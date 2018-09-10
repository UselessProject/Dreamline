import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';

import { CollapseModule, BsDatepickerModule } from 'ngx-bootstrap';
import { DataGridComponent } from './data-grid/data-grid.component';

import { SalesUnitService } from "../services/sales-unit";

@NgModule({
    declarations: [
        AppComponent,
        DataGridComponent
    ],
    imports: [
        BrowserModule,
        FormsModule,
        HttpClientModule,
        CollapseModule,
        BsDatepickerModule.forRoot()
    ],
    providers: [SalesUnitService],
    bootstrap: [AppComponent]
})
export class AppModule {
}
