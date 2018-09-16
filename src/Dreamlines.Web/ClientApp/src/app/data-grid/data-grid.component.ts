import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Observable } from "rxjs";

export interface PaginatedResult<T = any> {
    readonly skip: number;
    readonly limit: number;
    readonly total: number;
    readonly result: T[];
}

export interface Column {
    readonly name: string;
    readonly header: string;
    readonly className?: string;
    readonly href?: string;
}

@Component({
    selector: 'app-data-grid',
    templateUrl: './data-grid.component.html',
    styleUrls: ['./data-grid.component.scss']
})
export class DataGridComponent{

    @Input() columns: Column[];
    @Input() dataSource: Observable<any>;
    @Output() rowClick: EventEmitter<any> = new EventEmitter();
    
    onRowClick(record: any) {
        this.rowClick.emit(record);
    }

}
