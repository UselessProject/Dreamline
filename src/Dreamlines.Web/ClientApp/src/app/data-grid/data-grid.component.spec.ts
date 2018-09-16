import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DataGridComponent, PaginatedResult } from './data-grid.component';
import { Observable } from "rxjs";
import { By } from "@angular/platform-browser";

describe('DataGridComponent', () => {

    let component: DataGridComponent;
    let fixture: ComponentFixture<DataGridComponent>;

    beforeEach(async(() => {
        TestBed
            .configureTestingModule({
                declarations: [DataGridComponent]
            })
            .compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(DataGridComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it("Grid should show data", () => {
        const ds$ = new Observable<DummyRecord[]>(observer => {
            observer.next([
                {text: "Item 1", value: 1},
                {text: "Item 2", value: 2}
            ]);
        });

        component.columns = [
            {name: "text", header: "Text"},
            {name: "value", header: "Value"}
        ];

        component.dataSource = ds$;

        fixture.detectChanges();

        const table = fixture.debugElement
            .query(By.css("table")).nativeElement as HTMLTableElement;
        
        const header = table.querySelectorAll("th");
        expect(header.item(0).innerHTML).toEqual("Text");
        expect(header.item(1).innerHTML).toEqual("Value");
        
        const columns = table.querySelectorAll("td");
        expect(columns.item(0).innerHTML).toEqual("Item 1");
        expect(columns.item(1).innerHTML).toEqual("1");
        expect(columns.item(2).innerHTML).toEqual("Item 2");
        expect(columns.item(3).innerHTML).toEqual("2");
    });

});

interface DummyRecord {
    readonly text: string;
    readonly value: number;
}
