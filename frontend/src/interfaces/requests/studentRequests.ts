import { Person } from "@interfaces/interfaces";

export interface addStudentsToClassRequest
{
    classId: string;
    students: Person[];
}

export interface TransferStudentsFromOneClassToAnotherRequest
{
    oldClass: string;
    newClass: string;
}