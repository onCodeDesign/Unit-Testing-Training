using Microsoft.AspNetCore.Mvc;

namespace Pos.Web.UnitTests
{
    public static class MvcTestHelpers
    {
        public static TViewModel GetViewModel<TViewModel>(this IActionResult actionResult) where TViewModel : class
        {
            TViewModel model = (TViewModel) ((ViewResult)actionResult).Model;
            return model;
        }
    }
}