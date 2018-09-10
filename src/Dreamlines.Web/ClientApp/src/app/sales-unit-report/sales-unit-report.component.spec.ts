import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SalesUnitReportComponent } from './sales-unit-report.component';

describe('SalesUnitReportComponent', () => {
  let component: SalesUnitReportComponent;
  let fixture: ComponentFixture<SalesUnitReportComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SalesUnitReportComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SalesUnitReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
