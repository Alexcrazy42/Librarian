import { Person } from "@interfaces/interfaces";

export interface LibrarianResponse extends Person {
    id: string;
    groundId: string;
    schoolId: string;
    isGeneral: boolean;
}

export interface SchoolClassWithoutManagerResponse {
    id: string;
    number: number;
    name: string;
    subjectCount: number;
    groundId: string;
    schoolId: string;
}

export interface SchoolGroundResponse {
    id: string;
    name: string;
    schoolId: string;
    classes: SchoolClassWithoutManagerResponse[];
    librarians: LibrarianResponse[];
}

export interface SchoolResponse {
    id: string;
    shortName: string;
    officialName: string;
    grounds: SchoolGroundResponse[];
}