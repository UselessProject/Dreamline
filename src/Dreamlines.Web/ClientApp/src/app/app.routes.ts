import { Routes } from "@angular/router";
import { SalesUnitReportComponent } from "./sales-unit-report/sales-unit-report.component";
import { BookingReportComponent } from "./booking-report/booking-report.component";

export const AppRoutes: Routes = [
    {path: "", component: SalesUnitReportComponent},
    {path: "booking/:id", component: BookingReportComponent}
];