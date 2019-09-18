export interface Story {
  id: number;
  by: string;
  title: string;
  url: string;
}

export interface StoryQueryResult
{
  totalCount: number;
  stories: Story[];
}
