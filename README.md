

# .Net Core Web API for Spare parts
Web API project using .NET Core.

# Prerequisites
-   [MongoDB](https://docs.mongodb.com/manual/administration/install-community)
-   [Visual Studio Code](https://code.visualstudio.com/download)
-   [C# for Visual Studio Code](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
-   [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
-   [Docker](https://www.docker.com/get-started) (To run inside container)
-   [POSTMAN](https://www.postman.com/downloads/)



## Note
Make sure .NET SDK 6 is listed. Run the command in the terminal:
    
    dotnet --list-sdks

## Run with docker
Run the following command the run inside the container (**Release mode**)

    docker run -it --rm -p 8080:80 -e MongoDbSettings:Host=mongo --network=net6api mmucahit/otokocwebapi:v2

Interact with POSTMAN :


    SparePartObject:
    {
        "partNo": 17,
        "partName": "lol",
        "brand": "VOLVO",
        "model": "XC90",
        "modelYear":2017,
        "price": 700000,
        "imageUrl": "volvo_xc90_2017.jpeg"
    }

    Get all the parts:

    GET : http://localhost:8080/SpareParts


    POST: http://localhost:8080/SpareParts

Interact with HTTPREPL :
    
    httprepl
    connect http://localhost:8080
    ls


## Run with dotnet
Run the following commands in the terminal inside WorkingDirectory
(DEBUG mode)

    dotnet restore
    dotnet run



## References
-   [Create web APIs with ASP.NET Core
](https://docs.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-6.0)
-   [Docker images for ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/docker/building-net-docker-images?view=aspnetcore-6.0)
-   [Dockerize an ASP.NET Core application](https://docs.docker.com/samples/dotnetcore/)
