using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using asp_a2.Models;
using asp_a2.Repository;

namespace asp_a2.Controllers;

public class PeopleController : Controller
{
    private readonly ILogger<PeopleController> _logger;
    private IPersonModel _iperson;

    public PeopleController(ILogger<PeopleController> logger, IPersonModel iperson)
    {
        _logger = logger;
        _iperson = iperson;
    }

    public IActionResult Index()
    {
        return View(_iperson.List());
    }

        public IActionResult Details(int id){
        var person = _iperson.List().Where(p => p.Id == id).FirstOrDefault();
        return View(person);
    }

    public IActionResult Add(){
        return View();
    }

    [HttpPost]
    public IActionResult Add(PersonModel per){
        _iperson.Create(per);
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id){
        var person = _iperson.List().Where(p => p.Id == id).FirstOrDefault();
        return View(person);
    }

    [HttpPost]
    public IActionResult Edit(PersonModel per){
        _iperson.Update(per);
        return RedirectToAction("Index");
    }
    public IActionResult Delete(int id){
        var p = _iperson.Delete(id);
        SetCookie($"DeletedAccount{p.Id}", $"{p.Id}{p.FirstName}{p.LastName}{p.Gender}{p.DateOfBirth}{p.PhoneNumber}{p.BirthPlace}{p.IsGraduated}");
        ViewBag.Message = $"Person {p.FirstName} {p.LastName} was removed from the list successfully!";
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    private void SetCookie(string key, string value){
        CookieOptions options = new CookieOptions();
        Response.Cookies.Append(key,value);
    }

}
