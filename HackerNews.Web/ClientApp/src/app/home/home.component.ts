import { Component } from '@angular/core';
import { StoryService } from '../../domain/story.service';
import { Story } from '../../domain/story.model';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './home.component.html',
  providers: [StoryService]
})
export class HomeComponent {
  public stories: Story[];
  public query: string = "";
  public page: number = 1;
  public results: number = 10;
  public totalCount: number;
  private _storyService: StoryService;

  constructor(storyService: StoryService) {
    this._storyService = storyService;
    this._storyService.getStories(5).subscribe(result => {
      this.stories = result;
      this.totalCount = result.length;
    }, error=>console.log(error));
  }

  /**
   * Queries backend for subset of stories.
   * @param query -  Username or portion of the title of a story
   */
  public search(query: string)
  {
    this.stories = null;
    this._storyService.queryStories(this.page, this.results, this.query).subscribe(data => {
      this.totalCount = data.totalCount;
      this.stories = data.stories;
    }, error => console.log(error));
  }


}


