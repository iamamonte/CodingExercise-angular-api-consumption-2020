import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './home.component.html'
})
export class HomeComponent {
  public stories: Story[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Story[]>(baseUrl + 'api/Story/Stories').subscribe(result => {
      this.stories = result;
      console.log(this.stories);
    }, error => console.error(error));
  }
}

interface Story {
  id: number;
  by: string;
  title: string;
  url: string;
}
