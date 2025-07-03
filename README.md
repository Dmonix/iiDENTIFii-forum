# iiDENTIFii Forum

## Project Overview
The iiDENTIFii Forum is a web-based platform designed to facilitate discussions among a small number of users (< 100). The forum allows users to create posts, comment on posts, and like posts. Moderators have additional privileges to tag posts as "misleading or false information" for regulatory purposes.

## Features

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
2. Datastore backend is flexible but must integrate efficiently with ASP.NET.
3. User authentication is handled within the application (no external auth providers). ✅
4. Provides a simple API for external third-party applications, documented in Postman.

## Testing
1. Includes either a rudimentary UI (MVC pattern) or a Postman collection for API testing.

## Submission Guidelines
1. Code is submitted via a public GitHub repository with a full commit history. ✅
2. README contains instructions to run the project locally, including external dependencies.
3. Includes a datastore with test/dummy data.
4. Provides a public Postman collection for API endpoint testing.
