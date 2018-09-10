import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { PaginatedResult } from "../app/data-grid/data-grid.component";

export interface SearchRequest {
    readonly fromDate: Date;
    readonly toDate: Date;
    readonly skip: number;
    readonly limit: number;
}

export interface SalesUnitSummary {
    readonly salesUnitId: number;
    readonly countryName: string;
    readonly salesUnitName: string;
    readonly totalBooking: number;
    readonly totalPrice: number;
    readonly currencySymbol: string;
}

@Injectable()
export class SalesUnitService {
    
    constructor(readonly http: HttpClient) {}
    
    search(request: SearchRequest) {
        return this.http.post<PaginatedResult<SalesUnitSummary>>(
            "/api/salesunit/search", request);
    }
    
}
