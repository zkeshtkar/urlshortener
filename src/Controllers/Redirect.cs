using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Models;

namespace UrlShortener.Controllers {

    [Route ("Redirect/{*redirectAddress}")]
    [ApiController]
    public class Redirect : Controller {

        private readonly AppDbContext _appDbContext;

        public Redirect (AppDbContext app) {
            _appDbContext = app;
        }

        [HttpGet]
        public ActionResult Get (string redirectAddress) {
            string regex = @"^[A-Za-z]+$";
            Regex r = new Regex (regex);
            Url url = new Url ();
            if (redirectAddress.Length != 8) {
                return BadRequest ();
            }

            if (!r.IsMatch (redirectAddress)) {
                return BadRequest ();
            }

            if (_appDbContext.Find (url.GetType (), redirectAddress) != null) {
                
                url = (Url) _appDbContext.Find (url.GetType (), redirectAddress);

                return Redirect (url.LongUrl);
            } else {
                return NotFound ();
            }
        }

    }
}