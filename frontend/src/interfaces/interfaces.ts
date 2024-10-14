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

export const getEmployeeStatusName = (employeeStatus: EmployeeStatus) : string => {
    switch(employeeStatus) {
        case EmployeeStatus.NotTeacher: return 'Не учитель';
        case EmployeeStatus.Teacher: return 'Учитель';
    }
}

export enum Level {
    Unknown = 0,
    Base = 1,
    Advanced = 2,
    Both = 3
}

export const getLevelName = (level: Level): string => {
    switch (level) {
        case Level.Base: return 'Базовый';
        case Level.Advanced: return 'Продвинутый';
        case Level.Both: return 'Оба';
        default: return 'Неизвестно';
    }
};

export enum Appointment {
    Unknown = 0,
    Textbook = 1,
    Allowance = 2,
    Atlas = 3,
    Code = 4,
    Manual = 5
}

export const getAppointmentName = (appointment: Appointment): string => {
    switch (appointment) {
        case Appointment.Textbook: return 'Учебник';
        case Appointment.Allowance: return 'Дополнительное пособие';
        case Appointment.Atlas: return 'Атлас';
        case Appointment.Code: return 'Код';
        case Appointment.Manual: return 'Руководство';
        default: return 'Неизвестно';
    }
};

export enum Language {
    Unknown = 0,
    Russian = 1,
    English = 2,
    Spanish = 3,
    German = 4,
    French = 5
}

export const getLanguageName = (lang: Language): string => {
    switch (lang) {
        case Language.Russian: return 'Русский';
        case Language.English: return 'Английский';
        case Language.Spanish: return 'Испанский';
        case Language.German: return 'Немецкий';
        case Language.French: return 'Французский';
        // default: return 'Неизвестно';
    }
};

export enum BookCondition {
    Unknown = 0,
    New = 1,
    Good = 2,
    Satisfactorily = 3,
    Dilapidated = 4
}

export const getConditionName = (condition: BookCondition): string => {
    switch (condition) {
        case BookCondition.New: return 'Новый';
        case BookCondition.Good: return 'Хороший';
        case BookCondition.Satisfactorily: return 'Удовлетворительный';
        case BookCondition.Dilapidated: return 'Убежденный';
        default: return 'Неизвестно';
    }
};
