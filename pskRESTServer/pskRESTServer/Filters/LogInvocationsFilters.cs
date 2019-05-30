using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Http.Filters;

namespace pskRESTServer.Filters
{
    public class LogInvocationsFilters : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            using (pskTravellingEntities entities = new pskTravellingEntities())
            {
                InvocationLog log = new InvocationLog()
                {
                        Controller = actionExecutedContext.ActionContext.ControllerContext.ControllerDescriptor.ControllerName,
                        
                        Action = string.Concat(actionExecutedContext.ActionContext.ActionDescriptor.ActionName, " (Logged By: LogInvocationsFilters)"),
                        Ip = HttpContext.Current.Request.UserHostAddress,
                        Timestamp = HttpContext.Current.Timestamp.ToShortDateString() + " " +
                           HttpContext.Current.Timestamp.ToShortTimeString()
                };
                try
                {
                    log.Id = entities.InvocationLogs.Max(record => record.Id) + 1;
                }
                catch
                {
                    log.Id = 0;
                }
                entities.InvocationLogs.Add(log);
                entities.SaveChanges();
            }
        }
    }
}