namespace SignalRApi.Modules;

using Autofac;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.BusinessLayer.Concrete;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.DataAccessLayer.UnitOfWork;

using SignalR.EntityLayer.Concrete;
using System.Reflection;
using System.Runtime.InteropServices;
using Module = Autofac.Module;
public class RepoServiceModule:Module
{
    protected override void Load(Autofac.ContainerBuilder builder)
    {


        builder.RegisterType<SignalRContext>().As<DbContext>().WithParameter("options", new DbContextOptionsBuilder<SignalRContext>().UseSqlServer("SqlConnection").Options).InstancePerLifetimeScope();

        builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericDal<>)).InstancePerLifetimeScope();
        builder.RegisterGeneric(typeof(GenericService<>)).As(typeof(IGenericService<>)).InstancePerLifetimeScope();
        builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork)).InstancePerLifetimeScope();
        var apiAssembly = Assembly.GetExecutingAssembly();
        var repoAssembly = Assembly.GetAssembly(typeof(SignalRContext));

        var serviceAssembly = Assembly.GetAssembly(typeof(BookingService));

        builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Dal")).AsImplementedInterfaces().InstancePerLifetimeScope();

        builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();
    }
}

