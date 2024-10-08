import { EmployeeStatus, Person } from "@interfaces/interfaces";

export interface EmployeeResponse extends Person {
    id: string;
    employeeStatus: EmployeeStatus;
    schoolId?: string;
    schoolGroundId?: string;
    managementClass?: SchoolClassResponse;
}

export interface SchoolClassResponse {
    id: string;
    number: number;
    name: string;
}
