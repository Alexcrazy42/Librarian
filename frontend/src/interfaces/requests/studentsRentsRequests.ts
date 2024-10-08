export interface ReturnEdBookFromStudentRequest {
    id: string;
    count: number;
}

export interface StudentEdBookRentRequest {
    studentId: string;
    edBookInBalanceId: string;
    count: number;
    startDate: Date;
    endDate: Date;
}