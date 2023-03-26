using Autofac;

namespace Web.Models
{
    public class BaseModel
    {
        protected ILifetimeScope _scope;
        public BaseModel() { }
        public virtual void ResolveDependency(ILifetimeScope scope) => _scope = scope;
    }
}
