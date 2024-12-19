import { FilterComponent } from "../filter/filter.component";
import { CommonModule } from '@angular/common';
import { AfterViewInit, Component, EventEmitter, Input, OnChanges, OnInit, ViewChild } from '@angular/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatTable, MatTableDataSource, MatTableModule } from '@angular/material/table';
//import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
//import { Observable } from 'rxjs';
//import { SortDirection } from '@angular/material/sort';
import { Products } from '../model/Products';
import { PageEvent, MatPaginatorModule, MatPaginator } from '@angular/material/paginator';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'app-product-list',
  standalone: true,
  imports: [CommonModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    MatSlideToggleModule,
    MatPaginatorModule,
    MatTableModule,
  //  FilterComponent
  ],
  templateUrl: './product-list.component.html',
  styleUrl: './product-list.component.css'
})
export class ProductListComponent {
  // bring data from another component
  @Input({required: true}) length!: number;
  @Input({required: true}) data!: Products[]; 
  @Input({required: true}) pageSize!: number;

  @ViewChild(MatPaginator, {static: true})  paginator!: MatPaginator;

  // set some values
  pageIndex: number = 0;
  title = 'fetchdata';
  dataSource: any;
  columnsToDisplay = ['id', 'imageUrl', 'productName', 'price'];
  getdata: Products[] = []; 

  // begin pagination
  pageSizeOptions = [5, 10, 25];
  hidePageSize = false;
  showPageSizeOptions = true;
  showFirstLastButtons = true;
  disabled = false;
  pageEvent: PageEvent = new PageEvent;

  ngOnChanges(): void {
    this.getdata = this.getPaginatedData(0, 5, this.data);
  }
    
  handlePageEvent(e: PageEvent) {
    this.pageEvent = e;
    this.length = e.length;
    this.pageSize = e.pageSize;
    this.pageIndex = e.pageIndex;
    this.getdata = this.getPaginatedData(e.pageIndex, e.pageSize, this.data); 
    this.dataSource = new MatTableDataSource(this.getdata);
  }
  
  getPaginatedData(pageNumber: number, pageSize: number, data: any): any {
    const startIndex = pageNumber * pageSize;
    const endIndex = startIndex + pageSize;
    return data.slice(startIndex, endIndex);
  }
}
