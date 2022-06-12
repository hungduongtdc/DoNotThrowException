
using Microsoft.AspNetCore.Mvc;

namespace sample.web.api.extensions;
public static class ResultExtensions
{
    public static Microsoft.AspNetCore.Mvc.IActionResult ToActionResult<T>(this Result<T> result)
    {
        return result.Match<IActionResult>(x => new OkObjectResult(x), x => new BadRequestObjectResult(x));
    }
}