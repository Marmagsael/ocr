using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMySql.DataAccess.Login
{
    public class LoginAccess
    {
        private readonly IMySqlDataAccess _mysql;

        public LoginAccess(IMySqlDataAccess mysql)
        {
            _mysql = mysql;
        }

        public record LoginInputData(
                string Schema, 
                string EmpNumber,
                string Password
        );

        public record LoginOutputData(
            string EmpNumber,
            string EmpLastNm,
            string EmpFirstNm, 
            string EmpMidNm,
            string Clnumber,
            string EmpStatCd,
            string EmpStatus,
            string PositionCd,
            string Position,
            string DateHired,
            string Sss,
            string Tin,
            string License
        );

        public async Task<LoginOutputData?> LoginEmployee(LoginInputData input)
        {
            string schema = input.Schema;
            string sql = " select Empnumber, EmpLastNm, EmpMidNm from "+ schema + ".empmas e " + 
                         " where e.Empnumber = @Empnumber and e.empstat in " +
                                 " (select code from " + schema + ".empstat)" ;

            var data = await _mysql.FetchData<LoginOutputData?, dynamic>(sql, new { Empnumber = input.EmpNumber });

            return data.FirstOrDefault();
            
        }




    }
}
