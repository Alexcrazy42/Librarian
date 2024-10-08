export interface Classroom {
    id: number;
    number: string;
    name: string;
    subjectsCount: number;
}
  
export interface Employee {
    id: number;
    fullName: string;
}

export interface Librarian {
    id: number;
    name: string;
}
  
export interface Venue {
    id: number;
    name: string;
    librarians: Librarian[];
    classrooms: Classroom[];
}
  
export interface School {
    id: number;
    name: string;
    venues: Venue[];
}

export interface Student {
    id: string;
    surname: string;
    name: string;
    patronymic: string;
    classId: number
}

export interface Person {
    surname: string;
    name: string;
    patronymic?: string;
}


export enum EmployeeStatus {
    Teacher = 0,
    NotTeacher = 1
}

export enum Level {
    Unknown = 0,
    Base = 1,
    Advanced = 2,
    Both = 3
}

export enum Appointment {
    Unknown = 0,
    Textbook = 1,
    Allowance = 2,
    Atlas = 3,
    Code = 4,
    Manual = 5
}

export enum Language {
    Unknown = 0,
    Russian = 1,
    English = 2,
    Spanish = 3,
    German = 4,
    French = 5
}

export enum BookCondition {
    Unknown = 0,
    New = 1,
    Good = 2,
    Satisfactorily = 3,
    Dilapidated = 4
}