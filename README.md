# urlshortener

`Url Shortener` is URL shortening service and a link management platform
### Creating Database

this comments are useful for creating dataBase in your project :
```
   dotnet tool install --global dotnet-ef
   
   dotnet ef migrations add Booking.AppDbContext
   
   dotnet ef database update
```

### Run

You can write this comments in your terminal for runnig your project :

```
   dotnet run
```
 so you can see your project in this address: https://localhost:5001  or   http://localhost:5000
 
### Run Tests
  When you want to run tests,you should use this comments in your terminal :
  
  ```
   cd yourprojectname/tests
   
   dotnet test
  ```
 
### Usage

1. If you want to make short your url , you can use this comment :
```
    curl -X POST -H "Content-Type: application/json" -d '{"LongUrl": "your url","ShortUrl":""}' http://localhost:5000/urls
  
```
2. And if you want to redirec to the url by short url ,use this comment :
```
   curl -i http://localhost:5000/Your Route name/shortUrl
 
```
