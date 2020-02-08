using System;
using Xunit;
using RA;
using Newtonsoft.Json;
using System.Text;  
using System.Text.RegularExpressions;

namespace tests
{


    public class PostMethodeTest
    {
        [Fact]
        public void Test1()
        {
            var body=new {
                LongUrl="https://stackoverflow.com/questions/1465684/cannot-convert-system-string-to-system-uri",
                ShortUrl=""

            };
            
        new RestAssured()
        .Given()
        .Name("Check that valid url will be have short url is not null")
        .Header("Content-Type", "application/json")
        .Body(body)
        .When()
        .Post("http://localhost:5000/urls")
        .Then()
        .TestStatus("test name",r =>r==200)
        .TestBody("test body",b =>((String)b.shortUrl) != null)
        .Assert("test body")
        .AssertAll();
        }
        [Fact]
        public void Test2()
        {
            var body=new {
                LongUrl="https://stackoverflow.com/questions/1465684/cannot-convert-system-string-to-system-uri",
                ShortUrl=""

            };
            
        new RestAssured()
        .Given()
        .Name("Check that valid url will be have short url with 8 length")
        .Header("Content-Type", "application/json")
        .Body(body)
        .When()
        .Post("http://localhost:5000/urls")
        .Then()
        .TestStatus("test name",r =>r==200)
        .TestBody("test body",b=>((String)b.shortUrl).Length == 8)
        .Assert("test body")
        .AssertAll();
        }
       [Fact]
        public void Test3()
        {
            string regex=@"^[A-Za-z]+$";
            Regex r = new Regex(regex); 
              var body=new {
                LongUrl="https://stackoverflow.com/questions/1465684/cannot-convert-system-string-to-system-uri",
                ShortUrl=""
            };
            
        new RestAssured()
        .Given()
        .Name("Check that valid url will be have just characters not others")
        .Header("Content-Type", "application/json")
        .Body(body)
        .When()
        .Post("http://localhost:5000/urls")
        .Then()
        .TestStatus("test name",r =>r==200)
        .TestBody("test body",b=>(r.IsMatch((String)b.shortUrl)))
        .Assert("test body")
        .AssertAll();
        }

         [Fact]
         //start invalid
        public void Test4()
        { 
              var body=new {
                LongUrl="salam",
                ShortUrl=""
            };
            
        new RestAssured()
        .Given()
        .Name("Check that invalid url will be return bad request by status 400(invalid url )")
        .Header("Content-Type", "application/json")
        .Body(body)
        .When()
        .Post("http://localhost:5000/urls")
        .Then()
        .TestStatus("test name",r =>r==400)
        .AssertAll();
        }

        [Fact]
        public void Test5()
        { 
              var body=new {
                LongUrl="http://www",
                ShortUrl=""
            };
            
        new RestAssured()
        .Given()
        .Name("Check that valid url will be return bad request by status 400(invalid url )")
        .Header("Content-Type", "application/json")
        .Body(body)
        .When()
        .Post("http://localhost:5000/urls")
        .Then()
        .TestStatus("test name",r =>r==200)
        .AssertAll();
        }

        [Fact]
        public void Test6()
        { 
              var body=new {
                LongUrl="http://google",
                ShortUrl=""
            };
            
        new RestAssured()
        .Given()
        .Name("Check that valid url will be return bad request by status 400(invalid url )")
        .Header("Content-Type", "application/json")
        .Body(body)
        .When()
        .Post("http://localhost:5000/urls")
        .Then()
        .TestStatus("test name",r =>r==200)
        .AssertAll();
        }
        //end invalid
        [Fact]
        public void Test7()
        { 
              var body=new {
                LongUrl="https://stackoverflow###########.com/questions/1465684/cannot-convert-system-string-to-system-uri",
                ShortUrl=""
            };
            
        new RestAssured()
        .Given()
        .Name("Valid url with # sign")
        .Header("Content-Type", "application/json")
        .Body(body)
        .When()
        .Post("http://localhost:5000/urls")
        .Then()
        .TestStatus("test name",r =>r==200)
        .AssertAll();
        }

        [Fact]
        public void Test8()
        {
             var body=new {
                LongUrl="https://stackoverflowثقلثخنقفناتثندبصمین.com/questions/1465684/cannot-convert-system-string-to-system-uri",
                ShortUrl=""
            };
            
        new RestAssured()
        .Given()
        .Name("Valid url with persian alphabets")
        .Header("Content-Type", "application/json")
        .Body(body)
        .When()
        .Post("http://localhost:5000/urls")
        .Then()
        .TestStatus("test name",r =>r==200)
        .AssertAll();
        }

        [Fact]
        public void Test9()
        {
              var body=new {
                LongUrl="https://stackoverflowثقلثخنقفناتثندبصمین.com/questions/1465684/cannot-convert-system-string-to-system-uri",
                ShortUrl=""
            };
            
        new RestAssured()
        .Given()
        .Name("Valid url with persian alphabets")
        .Header("Content-Type", "application/json")
        .Body(body)
        .When()
        .Post("http://localhost:5000/urls")
        .Then()
        .TestStatus("test name",r =>r==200)
        .AssertAll();
        }
}
}

