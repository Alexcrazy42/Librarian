import { Appointment, BookCondition, Language, Level } from "@interfaces/interfaces";

export interface BaseEdBookResponse {
    id: string;
    title: string;
    publishingSeries: number;
    language: Language;
    level: Level;
    appointment: Appointment;
    chapter?: number;
    startClass: number;
    endClass: number;
}

export interface CanIssueEdBookInBalanceResponse {
    can: boolean;
    message?: string;
}

export interface EdBookInBalanceResponse {
    id: string;
    baseEdBook: BaseEdBookResponse;
    price: number;
    condition: BookCondition;
    year: number;
    note: string;
    inPlaceCount: number;
    totalCount: number;
    supplyId?: string;
    groundId?: string;
    inStock: boolean;
}