import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LoanComponent } from './loan.component';

describe('LoanComponent', () => {
    let component: LoanComponent;
    let fixture: ComponentFixture<LoanComponent>;

    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [LoanComponent]
        })
            .compileComponents();
    }));
    beforeEach(() => {
        fixture = TestBed.createComponent(LoanComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });
    it('should create', () => {
        expect(component).toBeTruthy();
    });
    it('should render title in a h2 tag', async(() => {
        const fixture = TestBed.createComponent(LoanComponent);
        fixture.detectChanges();
        const compiled = fixture.debugElement.nativeElement;
        expect(compiled.querySelector('h2').textContent).toContain('Personal Loan TopUp or Apply');
    }));

    it('should render warning in a div tag', async(() => {
        const fixture = TestBed.createComponent(LoanComponent);
        fixture.detectChanges();
        const compiled = fixture.debugElement.nativeElement;
        expect(compiled.querySelector('div').textContent).toContain('With 3 or more personal loans');
    }));

    it('should render carryover in a div tag', async(() => {
        const fixture = TestBed.createComponent(LoanComponent);
        fixture.detectChanges();
        const compiled = fixture.debugElement.nativeElement;
        expect(compiled.querySelector('div').textContent).toContain('Carryover / Payout Amount');
    }));

    it('should render first loan in a div tag', async(() => {
        const fixture = TestBed.createComponent(LoanComponent);
        fixture.detectChanges();
        const compiled = fixture.debugElement.nativeElement;
        expect(compiled.querySelector('div').textContent).toContain('You have');
    }));

});
