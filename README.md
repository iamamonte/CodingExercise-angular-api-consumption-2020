# hackernewsnetcoreapp
A small .net core angular app which pings github.com/HackerNews/API

# Requirements
Use https://github.com/HackerNews/API to generate a modern, web-based solution using C# and .NET Core that displays the title and author of the newest stories on Hacker News. This should be your code, so don’t just drop a library in and don’t use Razor.

There should be tests. It should compile and run. The title should take you to the article.

 

If you have time, try some of the bonuses:

·         Add a search function.

·         Build caching.

·         Put it on Azure and send us a link to it working.

 # Live Version
 A live version of the site is hosted at https://hackernewsweb.azurewebsites.net/


# Solution Architecture
 ## System Dependencies
      - .Net Core SDK 2.2.401+
      -  VS Code 1.38.1 or Visual Studio Community 2019
 ##  Deployment
      - Deployment to Azure App Service handled through Visual Studio Community's publish functionality.
 ## Solution Setup   
 The following commands were used to create the solution:
    
    ```console
    dotnet new sln -n HackerNews
    dotnet new classlib -f netcoreapp2.2 -n HackerNews.Domain
    dotnet new nunit -f netcoreapp2.2 -n HackerNews.Test
    dotnet new angular -f netcoreapp2.2 -n HackerNews.Web
    dotnet sln HackerNews.sln add .\HackerNews.Domain\HackerNews.Domain.csproj .\HackerNews.Test\HackerNews.Test.csproj .\HackerNews.Web\HackerNews.Web.csproj
    dotnet add .\HackerNews.Test\HackerNews.Test.csproj reference .\HackerNews.Domain\HackerNews.Domain.csproj
    dotnet add .\HackerNews.Web\HackerNews.Web.csproj reference .\HackerNews.Domain\HackerNews.Domain.csproj
    ```
 ## HackerNews.Domain
    - Contains domain objects and services.
 ## HackerNews.Test
    - Contains tests against HackerNews.Domain
 ## HackerNews.Web
    - Contains angular front end, MVC backend, front end tests.
 ## Extensions
   - .net core test explorer
   - C# XML Documentation Comments
   - C# for Visual Studio Code (powered by OmniSharp)
