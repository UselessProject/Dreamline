import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { PaginatedResult } from "../app/data-grid/data-grid.component";

export interface SearchRequest {
    readonly fromDate: string;
    readonly toDate: string;
    readonly skip: number;
    readonly limit: number;
    readonly salesUnitId: number;
}

export interface BookingSummary {
    readonly bookingId: number;
    readonly shipId: string;
    readonly shipName: string;
    readonly price: number;
    readonly currencySymbol: string;
    readonly bookingDate: Date;
}

@Injectable()
export class BookingService {

    constructor(readonly http: HttpClient) {}

    search(request: SearchRequest) {
        return this.http.post<PaginatedResult<BookingSummary>>(
            "/api/booking/search", request);
    }

}
