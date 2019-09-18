
import { Injectable } from '@angular/core'
import { HttpClient } from '@angular/common/http';
import { Story, StoryQueryResult } from "./story.model";
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class StoryService 
{
  private base: string = "/api/Story";
  constructor(private http: HttpClient) {
    this.http = http;
  }

  public getStories(count: number) : Observable<Story[]> {
    return this.http.get<Story[]>(`${this.base}/Stories?count=${count}`);
  }

  public queryStories(page: number, results: number, query: string) : Observable<StoryQueryResult> {
    return this.http.get<StoryQueryResult>(`${this.base}/Query?page=${page}&results=${results}&query=${query}`);
  }
}
