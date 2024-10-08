export interface CreateClassSubjectStructureRequest {
    groundId: string;
    classSubjects: CreateClassSubject[];
}

export interface CreateClassSubject {
    schoolClassId: string;
    subjects: CreateSubjectRequest[];
}

export interface CreateSubjectRequest {
    subjectId?: string;
    subjectName?: string;
    chapterNames: string[];
}

export interface SetEdBookToClassSubjectChapterRequest {
    classSubjectChapterId: string;
    edBookInBalanceId: string;
}

export interface UpdateClassSubjectRequest {
    id: string;
    subjectId: string;
}

export interface UpdateSubjectChapterEdBookRequest {
    id: string;
    edBookInBalanceId: string;
}

export interface UpdateSubjectChapterRequest {
    id: string;
    title: string;
}