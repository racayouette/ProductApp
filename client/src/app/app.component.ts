import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [MatTableModule, MatPaginatorModule, MatProgressSpinnerModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent implements OnInit {
  http = inject(HttpClient);
  title = 'ProductApp';
  users: any;

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  /* lazy loading table */
  displayedColumns: string[] = ['id', 'name', 'age'];
  dataSource = new MatTableDataSource<any>();
  totalRecords: number = 100; // total records (simulating from the server)
  isLoadingResults: boolean = false;

  ngOnInit(): void {
    this.http.get('https://localhost:5000/api/Users').subscribe({
      next: (response) => (this.users = response),
      error: (error) => console.log(error),
      complete: () => console.log('Request has completed'),
    });

    this.loadData();
  }

  // Simulate lazy loading of data from an API or server
  loadData() {
    this.isLoadingResults = true;

    // Simulate a delay (e.g., fetching data from an API)
    setTimeout(() => {
      const data = this.generateData(
        this.paginator.pageIndex,
        this.paginator.pageSize
      );
      this.dataSource.data = data;
      this.isLoadingResults = false;
    }, 1000);
  }

  // Simulate data generation based on pagination
  generateData(pageIndex: number, pageSize: number) {
    const data = [];
    const start = pageIndex * pageSize;
    const end = start + pageSize;
    for (let i = start; i < end; i++) {
      data.push({
        id: i + 1,
        name: `Name ${i + 1}`,
        age: 20 + Math.floor(Math.random() * 40),
      });
    }
    return data;
  }

  // Handle page changes
  onPageChange(event: any) {
    this.loadData();
  }
}
