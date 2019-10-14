import { Component, OnInit } from '@angular/core';
import { Loan } from '../model/Loan';
import { LoanService } from '../services/loan.service';


@Component({
    selector: 'loan',
    templateUrl: './loan.component.html',
    styleUrls: ['./loan.component.css']
})
export class LoanComponent implements OnInit {

    loans: Loan[];
    carryOverAmount: number=0;
    hasError: boolean;
    errorMessage: string;
    hasInfo: boolean;
    infoMessage: string;
    canApplyForNewLoan: boolean;

    constructor(private loanService: LoanService) { }

    ngOnInit() {
        this.getLoans();
    }

    getLoans(): void {
        this.loanService.getLoans()
            .subscribe(loans => { this.loans = loans; this.canApplyForLoan(); },
                (error) => {
                    this.hasError = true;
                    this.errorMessage = error;
                }
            );
            
    }

    calculatePayout(): void {
        this.carryOverAmount = 0.0;

        for (var i = 0; i < this.loans.length; i++) {
            if (this.loans[i].isSelected) {
                this.carryOverAmount += this.loans[i].carryOverAmount;
            }
        }

    }

    canApplyForLoan(): void {
        if (this.loans.length > 2) {
            this.canApplyForNewLoan = false;
            this.infoMessage = 'With 3 or more personal loans, a new loan is not possible in this flow.';
            this.hasInfo = true;
        }

    }


}
