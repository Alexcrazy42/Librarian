import { EmployeeStatus, Person } from "@interfaces/interfaces";

export interface CreateEmployeeRequest extends Person {
    employeeStatus: EmployeeStatus,
    schoolId: string;
    schoolGroundId: string;
    managementClassId?: string;
}

export interface UpdateEmployeeRequest extends Person {
    id: string;
    employeeStatus: EmployeeStatus;
    schoolId: string;
    schoolGroundId: string;
    managementClassId?: string;
}