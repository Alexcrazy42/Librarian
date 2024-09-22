import axios, { AxiosRequestConfig, Method, AxiosError, AxiosResponse } from 'axios';

let apiUrl = '';

export const API_BASE_URL = apiUrl;

type UploadProgressFn = (uploadPercentage: number) => any;

export class ApiRequest<T = any> {
    __unifyErrorsHandler = true;
    private __method: Method = 'GET';
    private __url = '/';
    private __initialUrl = '/';
    private __options: AxiosRequestConfig = {
        headers: {},
    };
    private __data = null;
    private __onUploadProgress: UploadProgressFn = null;
    private abortFetchFunctions: Function[] = null;
    // __qsParams: object = null;
    // static events = new EventEmitter<ApiRequestEvents>();

    constructor(url = 'GET /', unifyErrorsHandler = true) {
        this.__unifyErrorsHandler = unifyErrorsHandler;
        const spaceIndex = url.indexOf(' ');
        this.__method = url
            .substr(0, spaceIndex)
            .trim()
            .toUpperCase() as Method;
        this.__url = url.substr(spaceIndex + 1).trim();
        this.__initialUrl = this.__url;
    }

    private isAbsolute(url: string) {
        return url.indexOf('http://') === 0 || url.indexOf('https://') === 0 || url.indexOf('//') === 0;
    }

    buildUrl = (baseUrl: string) => {
        if (this.isAbsolute(this.__initialUrl)) {
            this.__url = this.__initialUrl;
        } else {
            if (baseUrl === '/') baseUrl = '';
            if (baseUrl.charAt(-1) === '/') baseUrl = baseUrl.substr(0, baseUrl.length - 1);

            this.__url = baseUrl + this.__initialUrl;
            this.buildQueryString();
        }

        return this;
    }

    qs(params: object = {}) {
        this.__qsParams = params;

        return this;
    }

    private buildQueryString() {
        const params = this.__qsParams;

        const url = new URL(this.__url, window.location.href);
        for (const key in params) {
            if (!params.hasOwnProperty(key)) continue;
            if (params[key] !== undefined && params[key] !== null) {
                url.searchParams.set(key, params[key]);
            }
        }

        this.__url = url.href;
    }

    // Зарегистрировать функция из которой дергаем запрос (нужно например для отмены запросов)
    registerAbort(abortFetchFunctions: Function[]) {
        this.abortFetchFunctions = abortFetchFunctions;
        return this;
    }

    onUploadProgress(func: UploadProgressFn) {
        this.__onUploadProgress = func;

        return this;
    }

    options(options: AxiosRequestConfig = {}) {
        this.__options = {
            ...this.__options,
            ...options,
        };

        return this;
    }

    setAccessToken = (options: AxiosRequestConfig) => {
        // Send authorization header if we can
        const userAccessToken = getUserAccessToken();
        if (userAccessToken) {
            options.headers.Authorization = 'Bearer ' + userAccessToken;
        }
    }

    private async __send() {
        let options: AxiosRequestConfig = {
            ...this.__options,
            method: this.__method,
            withCredentials: true,
        };
        if (this.__data !== null) options.data = this.__data;

        this.buildUrl(API_BASE_URL);

        // Send authorization header if we can
        this.setAccessToken(options);


        options.url = this.__url;

        // Upload progress
        options.onUploadProgress = (progressEvent) => {
            let uploadPercentage = parseInt(Math.round((progressEvent.loaded * 100) / progressEvent.total) + '');
            if (typeof this.__onUploadProgress === 'function') {
                this.__onUploadProgress(uploadPercentage);
            }
        };

        let abortFn = null;

        if (this.abortFetchFunctions) {
            const controller = new AbortController();
            options.signal = controller.signal;
            abortFn = () => controller.abort();
            this.abortFetchFunctions.push(abortFn);
        }

        let response: AxiosResponse;
        let error: AxiosError;

        try {
            response = await axios(options);
        } catch (e) {
            error = e;
            response = error.response;
        } finally {
            if (this.abortFetchFunctions) {
                this.abortFetchFunctions = this.abortFetchFunctions.filter((item) => item !== abortFn);
            }
        }

        // Network connection error and there is no response object
        if (response === undefined) throw error;


        /**
         * Success
         */
        if (response.status >= 200 && response.status < 300) {
            let resp = response.data;

            return resp;
        } else {
            /**
             * Errors
             */
            error.message = response?.data?.message || error.message;

            if (!this.__unifyErrorsHandler) throw error;

            // Universal error handling here
            console.error(error);

            throw error;
        }
    }

    async sendJSON(data: object = {}): Promise<T> {
        this.__data = JSON.stringify(data);

        this.__options.headers['Content-Type'] = 'application/json';

        return this.__send();
    }

    async send(data = null): Promise<T> {
        this.__data = data;

        return this.__send();
    }
}

export function getUserAccessToken() {
    return window.localStorage.getItem('access_token');
}
