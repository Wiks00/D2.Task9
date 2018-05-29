using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PostSharp.Aspects;


namespace LogLib
{
    [Serializable]
    public class LogMethodInfo : OnMethodBoundaryAspect
    {
        public override void OnSuccess(MethodExecutionArgs args)
        {
            var message = FormatMessage(args);

            var returnValue = JsonConvert.SerializeObject(args.ReturnValue, new JsonSerializerSettings { Error = (sender, eventArgs) => {} }) ?? "Not serializable";

            Logger.Logger.Info(message + $" and returned {returnValue} value");
        }

        public override void OnException(MethodExecutionArgs args)
        {
            var message = FormatMessage(args);

            Logger.Logger.Error(args.Exception, message + " and ");
        }

        private static string FormatMessage(MethodExecutionArgs args)
        {
            var message = $"Method {args.Method.Name} executed with";
            var arguments  = string.Join(", ", args.Arguments.Where(item => item != null).Select(item => $"{item.GetType()}-{item}"));

            message += arguments.Any() ? $" args: {arguments}" : " no args";

            return message;
        }
    }
}
