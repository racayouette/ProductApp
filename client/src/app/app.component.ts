import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { AppService } from './app.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';
import { MatDialogRef } from '@angular/material/dialog';

interface Post {
  id: number;
  title: string;
  body: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  displayedColumns: string[] = ['id', 'title', 'body', 'actions'];
  dataSource = new MatTableDataSource<Post>([]);

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private apiService: AppService, public dialog: MatDialog) {}

  ngOnInit(): void {
    this.loadPosts();
  }

  loadPosts(): void {
    this.apiService.getPosts().subscribe((data) => {
      this.dataSource.data = data;
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  }

  // Open dialog to create or edit post
  openDialog(post?: Post): void {
    const dialogRef = this.dialog.open(PostDialogComponent, {
      data: post,
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        if (post) {
          this.apiService.updatePost(result).subscribe(() => this.loadPosts());
        } else {
          this.apiService.createPost(result).subscribe(() => this.loadPosts());
        }
      }
    });
  }

  // Delete a post
  deletePost(id: number): void {
    if (confirm('Are you sure you want to delete this post?')) {
      this.apiService.deletePost(id).subscribe(() => this.loadPosts());
    }
  }
}

// Dialog component for adding and editing posts
@Component({
  selector: 'post-dialog',
  template: `
    <h1 mat-dialog-title>{{ data ? 'Edit Post' : 'Create Post' }}</h1>
    <div mat-dialog-content>
      <mat-form-field>
        <mat-cell>Title</mat-cell>
        <input matInput [(ngModel)]="post.title" />
      </mat-form-field>
      <mat-form-field>
        <mat-cell>Body</mat-cell>
        <textarea matInput [(ngModel)]="post.body"></textarea>
      </mat-form-field>
    </div>
    <div mat-dialog-actions>
      <button mat-button (click)="dialogRef.close()">Cancel</button>
      <button mat-button (click)="dialogRef.close(post)">Save</button>
    </div>
  `,
})
export class PostDialogComponent {
  post: Post = { id: 0, title: '', body: '' };

  constructor(
    public dialogRef: MatDialogRef<PostDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Post | undefined
  ) {
    if (data) {
      this.post = { ...data };
    }
  }
}
