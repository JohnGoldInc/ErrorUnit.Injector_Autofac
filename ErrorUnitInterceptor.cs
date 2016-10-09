using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorUnit.Injector_Autofac
{
    class ErrorUnitInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var stackInfo = new ErrorPrecondition(invocation);
            ErrorUnitInjector.ErrorUnitCentral.CurrentStack_Add(stackInfo);
            try
            {
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                ErrorUnitInjector.ErrorUnitCentral.ThrowErrorStack(ex);
            }
            finally
            {
                stackInfo.End = DateTime.Now;
            }
            ErrorUnitInjector.ErrorUnitCentral.CleanUp(stackInfo.End.Value);
        }
    }
}
