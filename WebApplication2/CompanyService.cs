namespace WebApplication2;

public class CompanyService
{
    private readonly IConfiguration _configuration;

    public CompanyService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public CompanyInfo GetCompanyWithMostEmployees()
    {
        var companies = new List<CompanyInfo>();

        var jsonCompany = _configuration.GetSection("JsonCompany").Get<CompanyInfo>();
        AddCompanyToList(jsonCompany, companies);

        var xmlCompany = _configuration.GetSection("XmlCompany").Get<CompanyInfo>();
        AddCompanyToList(xmlCompany, companies);

        var iniCompany = _configuration.GetSection("IniCompany").Get<CompanyInfo>();
        AddCompanyToList(iniCompany, companies);

        var companyWithMostEmployees = companies.OrderByDescending(c => c.Employees).FirstOrDefault();

        return companyWithMostEmployees;
    }

    private void AddCompanyToList(CompanyInfo company, List<CompanyInfo> companies)
    {
        if (company != null)
        {
            companies.Add(company);
        }
    }
}
