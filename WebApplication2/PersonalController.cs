using Microsoft.AspNetCore.Mvc;

namespace WebApplication2;

[ApiController]
[Route("[controller]")]
public class PersonalController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public PersonalController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet]
    public ActionResult<PersonalInfo> Get()
    {
        var personalInfo = _configuration.GetSection("PersonalInfo").Get<PersonalInfo>();
        if (personalInfo == null)
        {
            return NotFound("Personal information not found.");
        }
        return Ok(personalInfo);
    }
}

