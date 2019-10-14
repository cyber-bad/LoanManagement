import { Loan } from "../model/Loan";

export const GET_LOANS = 'GET_LOANS;'
export const GET_LOANS_SUCCESS = 'GET_LOANS_SUCCESS;'


export class GetLoansAction {
    readonly type = GET_LOANS;
    constructor() {}
}
export class GetLoansSuccessAction {
    readonly type = GET_LOANS_SUCCESS;
    constructor(public payload: Loan[]) { }
}
export type Action
    = GetLoansAction
    | GetLoansSuccessAction
