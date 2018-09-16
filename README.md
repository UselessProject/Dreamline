# Dreamlines

Dreamlines is a simple reporting microservice was written in C# and TypeScript and the client application implemented by Angular 6. In this project, I strived to use CQRS read model instead of Repository pattern.

## Data Model

The following figure demonstrates the database schema. Since I am using a Mac, I chose MySql as my main database. The model is simple and self-descriptive.

![Data Model](https://raw.githubusercontent.com/MehdiGolchin/dreamlines/master/datamodel.png)

## Cloning

To clone the source code on your computer in order to build and test it, you can use `git` command-line interface.

```bash
git clone https://github.com/MehdiGolchin/dreamlines.git
```

## Building

Before building Dreamlines, you need to have DotNet Core installed on your computer. If you haven't, don't worry, please check [.net core download page](https://www.microsoft.com/net/download).

If you are using Visual Studio 2017 or Jetbrain Rider, you can open the solution and build the project without an extra headache. However, if you are a bash guy and you like using bash, here is an example.

```bash
cd dreamlines
dotnet build
```

## Testing

I've written some Unit and Integration tests to show for this project. You can use your IDE to run them or use following `dotnet` CLI as follows.

```bash
dotnet test tests/**/*.csproj
```

## Connection String

In order to configure the database, you have to update the connection string. You can find it in the `appsettings.Development.json` file. The code snippet below shows the default value.

```json
{
  "ConnectionStrings": {
    "DreamlinesContext": "server=localhost;uid=root;pwd=12345678;database=dreamlines_dev"
  }
}
```

If you want to publish the API you should connect your app to the production database in the  `appsettings.json` file.

## Populating Data

Dreamlines will seed the database with common currencies, countries and sales units, but you need extra scripts to populate your database. You can find the dumped data inside the `db` directory in the root of the project.

## SalesUnit Summary API

Returns a sales units summary for a specific period of time. `salesUnitId` parameter allows you to filter the result by a sales unit identity.

```bash
curl -X POST \
  https://localhost:5001/api/salesunit/search \
  -H 'Cache-Control: no-cache' \
  -H 'Content-Type: application/json' \
  -d '{
	"fromDate": "2016-01-01",
	"toDate": "2016-03-01"
}'
```

## Booking Summary API

Returns a booking summary for specific sales unit.

```bash
curl -X POST \
  https://localhost:5001/api/booking/search \
  -H 'Cache-Control: no-cache' \
  -H 'Content-Type: application/json' \
  -d '{
	"fromDate": "2016-01-01",
	"toDate": "2016-03-01",
	"salesUnitId": 1
}'
```

## Pagination

All the API support pagination. So you can `skip` or `limit` your result to a specific amount of items, for an example.

```bash
curl -X POST \
  https://localhost:5001/api/salesunit/search \
  -H 'Cache-Control: no-cache' \
  -H 'Content-Type: application/json' \
  -d '{
	"fromDate": "2016-01-01",
	"toDate": "2016-03-01",
	"skip": 1,
	"limit": 2
}'
```

## Technologies

MySql (https://www.mysql.com/) . 

Asp.net Core (https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-2.1) . 
Entity Framework Core (https://github.com/aspnet/EntityFrameworkCore) . 

xUnit (https://xunit.github.io/) . 
Moq (https://github.com/moq/moq4) . 
FluentAssertion	(https://fluentassertions.com/) . 

AngularJs (https://angularjs.org/) . 
Bootstrap (https://getbootstrap.com/) . 
SCSS (https://sass-lang.com/) . 

Rider (https://www.jetbrains.com/rider/) . 
DataGrip (https://www.jetbrains.com/datagrip/) . 

## Thanks

Thanks for taking the time and for reading the document. Please don't hesitate to contact me if you have further question.
