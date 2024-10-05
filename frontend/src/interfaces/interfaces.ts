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
  