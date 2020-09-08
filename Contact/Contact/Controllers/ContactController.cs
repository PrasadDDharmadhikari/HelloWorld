using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contact.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Contact.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Contact()
        {
            List<ContactData> lst = new List<ContactData>();
            try
            {
                DataSet ds = new DataSet();
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("select * from Contact", con))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(ds);
                        }
                    }
                }
                lst = ds.Tables[0].ToList<ContactData>();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(lst);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ContactData contactdataobj)
        {
            string Query = "insert into Contact values('@FirstName','@LastName','@Email','@Phone','@Status')";
            Query = Query.Replace("@FirstName", contactdataobj.FirstName).Replace("@LastName", contactdataobj.LastName)
                .Replace("@Email", contactdataobj.Email).Replace("@Phone", Convert.ToString(contactdataobj.PhoneNumber)).Replace("@Status", contactdataobj.Status);
            try
            {
                DataSet ds = new DataSet();
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(Query, con))
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }               
            }
            catch (Exception ex)
            {
                throw ex;
            }
           return RedirectToAction("Contact");
        }

        public ActionResult Edit(int id)
        {
            List<ContactData> lst;
            ContactData contactobj;
            try
            {
                DataSet ds = new DataSet();
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("select * from Contact where Id="+id, con))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(ds);
                        }
                    }
                }
                lst = ds.Tables[0].ToList<ContactData>();
                contactobj = lst.Single(m => m.ID == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(contactobj);
        }

        [HttpPost]
        public ActionResult Edit(ContactData contactobj)
        {
            string Query = "Update Contact set FirstName='@FirstName',LastName='@LastName',Email='@Email',PhoneNumber='@Phone',Status='@Status' where ID='@ID'";
            Query = Query.Replace("@FirstName", contactobj.FirstName).Replace("@LastName", contactobj.LastName)
                .Replace("@Email", contactobj.Email).Replace("@Phone", Convert.ToString(contactobj.PhoneNumber)).Replace("@Status", contactobj.Status)
                .Replace("@ID", Convert.ToString(contactobj.ID));
            try
            {
                DataSet ds = new DataSet();
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(Query, con))
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Contact");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                DataSet ds = new DataSet();
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("delete from Contact where Id=" + id, con))
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
                return RedirectToAction("Contact");
        }
    }
}