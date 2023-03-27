using Autofac;
using Web.Areas.Admin.Models;
using Web.Models;

public class WebModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<CustomerCreateModel>().AsSelf();
        builder.RegisterType<CustomerEditModel>().AsSelf();
        builder.RegisterType<CustomerListModel>().AsSelf();
        builder.RegisterType<LoginModel>().AsSelf();
        builder.RegisterType<RegisterModel>().AsSelf();

        base.Load(builder);
    }
}