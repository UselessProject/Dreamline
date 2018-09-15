import { Component, OnInit } from '@angular/core';
import { Subject } from "rxjs";
import { Column, PaginatedResult } from "../data-grid/data-grid.component";
import { SalesUnitService, SalesUnitSummary, SearchRequest } from "../../services/sales-unit-service";
import { Router } from "@angular/router";
import { formatNumber, toIsoDate } from "../../utils";

export interface SalesUnitRecord {
    readonly id: number;
    readonly unit: string;
    readonly country: string;
    readonly quantity: number;
    readonly price: string;
}

@Component({
    selector: 'app-sales-unit-report',
    templateUrl: './sales-unit-report.component.html',
    styleUrls: ['./sales-unit-report.component.scss']
})
export class SalesUnitReportComponent implements OnInit {
    
    // filter properties
    public hideAdvanceSearch = true;
    public fromDate: Date = new Date(2016, 0, 1);
    public toDate: Date = new Date(2016, 2, 1);
    public totalResult: number = 0;

    // data grid properties
    public dataSource$ = new Subject<SalesUnitRecord[]>();
    public gridColumns: Column[] = [
        {name: 'id', header: '#', className: 'd-none d-lg-table-cell'},
        {name: 'unit', header: 'Name'},
        {name: 'country', header: 'Country', className: 'd-none d-lg-table-cell'},
        {name: 'quantity', header: 'Quantity', className: 'd-none d-lg-table-cell'},
        {name: 'price', header: 'Price'}
    ];

    constructor(private readonly salesUnitService: SalesUnitService,
                private readonly router: Router) {
        this.onDataReceived = this.onDataReceived.bind(this);
        this.mapSummaryRecords = this.mapSummaryRecords.bind(this);
    }

    ngOnInit() {
        this.search();
    }

    search() {
        const searchRequest: SearchRequest = {
            skip: 0,
            limit: 100,
            fromDate: toIsoDate(this.fromDate),
            toDate: toIsoDate(this.toDate)
        };

        this.salesUnitService
            .search(searchRequest)
            .subscribe(this.onDataReceived);
    }
    
    onRowClick(record: SalesUnitRecord) {
        this.router.navigate(
            ["booking", record.id],
            {
                queryParams: {
                    start: toIsoDate(this.fromDate),
                    end: toIsoDate(this.toDate)
                }
            }
        );
    }
    
    private onDataReceived(data: PaginatedResult<SalesUnitSummary>) {
        this.dataSource$.next(
            data.result.map(this.mapSummaryRecords)
        );
        this.totalResult = data.total;
    }

    private mapSummaryRecords = (summary: SalesUnitSummary): SalesUnitRecord => ({
        id: summary.salesUnitId,
        unit: summary.salesUnitName,
        country: summary.countryName,
        quantity: summary.totalBooking,
        price: `${summary.currencySymbol} ${formatNumber(summary.totalPrice)}`
    });

}


