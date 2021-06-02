using Autofac;
using TurkeyNewsExperimental.BLL.Managers;
using TurkeyNewsExperimental.BLL.Services;

namespace TurkeyNewsExperimental.BLL.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ArticleManager>().As<IArticleService>();
        }
    }
}
