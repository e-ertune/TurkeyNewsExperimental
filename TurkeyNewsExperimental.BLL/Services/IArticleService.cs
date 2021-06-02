using System.Collections.Generic;
using TurkeyNewsExperimental.Model.Models;

namespace TurkeyNewsExperimental.BLL.Services
{
    public interface IArticleService
    {
        List<Article> GetArticles(string apiUri);
    }
}
