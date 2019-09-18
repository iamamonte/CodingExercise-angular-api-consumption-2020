

# Design Plan
 
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
# Implementation Notes
    Querying results from HackerNews and deserializing them is a time expensive process. The app will impose more limits on the number of stories pulled from HackerNews than originally planned.

    The following items are forthcoming:
    - Proper pagination and front end controls for managing maximum story count of the data store
    - Caching of the data store 
    - Angular component tests 
    - Docker integration 
    - Continuous integration via Jenkins (?)

# Resources
- https://github.com/HackerNews/API
- https://news.ycombinator.com/newest
- https://elanderson.net/2017/05/setting-up-visual-studio-code-for-debugging-asp-net-core/
- https://www.dotnetcurry.com/aspnet/1373/debugging-aspnet-core-using-visual-studio-code
- https://www.codemag.com/Article/1605081/Integrating-ASP.NET-MVC-and-Angular-JS
- https://www.skylinetechnologies.com/Blog/Skyline-Blog/February_2018/how-to-use-dot-net-core-cli-create-multi-project
- https://docs.microsoft.com/en-us/aspnet/core/client-side/spa/angular?view=aspnetcore-2.2&tabs=visual-studio
- https://angular.io/guide
- https://docs.microsoft.com/en-us/aspnet/core/performance/caching/memory?view=aspnetcore-2.2
