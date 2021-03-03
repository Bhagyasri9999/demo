using demo_for_minni.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace demo_for_minni.Controllers
{
    public class DepartmentController : ApiController
    {

        public void Get()
        {
            DataTable dt = new DataTable();
            string query = @"select * from Departments";
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(dt);
            }
           
        }

        public string Post(Department dep)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"insert into Departments values('" + dep.DeptName + @"')";
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(dt);
                }
                return "Added Successfully";

            }
            catch (Exception)
            {
                return "failed to add";
            }

        }

        public string Put(Department dep)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"update Departments set DeptName= '" + dep.DeptName + @"' where DeptId = " + dep.Deptid + @" ";
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(dt);
                }
                return "updated Successfully";

            }
            catch (Exception)
            {
                return "failed to update";
            }
        }
        public string Delete(int id)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"Delete from Departments  where DeptId = " + id;
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(dt);
                }
                return "deleted";

            }
            catch (Exception)
            {
                return "failed to delete";
            }
        }
    }
}
