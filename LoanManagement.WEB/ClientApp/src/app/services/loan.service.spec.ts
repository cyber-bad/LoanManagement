import { TestBed } from '@angular/core/testing';
import { LoanService } from './loan.service';


describe('LoanService', () => {
    let loanService: LoanService; 

    beforeEach(() => {
        TestBed.configureTestingModule({
            providers: [loanService]
        });

        loanService = TestBed.get(loanService); 
    });

    it('should be created', () => { 
        expect(loanService).toBeTruthy();
    });

    it('should have loans', () => {
        expect(loanService).toBeTruthy();
    });


});
