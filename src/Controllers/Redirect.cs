using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using UrlShortener.Models;

namespace UrlShortener.Controllers
{

    [Route("/Redirect/{*redirectAddress}")]
    [ApiController]
    public class Redirect : Controller
    {
         
         private readonly AppDbContext _appDbContext;
         public Redirect(AppDbContext app)
         {
             _appDbContext=app;
         }
        

        [HttpGet]
        public ActionResult Get(string redirectAddress)
        {
            Url url=new Url();
            if(_appDbContext.Find(url.GetType(),redirectAddress)  !=null)
            {
                 url=(Url)_appDbContext.Find(url.GetType(),redirectAddress);
                return Redirect(url.LongUrl);
            }
            else
            {
                return NotFound();
            }
        }
       
}
}