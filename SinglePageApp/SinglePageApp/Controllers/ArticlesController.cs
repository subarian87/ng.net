using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SinglePageApp.Controllers
{
    public class ArticlesController : ApiController
    {
        public IHttpActionResult GetValues()
        {
            var articles = ArticlesRepository.GetArticles();
            return Ok(articles);
        }

        [HttpGet]
        public IHttpActionResult Create(string id, string name, string content)
        {
            var exists = ArticlesRepository.Get(id) != null;


            if (exists)
                return StatusCode(HttpStatusCode.Conflict);
            else
            {
                ArticlesRepository.Add(id, name, content);
                return Ok();
            }
        }

        [HttpGet]
        public IHttpActionResult Read(string id)
        {
            var article = ArticlesRepository.Get(id);

            if (article != null)
                return Ok(article);
            else
                return NotFound();
        }

        [HttpGet]
        public IHttpActionResult Update(string id, string name, string content)
        {
            var article = ArticlesRepository.Get(id);

            if (article != null)
            {
                var success = ArticlesRepository.Update(id, name, content);

                if (success)
                    return Ok();
                else
                    return StatusCode(HttpStatusCode.InternalServerError);
            }
            else
            {
                return NotFound();
            }
            
        }

        [HttpGet]
        public IHttpActionResult Delete(string id)
        {
            var existArticle = ArticlesRepository.Get(id) != null;
            
            if (existArticle)
            {
                var succesfullyRemoved = ArticlesRepository.Delete(id);

                if (succesfullyRemoved) 
                    return Ok();
                else
                    return StatusCode(HttpStatusCode.InternalServerError);
            }
            else
                return NotFound();
        }
    }
}
