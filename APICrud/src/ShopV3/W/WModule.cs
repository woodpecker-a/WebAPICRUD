using Autofac;
using W.Models;

public class WModule : Module
{
    protected override void Load(ContainerBuilder cb)
    {
        cb.RegisterType<RegisterModel>().AsSelf();
        cb.RegisterType<LoginModel>().AsSelf();
    }
}