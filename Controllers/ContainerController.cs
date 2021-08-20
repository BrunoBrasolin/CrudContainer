using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace CrudContainer.Controllers
{
  public class ContainerController : Controller
  {
    // GET: /Container/
    public IActionResult Index(string name = "Anônimo") {
      ViewData["name"] = name;
      return View();
    }

    // GET: /Container/HelloWorld/
    public string HelloWorld(string name) {
      return HtmlEncoder.Default.Encode($"Hello {name}");
    }
  }
}