import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from "@angular/router";

import { AppComponent } from './app.component';

import { CollapseModule, BsDatepickerModule } from 'ngx-bootstrap';
import { DataGridComponent } from './data-grid/data-grid.component';

import { SalesUnitService } from "../services/sales-unit-service";
import { SalesUnitReportComponent } from './sales-unit-report/sales-unit-report.component';

import { AppRoutes } from './app.routes';
import { BookingReportComponent } from './booking-report/booking-report.component';

@NgModule({
    declarations: [
        AppComponent,
        DataGridComponent,
        SalesUnitReportComponent,
        BookingReportComponent
    ],
    imports: [
        BrowserModule,
        FormsModule,
        HttpClientModule,
        RouterModule.forRoot(AppRoutes),
        CollapseModule,
        BsDatepickerModule.forRoot()
    ],
    providers: [SalesUnitService],
    bootstrap: [AppComponent]
})
export class AppModule {
}
