# Personal Reviews

## Overview

Personal Reviews is a web application developed using ASP.NET Core Razor Pages and PostgreSQL for managing and sharing reviews of various media types, such as movies, books, and games. 
Users can add, edit, delete, and view reviews, with options for filtering and sorting.

## Technologies Used

- **Language**: C#
- **Framework**: .NET 8
- **Web Framework**: ASP.NET Core Razor Pages
- **Database**: PostgreSQL
- **ORM**: Entity Framework Core

## Setting Up the Application Locally

To run the Personal Reviews application on your local machine, follow these steps:

### Prerequisites

1. **.NET SDK**: Ensure you have [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) installed.
2. **Visual Studio 2022**: Install Visual Studio 2022 with the ASP.NET and web development workload.
3. **PostgreSQL**: Install [PostgreSQL](https://www.postgresql.org/download/) on your local machine.
4. **PostgreSQL Management Tool**: (Optional) Use tools like [pgAdmin](https://www.pgadmin.org/download/) for database management.

### Steps to Set Up

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/snehith777/PersonalReviews.git
   cd PersonalReviews
2. **Setup the database**:

Create a new PostgreSQL database named PersonalReviews.
Run the following SQL script to create the required table:

CREATE TABLE "Reviews" (
    "ReviewID" SERIAL PRIMARY KEY,
    "Title" VARCHAR NOT NULL,
    "Category" VARCHAR NOT NULL,
    "ReviewText" TEXT NOT NULL,
    "Rating" INTEGER NOT NULL CHECK (Rating >= 1 AND Rating <= 5),
    "DateReviewed" TIMESTAMP WITH TIME ZONE NOT NULL
);


3. **Update the Connection String**:
Open appsettings.json and update the connection string to point to your PostgreSQL database
4. **Run Migrations**:
Open a terminal in the project directory and run the migration commands.
5.  **Run the Application**:
In Visual Studio, set the project as the startup project and press F5 or click on the Run button.

**Application Architecture**
The application follows the Model-View-Controller (MVC) architecture pattern, using Razor Pages for the view layer.

**Model**: 
Represents the data structure (Review class) and database interactions using Entity Framework Core.
**View**: 
Razor Pages for displaying the UI and handling user interactions.
**Controller Logic**: 
Handled in Page Models to manage user requests and responses.

**Design Decisions**
**User Interface**: Implemented with Bootstrap for a responsive and clean design.
**Filtering and Sorting**: Users can filter reviews by category and rating, enhancing the user experience.
**Pagination**: Included to manage long lists of reviews effectively.

**Assumptions and Considerations**
The application assumes that the user has a basic understanding of how to use a web browser and navigate forms.
Error handling is in place for invalid inputs, but additional logging and monitoring could be added for production readiness.
Media Reviewed

For the reviews, I chose a variety of media that I found personally impactful. The reviews include:
Movies: Analyzing storytelling, cinematography, and emotional impact.
Books: Reflecting on narrative style, themes, and character development.
Games: Evaluating gameplay mechanics, graphics, and overall engagement.
This variety allows users to see different perspectives on various media types.
