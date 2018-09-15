import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from "@angular/router";
import { SalesUnitService, SalesUnitSummary } from "../../services/sales-unit-service";
import { Column, PaginatedResult } from "../data-grid/data-grid.component";
import { formatNumber, toIsoDate, toUSDate as toUSDateFormat } from "../../utils";
import { Subject } from "rxjs";
import { BookingService, BookingSummary } from "../../services/booking-service";

export interface BookingRecord {
    readonly id: number;
    readonly ship: string;
    readonly price: string;
    readonly date: string;
}

@Component({
    selector: 'app-booking-report',
    templateUrl: './booking-report.component.html',
    styleUrls: ['./booking-report.component.scss']
})
export class BookingReportComponent implements OnInit {

    constructor(
        private readonly salesUnitService: SalesUnitService,
        private readonly bookingService: BookingService,
        private readonly route: ActivatedRoute) {
    }

    public dataSource$ = new Subject<BookingRecord[]>();
    public gridColumns: Column[] = [
        {name: 'id', header: '#', className: 'd-none d-lg-table-cell'},
        {name: 'ship', header: 'Ship'},
        {name: 'price', header: 'Price'},
        {name: 'date', header: 'Date', className: 'd-none d-lg-table-cell'},
    ];

    public fromDate: Date;
    public toDate: Date;
    public salesUnitName: string;
    public countryName: string;
    public totalBooking: string;
    public totalPrice: string;
    public currencySymbol: string;

    ngOnInit() {
        const {params, queryParams} = this.route.snapshot;
        this.fromDate = new Date(queryParams.start);
        this.toDate = new Date(queryParams.end);

        const salesUnitId = +params.id;

        this.salesUnitService
            .search({
                salesUnitId,
                fromDate: toIsoDate(this.fromDate),
                toDate: toIsoDate(this.toDate),
                skip: 0,
                limit: 100
            })
            .subscribe(this.onSalesUnitSummaryReceived.bind(this));

        this.bookingService
            .search({
                salesUnitId,
                fromDate: toIsoDate(this.fromDate),
                toDate: toIsoDate(this.toDate),
                skip: 0,
                limit: 100
            })
            .subscribe(this.onBookingSummaryReceived.bind(this));
    }

    private onSalesUnitSummaryReceived(summary: PaginatedResult<SalesUnitSummary>) {
        const [first] = summary.result;
        this.salesUnitName = first.salesUnitName;
        this.countryName = first.countryName;
        this.totalBooking = formatNumber(first.totalBooking, 0);
        this.totalPrice = formatNumber(first.totalPrice);
        this.currencySymbol = first.currencySymbol;
    }

    private onBookingSummaryReceived(summary: PaginatedResult<BookingSummary>) {
        this.dataSource$.next(summary.result.map(e => ({
            id: e.bookingId,
            ship: e.shipName,
            price: `${e.currencySymbol} ${formatNumber(e.price)}`,
            date: toUSDateFormat(new Date(e.bookingDate))
        })));
    }
    

}
