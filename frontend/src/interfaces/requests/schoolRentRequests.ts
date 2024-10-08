export interface CreateEdBookSchoolRentRequest {
    debtorSchoolGroundId: string;
    ownerSchoolGroundId: string;
    edBookInBalanceId: string;
    requestingBookCount: number;
    endRentAt: Date;
}

export enum SchoolRentConversationMessageStatus {
    Message = 0,
    Accept = 1,
    Reject = 2,
    ReadyGivePartOfBook = 3
}

export interface SendMessageToRentRequestRequest {
    rentRequestId: string;
    groundSenderId: string;
    message: string;
    status: SchoolRentConversationMessageStatus;
    readyGiveBookCount?: number;
    readyEndRentAt?: Date;
}

export interface SendMessageToRentRequestResponseRequest {
    rentRequestId: string;
    groundSenderId: string;
    message: string;
    changeRequestedBookCount?: number;
    changeEndRentAt?: Date; 
}