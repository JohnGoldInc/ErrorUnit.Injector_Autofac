using Autofac;
using Castle.DynamicProxy;
using ErrorUnit.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorUnit.Injector_Autofac
{
    /// <summary>
    /// The Injector link for Autofac
    /// </summary>
    public class ErrorUnitInjector : IInjector
    {

        /// <summary>
        /// The Autofac ContainerBuilder
        /// </summary>
        private static ContainerBuilder container = null;
        /// <summary>
        /// The json serializer to use
        /// </summary>
        public static IErrorUnitCentral ErrorUnitCentral;

        /// <summary>
        /// Links the injector.
        /// </summary>
        /// <typeparam name="C"></typeparam>
        /// <param name="ioc">The ioc.</param>
        /// <param name="errorUnitCentral">The ErrorUnitCentral.Instance</param>
        /// <returns></returns>
        public C LinkInjector<C>(C ioc, IErrorUnitCentral errorUnitCentral)
        {
            container = ioc as ContainerBuilder;
            ErrorUnitInjector.ErrorUnitCentral = errorUnitCentral;
            container.Register(c => errorUnitCentral.ErrorUnitInterceptor);
            return ioc;
        }
    }
}
