import { BaseEdBookResponse, EdBookInBalanceResponse } from "./edBooksResponses";
import { SubjectResponse } from "./subjectResponses";

export interface ClassSubjectChapterResponse {
    id: string;
    chapterId: string;
    title: string;
    edBookInBalance: EdBookInBalanceResponse;
}

export interface ClassSubjectDto {
    schoolClassId: string;
    number: number;
    name: string;
    subjects: ClassSubjectResponse[];
}

export interface ClassSubjectResponse {
    id: string;
    subjectId: string;
    name: string;
    chapters: ClassSubjectChapterWithBookDto[];
}

export interface ClassSubjectChapterWithBookDto {
    id: string;
    title: string;
    edBook: BaseEdBookResponse;
}

export interface UpdateClassSubjectResponse {
    id: string;
    subject: SubjectResponse;
}

export interface UpdateSubjectChapterEdBookResponse {
    id: string;
    edBookInBalance: EdBookInBalanceResponse;
}

export interface UpdateSubjectChapterResponse {
    id: string;
    title: string;
}