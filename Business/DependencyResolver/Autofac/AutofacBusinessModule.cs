using Autofac;
using Business.Abstract;
using Business.Concrete;
using Core.Helpers.Security;
using DataAccess.Database.Abstract;
using DataAccess.Database.Concrete.EntityFramework;
using DataAccess.Wired.Abstract;
using DataAccess.Wired.Concrete;

namespace Business.DependencyResolver.Autofac;

public class AutofacBusinessModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ExamManager>().As<IExamService>();
        builder.RegisterType<ExamDataAccess>().As<IExamDataAccess>();
        builder.RegisterType<QuestionManager>().As<IQuestionService>();
        builder.RegisterType<QuestionDataAccess>().As<IQuestionDataAccess>();
        builder.RegisterType<UserDataAccess>().As<IUserDataAccess>();
        builder.RegisterType<UserManager>().As<IUserService>();
        builder.RegisterType<AuthManager>().As<IAuthService>();
        builder.RegisterType<JwtHelper>().As<IAccessTokenHelper>();
        builder.RegisterType<WiredPostDataAccess>().As<IWiredPostDataAccess>();
        builder.RegisterType<WiredPostManager>().As<IWiredPostService>();
    }
}

