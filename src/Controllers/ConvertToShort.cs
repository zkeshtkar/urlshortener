using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Models;

namespace UrlShortener.Controllers {

    [Route ("urls")]
    [ApiController]
    public class ConvertToShort : Controller {
        private readonly AppDbContext _appDbContext;
        public bool IsNotValid (string url) {
            Uri validatedUri;

            if (Uri.TryCreate (url, UriKind.Absolute, out validatedUri)) {
                return !(validatedUri.Scheme == Uri.UriSchemeHttp || validatedUri.Scheme == Uri.UriSchemeHttps);
            }
            return true;
        }

        public ConvertToShort (AppDbContext app) {
            _appDbContext = app;
        }

        [HttpPost]
        public ActionResult Post ([FromBody] Url url) {
            var alphabets = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var random = new Random ();

            if (IsNotValid (url.LongUrl)) {
                return BadRequest ();
            } else {
                do {
                    url.ShortUrl = "";
                    for (int i = 0; i < 8; i++) {
                        url.ShortUrl += alphabets[random.Next (42)];
                    }
                } while (_appDbContext.Find (url.GetType (), url.ShortUrl) != null);

                _appDbContext.urls.Add (url);

                _appDbContext.SaveChanges ();

                Response r = new Response (url.ShortUrl);

                return Ok (r);
            }
        }

    }

    class Response {
        public string ShortUrl { get; set; }
        public Response (string shortUrl) {
            this.ShortUrl = shortUrl;
        }
    }

}