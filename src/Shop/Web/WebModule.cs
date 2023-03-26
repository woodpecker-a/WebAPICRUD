using Autofac;
using Web.Models;

public class WebModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<CustomerCreateModel>().AsSelf();

        base.Load(builder);
    }
}