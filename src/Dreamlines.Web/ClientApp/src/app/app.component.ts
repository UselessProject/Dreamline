import { Component } from '@angular/core';

export interface SalesUnitRecord {
    readonly id: number;
    readonly unit: string;
    readonly country: string;
    readonly quantity: number;
    readonly price: string;
}

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss']
})
export class AppComponent {
    
}
