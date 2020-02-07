using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using UrlShortener.Models;

namespace UrlShortener.Controllers
{

    [Route("save")]
    [ApiController]
    public class ConvertToShort : Controller
    {
         
         private readonly AppDbContext _appDbContext;
         public ConvertToShort(AppDbContext app)
         {
             _appDbContext=app;
         }
        

        [HttpPost]
        public ActionResult<string> Post([FromBody]Url url)
        {
            var alphabets  ="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var random=new Random();
           do
            {
            url.ShortUrl ="";
             for(int i=0;i<8;i++)
             {
                 url.ShortUrl+=alphabets[random.Next(42)];
             }
            }while(_appDbContext.Find(url.GetType(),url.ShortUrl)  !=null);
         _appDbContext.urls.Add(url);
        _appDbContext.SaveChanges();
             return url.ShortUrl; 
        }
        [HttpGet]
        public ActionResult Get()
        {
            
            return Ok();
        }
    }
   
    class ResponseExample
    {
        public string response{get;set;}
        public ResponseExample(string response)
        {
            this.response=response;
        }
    }
}