using System.Web.Mvc;
using TuralıGroupDemo.Repository.Abstract;
using TuralıGroupDemo.Repository.ConcreteEF;
using Unity;
using Unity.Mvc5;

namespace TuralıGroupDemo
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            container.RegisterType<IClientDal, EfClientDal>();
            container.RegisterType<IProductDal, EfProductDal>();
            container.RegisterType<IBankDal, EfBankDal>();
            container.RegisterType<ICaseDal, EfCaseDal>();
            container.RegisterType<IOrderDal, EfOrderDal>();


            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}