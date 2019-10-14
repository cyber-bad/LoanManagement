import { Loan } from "./Loan";

export interface  AppState {
    loans: Loan[],
    hasError: boolean,
    errorMessage: string
}
