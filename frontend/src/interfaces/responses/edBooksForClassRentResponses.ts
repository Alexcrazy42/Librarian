import { EdBookInBalanceResponse } from "./edBooksResponses";

export interface GetClassEdBookRentsResponse {
    id: string;
    studentId: string;
    edBook: EdBookInBalanceResponse;
    count: number;
    isOverdue: boolean;
    startDate: Date;
    endDate: Date;
}

export interface StudentEdBookInBalanceRentResponse {
    id: string;
    studentId: string;
    edBookInBalanceId: string;
    count: number;
    isOverdue: boolean;
    startDate: Date;
    endDate: Date;
}