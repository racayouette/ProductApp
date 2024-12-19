import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule, HttpParams } from '@angular/common/http';
import { AfterViewInit, Component, EventEmitter, inject, OnInit, Output, viewChild, ViewChild } from '@angular/core';
import { Products } from './model/Products';
import { ProductListComponent } from "./product-list/product-list.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [HttpClientModule,
    ProductListComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements AfterViewInit {

  httpClient = inject(HttpClient);
  data: Products[] = []; 
  length: number = this.data.length;
  pageSize: number = 5;

  ngAfterViewInit(): void {
    this.fetchData();
  }

    // fetchData(index: number, size: number) {
    // HTTP GET request with pagination parameters
    // const params = new HttpParams()
    //      .set('parms', index.toString() + ':' + size.toString());
    // this.httpClient
    //.get<any>('https://localhost:5000/api/Products', { params })
    
    fetchData() {
    this.httpClient
    .get<any>('https://localhost:5000/api/Products2')
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
        // TODO: something here
        // this.isLoadingResults = false;
      },
    });
  }
}