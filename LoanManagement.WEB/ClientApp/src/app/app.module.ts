import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { LoanComponent } from './loan/loan.component';

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

        ])
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }
