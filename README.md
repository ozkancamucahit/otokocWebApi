

# .Net Core Web API for Spare parts
Web API project using .NET Core.

# Prerequisites
-   [MongoDB](https://docs.mongodb.com/manual/administration/install-community)
-   [Visual Studio Code](https://code.visualstudio.com/download)
-   [C# for Visual Studio Code](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
-   [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
-   [Docker](https://www.docker.com/get-started) (To run inside container)


## Note
Make sure .NET SDK 6 is listed. Run the command in the terminal:
    
    dotnet --list-sdks

## Run with docker
Run the following command the run inside the container (**Release mode**)

    docker run -it -rm -p 8080:80 -e MongoDbSettings:Host=mongo --network=net6api webapi:v2


## Run with dotnet
Run the following commands in the terminal inside WorkingDirectory
(DEBUG mode)

    dotnet restore
    dotnet run