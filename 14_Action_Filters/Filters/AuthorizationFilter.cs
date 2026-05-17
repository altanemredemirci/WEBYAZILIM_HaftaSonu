using _14_Action_Filters.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace _14_Action_Filters.Filters
{
    public class AuthorizationFilter:ActionFilterAttribute //Yetki Filtresi
    {
        private readonly string _requiredPermission;

        public AuthorizationFilter(string requiredPermission)
        {
            _requiredPermission = requiredPermission;    
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var blogService = context.HttpContext.RequestServices.GetService<BlogService>();

            var userName = context.HttpContext.User.Identity.Name; //Oturumu açık olan kullanıcı adı

            if (string.IsNullOrEmpty(userName))
            {
                //Oturum açık değilse kullanıcıyı Login sayfasına yönlendir.
                context.Result = new RedirectToActionResult("Login", "Account", null);
                return;
            }

            var user = blogService.GetUserByUserName(userName);

            if(user==null || !user.Permissions.Contains(_requiredPermission))
            {
                context.Result = new ViewResult
                {
                    ViewName = "UnAuthorized",
                    ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                    {
                        ["RequiredPermission"] = _requiredPermission,
                        ["UserRole"] = user?.Role ?? "Unknown",
                        ["Message"] = $"Bu işlem için '{_requiredPermission}' yetkisine ihtiyaç var. Sizin rolünüz:{user.Role ?? "Bilinmiyor"}"
                    }
                };
                return;
            }

           if(context.Controller is Controller controller)
            {
                controller.ViewBag.AutorizationInfo = $"{user.Role} rolü ile '{_requiredPermission}' yetkisi doğrulandı.";
            }

            base.OnActionExecuting(context);
        }
    }
}
