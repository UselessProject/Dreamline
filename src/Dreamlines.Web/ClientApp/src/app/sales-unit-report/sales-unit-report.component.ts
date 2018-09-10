import { Component, OnInit } from '@angular/core';
import { Subject } from "rxjs";
import { Column } from "../data-grid/data-grid.component";
import { SalesUnitService, SalesUnitSummary } from "../../services/sales-unit";
import { SalesUnitRecord } from "../app.component";

@Component({
  selector: 'app-sales-unit-report',
  templateUrl: './sales-unit-report.component.html',
  styleUrls: ['./sales-unit-report.component.scss']
})
export class SalesUnitReportComponent implements OnInit {

    private currencySeparatorRegex = /\d(?=(\d{3})+\.)/g;
    private currencySeparator = "$&,";

    // filter properties
    public isCollapsed = true;
    public fromDate: Date = new Date(2016, 0, 1);
    public toDate: Date = new Date(2016, 2, 1);
    public totalResult: number = 0;

    // data grid properties
    public dataSource$ = new Subject<SalesUnitRecord[]>();
    public gridColumns: Column[] = [
        {name: 'id', header: '#', className: 'd-none d-lg-table-cell text-truncate'},
        {name: 'unit', header: 'Name', className: 'text-truncate'},
        {name: 'country', header: 'Country', className: 'd-none d-lg-table-cell text-truncate'},
        {name: 'quantity', header: 'Quantity', className: 'd-none d-lg-table-cell text-truncate'},
        {name: 'price', header: 'Price', className: 'text-truncate'}
    ];

    constructor(readonly salesUnitService: SalesUnitService) {
    }

    ngOnInit(): void {
        this.search();
    }

    search() {
        this.salesUnitService.search({
            skip: 0,
            limit: 100,
            fromDate: this.fromDate,
            toDate: this.toDate
        }).subscribe(data => {
            this.dataSource$.next(data.result.map(this.mapSummaryRecords.bind(this)));
            this.totalResult = data.total;
        });
    }

    mapSummaryRecords(summary: SalesUnitSummary): SalesUnitRecord {
        return {
            id: summary.salesUnitId,
            unit: summary.salesUnitName,
            country: summary.countryName,
            quantity: summary.totalBooking,
            price: `${summary.currencySymbol} ${this.formatCurrency(summary.totalPrice)}`
        };
    }

    formatCurrency = (value: number) =>
        value.toFixed(3).replace(this.currencySeparatorRegex, this.currencySeparator);

}
