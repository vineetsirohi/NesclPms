using Moq;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NesclPms.Domain.Abstract;
using NesclPms.Domain.Entities;

namespace NesclPms.WebUI.Infrastructure
{
    public class NinjectDependencyResolver  : IDependencyResolver {
        private IKernel kernel;
 
        public NinjectDependencyResolver(IKernel kernelParam) {
            kernel = kernelParam;
            AddBindings();
        }
 
        public object GetService(Type serviceType) {
            return kernel.TryGet(serviceType);
        }
 
        public IEnumerable<object> GetServices(Type serviceType) {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            // put bindings here
            Mock<IEntitiesRepository> mock = new Mock<IEntitiesRepository>();
            mock.Setup(m => m.VehicleBills).Returns(new List<VehicleBill>
            {
                new VehicleBill{ID=0, Name="RAB1", Date=1, Comments=""},
                new VehicleBill{ID=1, Name="RAB2", Date=2, Comments=""},
                new VehicleBill{ID=2, Name="RAB3", Date=3, Comments=""}
            });

            kernel.Bind<IEntitiesRepository>().ToConstant(mock.Object);
        }
    }
}