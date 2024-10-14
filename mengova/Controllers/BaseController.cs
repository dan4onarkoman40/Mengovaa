using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using mengova.Data;

public class BaseController : Controller
{
    private readonly ApplicationDbContext _context;

    public BaseController(ApplicationDbContext context)
    {
        _context = context;
    }

    // This method will be executed for every action in derived controllers
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        var categories = _context.mengova.ToList();
        ViewBag.Categories = categories;
        base.OnActionExecuting(filterContext);
    }
}