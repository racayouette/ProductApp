import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule, HttpParams } from '@angular/common/http';
import { AfterViewInit, Component, inject, OnInit, viewChild, ViewChild } from '@angular/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatTable, MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { Observable } from 'rxjs';
import { SortDirection } from '@angular/material/sort';
import { Products } from './model/Products';
import { PageEvent, MatPaginatorModule, MatPaginator } from '@angular/material/paginator';
import {MatSlideToggleModule} from '@angular/material/slide-toggle';
import {FormsModule} from '@angular/forms';
import {MatInputModule} from '@angular/material/input';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, 
    HttpClientModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    MatSlideToggleModule,
    MatPaginatorModule,
    MatTableModule
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit, AfterViewInit {
 
  title = 'fetchdata';
  httpClient = inject(HttpClient);
  data: Products[] = []; 
  columnsToDisplay = ['id', 'imageUrl', 'productName', 'price'];
  dataSource = new MatTableDataSource(this.data);
  pageSize = 5;
  pageIndex: number = 0;

  @ViewChild(MatPaginator, {static: false})  paginator!: MatPaginator;

    // begin pagination
    length: number = this.data.length;
    
    pageSizeOptions = [5, 10, 25];
  
    hidePageSize = false;
    showPageSizeOptions = true;
    showFirstLastButtons = true;
    disabled = false;
  
    pageEvent: PageEvent = new PageEvent;

    ngOnInit(): void {
      this.pageIndex = 0;
      this.dataSource.paginator = this.paginator;
      this.fetchData(0, this.pageSize);
      this.dataSource = new MatTableDataSource(this.data);
    }
    
    ngAfterViewInit(): void {
      this.dataSource.paginator = this.paginator;
      this.dataSource = new MatTableDataSource(this.data);
    }
  
    handlePageEvent(e: PageEvent) {
      this.pageEvent = e;
      this.length = e.length;
      this.pageSize = e.pageSize;
      this.pageIndex = e.pageIndex;
      this.fetchData(e.pageIndex, e.pageSize);
    }
  
   fetchData(index: number, size: number) {
    
    // HTTP GET request with pagination parameters
    const params = new HttpParams()
      .set('parms', index.toString() + ':' + size.toString());
    this.httpClient
    .get<any>('https://localhost:5000/api/Products', { params })
    .subscribe({
      next: (response) => {
        this.data = response.items; // Assign the data for current page
        const totalItems = response.totalItems;
        this.length = totalItems; // Assign the total count for pagination
      },
      error: (error) => {
        console.error('Error fetching data:', error);
      },
      complete: () => {
        // this.isLoadingResults = false;
      },
    });
  }
}

