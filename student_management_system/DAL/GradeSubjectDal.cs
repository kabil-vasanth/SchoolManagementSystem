using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_management_system.DAL
{
    public class GradeSubjectDal
    {
        static SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString());

        public static DataTable GetAll()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT [dbo].[grade_subject].[id],[grade_id],[dbo].[grades].[name],[subject_id],[dbo].[subjects].[subject_name] FROM [dbo].[grade_subject]INNER JOIN[dbo].[grades] ON [dbo].[grade_subject].grade_id=[dbo].[grades].id INNER JOIN [dbo].[subjects] ON [dbo].[grade_subject].subject_id=[dbo].[subjects].id";
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
                cmd.CommandText = $"SELECT [id],[grade_id],[subject_id]FROM [dbo].[grade_subject] WHERE [id]='{id}'";
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

        public static void insert(string grade_id, string subject_id)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = $"INSERT INTO [dbo].[grade_subject] ([grade_id],[subject_id])VALUES ('{grade_id}','{subject_id}' )";
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

        public static Int32 countGradeSubject(string grade_id, string subject_id)
        {
            Int32 counts = 0;
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = $"select count(*) from [dbo].[grade_subject]  WHERE [grade_id] = '{grade_id}' and [subject_id] ='{subject_id}''";
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
             var count=cmd.ExecuteScalar();
                counts =Convert.ToInt32(count);
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
            return counts;
        }

        public static void update(string grade_id, string subject_id,int id)
        {
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = $"UPDATE [dbo].[grade_subject] SET [grade_id] = '{grade_id}',[subject_id] ='{subject_id}' WHERE [id]='{id}'";
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
                cmd.CommandText = $"DELETE FROM [dbo].[grade_subject] WHERE[id] = '{id}';";
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
