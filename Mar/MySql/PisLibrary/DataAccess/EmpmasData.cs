using Dapper;
using OcrLibrary.DataAccess;
using PisLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace PisLibrary.DataAccess;

public class EmpmasData : IEmpmasData
{
    private readonly ISqlDataAccess _sql;

    public EmpmasData(ISqlDataAccess sql)
    {
        _sql = sql;
    }



    public async Task<List<EmployeeInfoModel?>> GetEmployeeList()
    {
        string cmd = @"SELECT e.EmpNumber, 
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

        var results = await _sql.FetchCmdQS<EmployeeInfoModel?, dynamic>(cmd, new { }, "MySqlConn");

        return results;


    }
}
