using System;
using Autofac;
using System.Reflection;

namespace PokemonMVCApp
{
    public class AutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterAssemblyTypes(typeof(IPokemonConnection).GetTypeInfo().Assembly).AsImplementedInterfaces();
        }
    }
}
