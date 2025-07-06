# iiDENTIFii Forum

## Project Overview
The iiDENTIFii Forum is a web-based platform designed to facilitate discussions among a small number of users (< 100). The forum allows users to create posts, comment on posts, and like posts. Moderators have additional privileges to tag posts as "misleading or false information" for regulatory purposes.

## Working with the project

### Overview
A number of items need to be correctly prepared before starting the project up and running it. these are:
1. Setting up the database
2. Building the project

In addition, the Postman collection will require the `bearer` token for a number of requests.

There are a number of Test users that are seeded with the project on the initial database migration and they all use the same base password: `no_3ntrY`.<br>
<br>
These users are named after the main function they've been added to the database for
| Name      | Username              | Reason added      |
| --------  | -------               | -------           |
| Arthur    | arthur@gmail.com      | Authoring posts   |
| Luke      | luke@gmail.com        | Liking posts      |
| Martin    | martin@gmail.com      | Moderator         |

### Setting up the database

These instructions are based off of the Microsoft Learn module which can be found at the following link: [SQLite Tutorial](https://learn.microsoft.com/en-us/training/paths/aspnet-core-minimal-api/)<br>
<br>
In the Powershell console enter the following commanders in the `iiDENTIFii-forum\iiDENTIFii.Forum` folder containing the iiDENTIFii-forum\iiDENTIFii.Forum.csproj file<br>

1. `dotnet ef migrations add InitialCreate`
2. `dotnet ef database update`

### Run the project

In Visual Studio, build the project and then you will be able to run it either through the IDE or opening the executable via your Console. The included Postman collection contains an endpoint to interact with all of the endpoints correctly all that is needed is to use the Login method and copy the Token into the requests you wish to perform.

## Feature Requirements

### User Functionality
1. **Post Creation**: Users can create posts. ✅
2. **Commenting**: Users can add comments to posts. ✅
3. **Likes**: Users can like posts, but cannot like their own posts or like a post more than once. ✅
4. **Anonymous Viewing**: Posts can be viewed anonymously, but login is required for posting, commenting, or liking. ✅
5. **Login and Registration**: As implied by the previous functionality a user is required to be able to log in and register for the forum. ✅

### Moderator Functionality
1. **Tagging Posts**: Moderators can tag posts as "misleading or false information". ✅

### Post Retrieval
1. **Pagination**: Retrieve posts with pagination.
2. **Filters**: Filter posts by date range, author, tags.
3. **Sorting**: Sort posts by date or like count.

## Backend Specifications
1. Built using **C#** and **ASP.NET**. ✅
2. Datastore backend is flexible but must integrate efficiently with ASP.NET. ✅
3. User authentication is handled within the application (no external auth providers). ✅
4. Provides a simple API for external third-party applications, documented in Postman. ✅

## Testing
1. Includes either a rudimentary UI (MVC pattern) or a Postman collection for API testing. ✅

## Submission Guidelines
1. Code is submitted via a public GitHub repository with a full commit history. ✅
2. README contains instructions to run the project locally, including external dependencies. ✅
3. Includes a datastore with test/dummy data. ✅
4. Provides a public Postman collection for API endpoint testing. ✅
