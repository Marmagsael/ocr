using LibraryMySql;
using LibraryMySql.Models;
using Microsoft.AspNetCore.Mvc;



namespace Ocr.Controllers.Pis; 

public class PisController : Controller
{
    private readonly IMySqlDataAccess _mysql;

    public PisController(IMySqlDataAccess mysql)
    {
        _mysql = mysql;
    }

    public async Task<IActionResult> Index()
    {
        string sql = @"SELECT e.EmpNumber, 
                             CONCAT(trim(e.EMPLASTNM), ', ', trim(e.EMPFIRSTNM), ' ', trim(e.EMPMIDNM)) AS FullName, 
                             e.EmpLastNm, 
                             e.EmpFirstNm, 
                             e.EmpMidNm, 
                             e.Suffix, 
                             e.EmpAlias, 
                             c.ClNumber, 
                             e.ClName 
                        FROM Empmas e
                        left join Client c on c.ClNumber = e.Client_";

        List<EmployeeInfoModel?> employees = await _mysql.FetchData<EmployeeInfoModel?, dynamic>(sql, new { });
        
        ViewBag.ConnString = _mysql.GetConnString();
        ViewBag.Employees = employees;

        //return View(employees);
        return View(employees);
    }

    public IActionResult Create()
    {
        return View(); 
    }

    public IActionResult Edit()
    {
        return View();
    }
}
