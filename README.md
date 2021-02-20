# Architecture
The architecture is mainly based on the [Hexagonal Architecture](https://netflixtechblog.com/tagged/hexagonal-architecture) published by Netflix. The solution is comprised of 3 projects API, Domain and SqlDataAccess. 

The domain is at the centre of the architecture without any dependencies to the other projects and should include business logic related to the domain. The domain project implements the Mediator pattern where commands and queries are issued by the API for the CRUD operations on the products.

The entities are also defined in the domain and used for direct storage. The project includes an abstract `ProductRepository` interface that defines the contract for data source (dependency inversion), that results in data sources being swappable.

The SqlDataAccess implements the `ProductRepository` interface and persist the `Product` entity into a local SQL server using the Entity Framework Core. The project first create and seeds the database when the API project starts.

The API issue commands and queries and convert the product entity to a response DTO model.

# How to run
- Clone the repository to a suitable location.
- Download and install [.Net 5.0 SDK](https://dotnet.microsoft.com/download/dotnet/5.0).
- The solution uses an instance of LocalDB for storage therefore you will need to download and install SQL Server Express. More information [here](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb?view=sql-server-ver15#install-localdb).
- Open a terminal prompt, navigate to the root of the repo. Run `dotnet build`. 
- If everything is ok with the build, then run `dotnet run -p .\Src\Api\Api.csproj`.
- The swagger page should be available at `https://localhost:5001/swagger/index.html`.

# Docker
*Not fully functional*

To run it in Docker, navigate to the root of the repository (where the Dockerfile is) and run the following commands in a command prompt:
- `docker build -t code-test-api .`
- Once the image is build, run `docker run -it --rm --name code-test-api code-test-api`.

I chose to store the data in a `localDb` instance, so you will also need a SQL Server container and change the connection string in the `appsettings.json`in the API project to point to your SQL server container.

# Notes
The automated tests provided will pass on the first run, however additional test runs will start failing as new products created will have a different id than `4` (auto-increment). The hardcoded id of `4` will stop matching the newly created product.
