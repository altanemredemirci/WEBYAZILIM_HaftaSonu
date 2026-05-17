using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace _14_Action_Filters.Filters
{
    public class LogActionFilter:ActionFilterAttribute //İşlem Günlüğü
    {
        private readonly ILogger<LogActionFilter> _logger;

        public LogActionFilter(ILogger<LogActionFilter> logger)
        {
            _logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var actionName = context.ActionDescriptor.DisplayName;
            var contrrollerName = context.Controller.GetType().Name;
            var userAgent = context.HttpContext.Request.Headers["User-Agent"];

            _logger.LogInformation($"Action başladı:{contrrollerName}.{actionName} | User-Agent:{userAgent}");

            //ViewBag'e bilgi ekle
            if(context.Controller is Controller controller)
            {
                controller.ViewBag.ActionStartTime = DateTime.Now;
                controller.ViewBag.LogMessage = $"Bu sayfa LogActionFilter tarafından izleniyor";
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var actionName = context.ActionDescriptor.DisplayName;
            _logger.LogInformation($"Action tamamlandı:{actionName}");
        }
    }
}
