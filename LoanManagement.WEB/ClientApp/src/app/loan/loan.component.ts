import { Component, OnInit } from '@angular/core';
import { Loan } from '../model/Loan';
import { LoanService } from '../services/loan.service';


@Component({
  selector: 'loan',
  templateUrl: './loan.component.html',
})
export class LoanComponent implements OnInit {

    loans: Loan[];

    constructor(private loanService: LoanService) { }

    ngOnInit() {
        this.getLoans();
    }

    getLoans(): void {
        this.loanService.getLoans()
            .subscribe(loans => this.loans = loans);
    }

}
