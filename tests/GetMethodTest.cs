using System;
using Xunit;
using RA;
using Newtonsoft.Json;
using System.Text;  
using System.Text.RegularExpressions;

namespace tests
{


    public class GetMethodTest
    {

        [Fact]
        public void CheckingLengthShortUrl1()
        {
             new RestAssured()
            .Given().Name("testing the length of shor url")
            .Header("Content-Type","application.json")
            .Header("Accept-Encoding","utf-8")
            .When()
            .Get("http://localhost:5000/Redirect/AANZaa")
            .Then()
            .TestStatus("testing the length of shor url",r =>r==400)
            .AssertAll();
        }
         [Fact]
        public void CheckingIsNotRegex()
        {
             new RestAssured()
            .Given().Name("testing the regex")
            .Header("Content-Type","application.json")
            .Header("Accept-Encoding","utf-8")
            .When()
            .Get("http://localhost:5000/Redirect/AANZaas4")
            .Then()
            .TestStatus("testing the length of shor url",r =>r==400)
            .AssertAll();
        }
         [Fact]
        public void CheckingIsRegex()
        {
             new RestAssured()
            .Given().Name("testing the regex")
            .Header("Content-Type","application.json")
            .Header("Accept-Encoding","utf-8")
            .When()
            .Get("http://localhost:5000/Redirect/AANZaase")
            .Then()
            .TestStatus("testing the length of shor url",r =>r!=400)
            .AssertAll();
        }

        [Fact]
        public void CheckingNotFoundShortUrl()
        {
             new RestAssured()
            .Given().Name("testing the length of shor url")
            .Header("Content-Type","application.json")
            .Header("Accept-Encoding","utf-8")
            .When()
            .Get("http://localhost:5000/Redirect/zzzzzzzz")
            .Then()
            .TestStatus("",r =>r==404)
            .AssertAll();
        }

         [Fact]
        public void CheckingLengthShortUrl2()
        {
             new RestAssured()
            .Given().Name("testing the length of shor url")
            .Header("Content-Type","application.json")
            .Header("Accept-Encoding","utf-8")
            .When()
            .Get("http://localhost:5000/Redirect/AANZaaqwe")
            .Then()
            .TestStatus("testing the length of shor url",r =>r==400)
            .AssertAll();
        }

        [Fact]
        public void CheckingLengthShortUrl3()
        {
             new RestAssured()
            .Given().Name("testing the length of shor url")
            .Header("Content-Type","application.json")
            .Header("Accept-Encoding","utf-8")
            .When()
            .Get("http://localhost:5000/Redirect/AANZaaqw")
            .Then()
            .TestStatus("testing the length of shor url",r =>r != 400)
            .AssertAll();
        }

    }
}
