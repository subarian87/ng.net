using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ArticlesRepository
    {
        private static List<Article> Articles = new List<Article> 
        { 
            new Article {Id = "1", Name = "Article 1", Content="Bla-Bla-bla"}, 
            new Article {Id = "2", Name = "Article 2", Content="Bla2-Bla2-bla2"}, 
            new Article {Id = "3", Name = "Article 3", Content="Bla3-Bla3-bla3"}, 
        };

        public static List<Article> GetArticles()
        {
            return Articles;
        }

        public static Article Get(string id)
        {
            var article = Articles.Where(a => a.Id == id).FirstOrDefault();
            return article;
        }

        public static Article Add(string id, string name, string content)
        {
            var article = new Article();
            article.Id = id;
            article.Name = name;
            article.Content = content;

            Articles.Add(article);
            return article;
        }


        public static bool Delete(string id)
        {
            var article = Get(id);
            return Articles.Remove(article);  
        }

        public static bool Update(string id, string name, string content)
        {
            var article = Get(id);
            article.Name = name;
            article.Content = content;

            return true;
        }
    }
}
