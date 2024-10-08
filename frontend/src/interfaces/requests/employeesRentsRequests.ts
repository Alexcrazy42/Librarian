export interface EmployeeEdBookRentRequest {
    employeeId: string;
    edBookInBalanceId: string;
    count: number;
    startDate: Date;
    endDate: Date;
}

export interface ReturnEdBookFromEmployeeRequest {
    id: string;
    count: number;
}