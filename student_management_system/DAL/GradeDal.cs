using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace student_management_system.DAL
{
    public class GradeDal
    {

        static SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString());

        public static DataTable GetAll()
        {
            DataTable dt = new DataTable(); 
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM grades";
                if (conn.State != ConnectionState.Open) 
                { 
                    conn.Open();   
                }
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dt.Load(dr);
                cmd.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                conn.Close();
            }
            return dt;   
        }

        public static void GetId(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM grades WHERE [id]='{id}'";
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dt.Load(dr);
                cmd.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                conn.Close();
            }
           
        }

        public static void insert(string GradeName,string grdClr, string grdOrd, string grdGrp)
        {
            DataTable dt = new DataTable();
            
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = $"INSERT INTO [dbo].[grades]([name],[grade_group],[ord_no],[color])VALUES('{GradeName}','{grdGrp}','{grdOrd}','{grdClr}')";
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
               cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                conn.Close();
            }
            
        }

        public static void update(string GradeName, string gradegroup, string GradeOrder,string GradeColor, int id)
        {
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = $"UPDATE [dbo].[grades] SET[grd_name] = '{GradeName}',[grade_group]='{gradegroup}',[grd_no] = '{GradeOrder}',[color] = '{GradeColor}' WHERE[id] = '{id}';";
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                conn.Close();
            }
        }

        public static void delete(int id)
        {
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = $"DELETE FROM [dbo].[grades] WHERE[id] = '{id}';";
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                conn.Close();
            }
        }
    }
}
