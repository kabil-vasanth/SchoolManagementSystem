using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace student_management_system.DAL
{
    public class SubjectDal
    {
        static SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString());
        public static DataTable GetAll()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM subjects";
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
                cmd.CommandText = "SELECT * FROM subjects WHERE [id]='{id}'";
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

        public static void insert(string subjectName, string SubjectOredr, string SubjectIndex,string subnumber)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = $"INSERT INTO [dbo].[subjects]([subject_name] ,[subject_index],[subject_order],[subject_number])VALUES('{subjectName}','{SubjectOredr}','{SubjectIndex}','{subnumber}');";
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

        public static void update(string subjectName, string SubjectOredr, string SubjectIndex, int id)
        {
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = $"UPDATE [dbo].[subjects] SET [subject_name] = '{subjectName}',[subject_index] = '{SubjectOredr}',[subject_order] = ''{SubjectIndex},[updated_at] = '{DateTime.Now.ToString()}' WHERE [ID]='{id}'";
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
                cmd.CommandText = $"DELETE FROM [dbo].[subjects]  WHERE[id] = '{id}';";
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
