import { SalesUnitQuery, SalesUnitService, SalesUnitSummary } from "./sales-unit-service";
import { getTestBed, TestBed } from "@angular/core/testing";
import { HttpClientTestingModule, HttpTestingController } from "@angular/common/http/testing";
import { PaginatedResult } from "../app/data-grid/data-grid.component";

describe("SalesUnitService", () => {

    let container: TestBed;

    beforeEach(() => {
        TestBed.configureTestingModule({
            imports: [HttpClientTestingModule],
            providers: [SalesUnitService]
        });
        container = getTestBed();
    });

    it("search should return all summaries", (done: DoneFn) => {
        // arrange
        const expected: PaginatedResult<SalesUnitSummary> = {
            skip: 0,
            limit: 100,
            total: 1,
            result: [
                {
                    salesUnitId: 1,
                    countryName: 'Germany',
                    salesUnitName: 'Unit 1',
                    totalBooking: 1,
                    totalPrice: 1000,
                    currencySymbol: '$'
                }
            ]
        };

        const query: SalesUnitQuery = {
            skip: 0,
            limit: 100,
            fromDate: "2016-01-01",
            toDate: "2016-03-01",
        }

        const service = container.get(SalesUnitService) as SalesUnitService;
        const http = container.get(HttpTestingController) as HttpTestingController;

        // act & assert
        service.search(query).subscribe(actual => {
            expect(actual).toEqual(expected);
            done();
        });

        http.expectOne(req =>
            req.url === "/api/salesunit/search" &&
            req.body === query
        ).flush(expected);
    });

});