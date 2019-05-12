using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;


namespace EFCoreRestauranteer 
{
    public class ModelStateTransfer : ActionFilterAttribute 
    {
        protected const string Key = nameof(ModelStateTransfer);
    }
    public class ExportModelStateAttribute : ModelStateTransfer
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if(!context.ModelState.IsValid && (
                context.Result is RedirectResult ||
                context.Result is RedirectToActionResult ||
                context.Result is RedirectToRouteResult
            ))
            {
                var controller = context.Controller as Controller;
                if(controller != null && context.ModelState != null){
                    var modelState = ModelStateHelpers.SerialiseModelState(context.ModelState);
                    controller.TempData[Key] = modelState;
                }
            }
            base.OnActionExecuted(context);
        }
    }
    public class ImportModelStateAttribute : ModelStateTransfer
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var controller = context.Controller as Controller;
            var serializedModelState = controller?.TempData[Key] as string;

            if(serializedModelState != null)
            {
                if(context.Result is ViewResult)
                {
                    var modelState = ModelStateHelpers.DeserializeModelState(serializedModelState);                    
                    context.ModelState.Merge(modelState);
                }
                else
                {
                    controller.TempData.Remove(Key);
                }
            }
        base.OnActionExecuted(context);

        }   
    }
}