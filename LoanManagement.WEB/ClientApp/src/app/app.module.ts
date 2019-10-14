import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { LoanComponent } from './loan/loan.component';
import { StoreModule } from '@ngrx/store';
import { loanReducer } from './reducers/loan.reducer';


@NgModule({
    declarations: [
        AppComponent,
        LoanComponent
    ],
    imports: [
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        HttpClientModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', component: LoanComponent },
            { path: 'loan', component: LoanComponent }

        ]),
        StoreModule.forRoot({loans:loanReducer})
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }
