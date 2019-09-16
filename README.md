# hackernewsnetcoreapp
A small .net core angular app which pings github.com/HackerNews/API

# Requirements
Use https://github.com/HackerNews/API to generate a modern, web-based solution using C# and .NET Core that displays the title and author of the newest stories on Hacker News. This should be your code, so don’t just drop a library in and don’t use Razor.

There should be tests. It should compile and run. The title should take you to the article.

 

If you have time, try some of the bonuses:

·         Add a search function.

·         Build caching.

·         Put it on Azure and send us a link to it working.

 

# Architecture
 ## .net Core MVC
    A .net core MVC app will serve as the infrastructure for this application. It will query and hold the top 500 stories in memory. That list can be cleared and refreshed by the end user. It will expose endpoints accessible by the front end, which will be written in Angular. 

    /query/:count:page:text
    - Searches by title or username

    /reset
    - Clears existing stories and pulls latest 500 stories into memory


    
 ## Angular 2
    The front end will support the following controls:
        - Number of results per page and page number.
        - Search text field.
        - Refresh data store.

 ## DAL
    One service will support data access. The interface for which will expose:
        - LoadTopStories
        - QueryStories(skip, take, [search])
    A Story object will represent the title, author of username, url link to the story. Additional properties like inception date and comment count may be added.

 ### Raw Data
    -   HackerNews/API exposes top 500 new stories through an endpoint which returns an array of IDS: https://hacker-news.firebaseio.com//v0/newstories.json?print=pretty
    -   Story data object is exposed through https://hacker-news.firebaseio.com/v0/item/<ID>.json?print=pretty
        -  Where ID is an integer
    -   User data is exposed through https://hacker-news.firebaseio.com/v0/user/<ID>.json?print=pretty
        -   Where ID is a case sensitive user ID
