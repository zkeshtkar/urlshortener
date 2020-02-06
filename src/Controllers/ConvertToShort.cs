using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using UrlShortener.Models;

namespace UrlShortener.Controllers
{

    [Route("/save")]
    [ApiController]
    public class ConvertToShort : ControllerBase
    {
         char[] alphabets  ="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
         private readonly AppDbContext _appDbContext;
         public ConvertToShort(AppDbContext app)
         {
             _appDbContext=app;
         }
        

        [HttpPost]
        public ActionResult Post([FromBody]Url url)
        {
        
             url.ShortUrl = url.LongUrl + "short";
         _appDbContext.urls.Add(url);
            _appDbContext.SaveChanges();
             return Ok(); 
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