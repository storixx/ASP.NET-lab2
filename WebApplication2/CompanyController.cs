using Microsoft.AspNetCore.Mvc;

namespace WebApplication2;

[ApiController]
[Route("[controller]")]
public class CompanyController : ControllerBase
{
    private readonly CompanyService _companyService;

    public CompanyController(CompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpGet]
    public ActionResult<string> Get()
    {
        var companyName = _companyService.GetCompanyWithMostEmployees();
        return Ok(companyName);
    }
}
