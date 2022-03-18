using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Nyoba
{
    /// <summary>
    /// Summary description for Nasabah
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Nasabah : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            string constr = ConfigurationManager.ConnectionStrings["NasabahEntities"].ConnectionString;
            return constr;
        }
        [WebMethod]
        public DataTable Get()
        {
            string constr = ConfigurationManager.ConnectionStrings["NasabahEntities"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM MstData"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            dt.TableName = "Nasabah";
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }
        [WebMethod]
        public DataTable GetByKTP(string noKTP)
        {
            string constr = ConfigurationManager.ConnectionStrings["NasabahEntities"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM MstData where NoKTP = @noKTP"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Parameters.AddWithValue("@noKTP", noKTP);
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            dt.TableName = "Nasabah";
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }

        [WebMethod]
        public void Add(string noKTP, string nama, string alamat, string tempatLahir, DateTime tanggalLahir, string noHP)
        {
            string constr = ConfigurationManager.ConnectionStrings["NasabahEntities"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT into dbo.MstData(NoKTP, Nama, Alamat, TempatLahir, TanggalLahir, NoHP) VALUES (@noKTP, @nama, @alamat, @tempatLahir, @tanggalLahir, @noHP)"))
                {
                    cmd.Parameters.AddWithValue("@noKTP", noKTP);
                    cmd.Parameters.AddWithValue("@nama", nama);
                    cmd.Parameters.AddWithValue("@alamat", alamat);
                    cmd.Parameters.AddWithValue("@tempatLahir", tempatLahir);
                    cmd.Parameters.AddWithValue("@tanggalLahir", tanggalLahir);
                    cmd.Parameters.AddWithValue("@noHp", noHP);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        [WebMethod]
        public void Edit(string noKTP, string nama, string alamat, string noHP)
        {
            string constr = ConfigurationManager.ConnectionStrings["NasabahEntities"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE dbo.MstData SET Nama = @nama, Alamat=  @alamat, NoHP = @noHP WHERE NoKTP = @noKTP"))
                {
                    cmd.Parameters.AddWithValue("@noKTP", noKTP);
                    cmd.Parameters.AddWithValue("@nama", nama);
                    cmd.Parameters.AddWithValue("@alamat", alamat);
                    cmd.Parameters.AddWithValue("@noHp", noHP);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        [WebMethod]
        public void Delete(string noKTP)
        {
            string constr = ConfigurationManager.ConnectionStrings["NasabahEntities"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE dbo.MstData WHERE NoKTP = @noKTP"))
                {
                    cmd.Parameters.AddWithValue("@noKTP", noKTP);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }
}
