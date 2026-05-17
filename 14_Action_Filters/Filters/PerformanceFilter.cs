using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace _14_Action_Filters.Filters
{
    public class PerformanceFilter:ActionFilterAttribute
    {
        private readonly ILogger<PerformanceFilter> _logger;
        private Stopwatch _stopwatch;

        public PerformanceFilter(ILogger<PerformanceFilter> logger)
        {
            _logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _stopwatch = Stopwatch.StartNew();
            _logger.LogInformation($"Performans ölçümü başladı:{context.ActionDescriptor.DisplayName}");
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            _stopwatch.Stop();
            var executionTime = _stopwatch.ElapsedMilliseconds;

            _logger.LogInformation($"Action süresi:{executionTime}ms");

            if (executionTime > 1000)
            {
                _logger.LogInformation($"Yavaş action tespit edildi:{executionTime}ms");
            }

            if(context.Controller is Controller controller)
            {
                controller.ViewBag.ExecutionTime = executionTime;
                controller.ViewBag.PerformanceMessage = executionTime > 1000 ? "Bu sayfa yavaş yüklendi, optimizasyon gerekli!" : "Sayfa hızlı yüklendi";
            }
        }
    }
}
