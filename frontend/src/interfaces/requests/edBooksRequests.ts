import { Appointment, BookCondition, Language, Level } from "@interfaces/interfaces";

export interface CreateBaseEdBookRequest {
    authorId: string;
    editorId: string;
    title: string;
    publishingPlaceId: string;
    publishingHouseId: string;
    publishingSeries: number;
    language: Language;
    level: Level;
    appointment: Appointment;
    chapter: number;
    subjectId: string;
    startClass: number;
    endClass: number;
    leaveFromFederalBooksListAt: string;
    anotherAuthorsIds: string[];
}

export interface CreateEdBookInBalanceRequest {
    baseEdBookId: string;
    price: number;
    condition: BookCondition;
    year: number;
    note: string;
    count: number;
    groundId: string;
    supplyId: string;
}

export interface GetSimilarBaseEdBookRequest {
    authorId?: string;
    editorId?: string;
    title?: string;
    publishingPlaceId?: string;
    publishingHouseId?: string;
    publishingSeries?: number;
    language?: Language;
    level?: Level;
    appointment?: Appointment;
    chapter?: number;
    subjectId?: string;
    startClass?: number;
    endClass?: number;
    leaveFromFederalBooksListAt?: string;
    anotherAuthorsIds: string[];
}