import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Loan } from '../model/Loan';

@Injectable({ providedIn: 'root', })
export class LoanService {
    loans: Loan[] = [];
    private loansUrl = 'http://localhost:56216/loan'; 
    httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    constructor(
        private http: HttpClient,
        private messageService: LoanService) { }


    getLoans(): Observable<Loan[]> {
        return this.http.get<Loan[]>(this.loansUrl)
            .pipe(
                catchError(this.handleError<Loan[]>('getLoans', []))
            );
    }

    private handleError<T>(operation = 'operation', result?: T) {
        return (error: any): Observable<T> => {
            console.error(error);

            return of(result as T);
        };
    }
}
