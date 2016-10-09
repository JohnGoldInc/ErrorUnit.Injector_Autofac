using Autofac.Builder;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorUnit.Injector_Autofac
{
    public static class ErrorUnitExtension
    {
        /// <summary>
        ///     Enable ErrorUnit interface interception on the target type. Interceptors will be determined
        ///     via Intercept attributes on the class or interface, or added with InterceptedBy()
        ///     calls.
        /// </summary>
        /// <typeparam name="TLimit">Registration limit type.</typeparam>
        /// <typeparam name="TActivatorData">Activator data type.</typeparam>
        /// <typeparam name="TSingleRegistrationStyle"> Registration style.</typeparam>
        /// <param name="registration">Registration to apply interception to.</param>
        /// <returns> Registration builder allowing the registration to be configured.</returns>
        public static IRegistrationBuilder<TLimit, TActivatorData, TSingleRegistrationStyle> EnableErrorUnitInterceptor<TLimit, TActivatorData, TSingleRegistrationStyle>(this IRegistrationBuilder<TLimit, TActivatorData, TSingleRegistrationStyle> registration)
        {
            return registration.EnableInterfaceInterceptors()
                               .InterceptedBy(typeof(ErrorUnitInterceptor));
        }

        /// <summary>
        ///    Enable ErrorUnit interface interception on the target type. Interceptors will be determined
        ///    via Intercept attributes on the class or interface, or added with InterceptedBy()
        ///    calls.
        /// </summary>
        /// <typeparam name="TLimit">Registration limit type.</typeparam>
        /// <typeparam name="TActivatorData">Activator data type.</typeparam>
        /// <typeparam name="TSingleRegistrationStyle">Registration style.</typeparam>
        /// <param name="registration">Registration to apply interception to.</param>
        /// <param name="options">Proxy generation options to apply.</param>
        /// <returns>Registration builder allowing the registration to be configured.</returns>
        public static IRegistrationBuilder<TLimit, TActivatorData, TSingleRegistrationStyle> EnableInterfaceInterceptors<TLimit, TActivatorData, TSingleRegistrationStyle>(this IRegistrationBuilder<TLimit, TActivatorData, TSingleRegistrationStyle> registration, ProxyGenerationOptions options)
        {
            return registration.EnableInterfaceInterceptors(options)
                               .InterceptedBy(typeof(ErrorUnitInterceptor));
        }
    }
}
