import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: 'app-booking-report',
  templateUrl: './booking-report.component.html',
  styleUrls: ['./booking-report.component.scss']
})
export class BookingReportComponent implements OnInit {

  constructor(private readonly route: ActivatedRoute) { }

  ngOnInit() {
      const id = +this.route.snapshot.params.id;
      console.log(id);
  }

}
