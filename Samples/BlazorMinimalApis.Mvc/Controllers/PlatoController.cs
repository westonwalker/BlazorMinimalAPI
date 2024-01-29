using System.ComponentModel.DataAnnotations;
using BlazorMinimalApis.Lib.Routing;
using BlazorMinimalApis.Mvc.Data;
using BlazorMinimalApis.Mvc.Views.Contacts;
using Riok.Mapperly.Abstractions;

namespace BlazorMinimalApis.Mvc.Controllers;

public class PlatoController(RambosaDbContext dbContext) : XController
{
    public IResult List(HttpContext context)
    {
        var parameters = new { Clientes = dbContext.Clientes.ToList() };
        return View<List>(parameters);
        /*var parameters = new { Contacts = Database.Contacts };
        return View<List>(parameters);*/
    }
    
    /*public IResult Create()
    {
        var model = new { Form = new CreateContactForm() };
        return View<Create>(model);
    }*/
}

public class CreatePlatoForm
{
    [Required] public string Name { get; set; }
    [Required] public int Price { get; set; }
}

[Mapper]
public partial class CreatePlatoMapper
{
    public partial CreatePlatoForm PlatoToForm(Plato Plato);
    public partial Plato FormToPlato(CreatePlatoForm Plato);
}

public class EditPlatoForm
{
    public int Id { get; set; }
    [Required] public string Name { get; set; }
    [Required] public int Price { get; set; }
}

[Mapper]
public partial class EditPlatoMapper
{
    public partial EditPlatoForm PlatoToForm(Plato Plato);
    public partial Plato FormToPlato(EditPlatoForm Plato);
}