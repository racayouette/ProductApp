import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

interface Post {
  id: number;
  title: string;
  body: string;
}

@Injectable({
  providedIn: 'root',
})
export class AppService {
  private apiUrl = 'https://jsonplaceholder.typicode.com/posts'; // Fake API URL

  constructor(private http: HttpClient) {}

  // Get posts
  getPosts(): Observable<Post[]> {
    return this.http.get<Post[]>(this.apiUrl);
  }

  // Create a new post
  createPost(post: Post): Observable<Post> {
    return this.http.post<Post>(this.apiUrl, post);
  }

  // Update an existing post
  updatePost(post: Post): Observable<Post> {
    return this.http.put<Post>(`${this.apiUrl}/${post.id}`, post);
  }

  // Delete a post
  deletePost(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
