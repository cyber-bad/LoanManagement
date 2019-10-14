import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { EMPTY } from 'rxjs';
import { map, mergeMap, catchError } from 'rxjs/operators';
import { LoanService } from '../services/loan.service';
import * as loanActions from './../actions/loan.action';

@Injectable()
export class LoanEffects {


    loans$ = this.actions$.pipe(
        ofType(loanActions.GET_LOANS),
        mergeMap(() => this.loanService.getLoans()
            .pipe(
                map(loans => ({ type: loanActions.GET_LOANS_SUCCESS, payload: loans })),
                catchError(() => EMPTY)
            )
    )
    );

   

    constructor(private actions$: Actions, private loanService: LoanService) {}
}
