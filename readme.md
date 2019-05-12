This application is built with Asp.NET Core and PostgreSQL. Users may write reviews for restaurants
and rate reviews as helpful or unhelpful.
To run this application using Asp.NET Core, Postgres must be installed and running.   

The connection must be configured with a JSON file named dbsettings.json in the app root, with the following structure:   
`
{
    "DbInfo" : {
        "Name" : "Postgres",
        "ConnectionString" : [Connection string to your database]
    }
}
`  

Before attempting to run the application, run   
`dotnet ef migrations add [Migration-Name]`  
followed by  
`dotnet ef database update`  
Then run the application with   
`dotnet run --environment "Production"`  
Note that the required assets for running in development mode are not included in this repo.