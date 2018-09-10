import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from "@angular/router";

import { AppComponent } from './app.component';

import { CollapseModule, BsDatepickerModule } from 'ngx-bootstrap';
import { DataGridComponent } from './data-grid/data-grid.component';

import { SalesUnitService } from "../services/sales-unit";
import { SalesUnitReportComponent } from './sales-unit-report/sales-unit-report.component';

const appRoutes: Routes = [
    {path: "", component: SalesUnitReportComponent}
];

@NgModule({
    declarations: [
        AppComponent,
        DataGridComponent,
        SalesUnitReportComponent
    ],
    imports: [
        BrowserModule,
        FormsModule,
        HttpClientModule,
        RouterModule.forRoot(appRoutes),
        CollapseModule,
        BsDatepickerModule.forRoot()
    ],
    providers: [SalesUnitService],
    bootstrap: [AppComponent]
})
export class AppModule {
}
