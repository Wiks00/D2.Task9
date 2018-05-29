using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Newtonsoft.Json;

namespace LogLibForProxy
{
    public class LogMethodInfoInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var message = FormatMessage(invocation);

            try
            {
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                Logger.Logger.Error(ex, message + " and ");
            }

            var returnValue = JsonConvert.SerializeObject(invocation.ReturnValue, new JsonSerializerSettings {Error = (sender, eventArgs) => { }}) ?? "Not serializable";

            Logger.Logger.Info(message + $" and returned {returnValue} value");
        }

        private static string FormatMessage(IInvocation invocation)
        {
            var message = $"Method {invocation.Method.Name} executed with";
            var arguments = string.Join(", ", invocation.Arguments.Where(item => item != null).Select(item => $"{item.GetType()}-{item}"));

            message += arguments.Any() ? $" args: {arguments}" : " no args";

            return message;
        }
    }
}
