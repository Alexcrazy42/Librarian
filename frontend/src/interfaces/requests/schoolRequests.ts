import { Person } from "@interfaces/interfaces";

export interface CreateSchoolStructureRequest {
    shortName: string;
    officialName: string;
    grounds: CreateSchoolGroundRequest[];
}

export interface CreateSchoolGroundRequest {
    name: string;
    classes: CreateSchoolClassRequest[];
    librarians: CreateLibrarianRequest[];
}

export interface CreateSchoolClassRequest {
    number: number;
    name: string;
    subjectCount: number;
}

export interface CreateLibrarianRequest {
    surname: string;
    name: string;
    patronymic: string;
    isGeneral: boolean;
}


export interface UpdateSchoolRequest {
    id: string;
    shortName: string;
    officialName: string;
}

export interface UpdateSchoolGroundRequest {
    id: string;
    name: string;
}

export interface UpdateLibrarianRequest extends Person {
    id: string;
    isGeneral: boolean;
}