using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using GSA_Management_Information_System.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using ClosedXML.Excel;

namespace GSA_Management_Information_System.Controllers
{
    public class CargoSalesReportController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public SqlConnection con;

        // GET: CargoSalesReport
        public ActionResult Index()
        {
            var subMenuId = db.SubMenuInformations.Where(a => a.Access_Name == "Cargo Sales Report").FirstOrDefault();
            //ViewBag.ReportId = new SelectList(db.Reports.Where(a => a.SubMenuId == subMenuId.SubMenuId), "ReportId", "ReportName");
            //ViewBag.ReportName = new SelectList(db.Reports.Where(a => a.SubMenuId == subMenuId.SubMenuId), "ReportName", "ReportName");

            ViewBag.ReportList =(db.Reports.Where(a => a.SubMenuId == subMenuId.SubMenuId).ToList());
            return View();
        }

        public JsonResult GetNameCodeById(int reportcode)
        {

            
            // var data = db.StockIssueInformations.Where(a => a.SIssueId == a.SIssueId).ToList();
            //List<StockIssueInformation> Informations = db.StockIssueInformations.ToList<StockIssueInformation>();
            // ViewBag.stockdata = data;
            // return View();

            var report_code = db.Reports.Where(a => a.ReportId == reportcode).FirstOrDefault(); //Report Name Must be Database Name
            //return Json(Informations, JsonRequestBehavior.AllowGet);
            return Json(report_code, JsonRequestBehavior.AllowGet);
            //return Json(new { data = Informations }, JsonRequestBehavior.AllowGet);

        }
        public void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ToString();
            con = new SqlConnection(constr);
            //SqlDataReader sa
            

        }

        //CargoType
        public JsonResult Get_CargoType_From_Item(string Prefix)
        {


            string constr = ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ToString();
            con = new SqlConnection(constr);
            con.Open();
            //ApplicationDbContext db = new ApplicationDbContext();
            //SqlDataReader sdr = new SqlDataReader();
            SqlCommand com = new SqlCommand("spSearchCargoType", con);
            com.CommandType = CommandType.StoredProcedure;
            //com.Parameters.add("@CargoType", SqlDbType.VarChar, 50).Value = Prefix + "%";
            com.Parameters.AddWithValue("@CargoType", '%' + Prefix + '%');
            


            //con.Open();
            SqlDataReader reader = com.ExecuteReader();
            List<string> cargotype = new List<string>();
            while (reader.Read())
            {
                cargotype.Add(reader["Cargo_Type"].ToString());
                //UserDocument UserDocument = new UserDocument();
                //UserDocument.Tax_Year = reader["Tax_Year"].ToString();
                //UserDocument.DocumentName = reader["DocumentName"].ToString();
                //UserDocument.Notes = reader["filename"].ToString();
                //userdocuments.Add(UserDocument);
            }

            //con.Open();
            //com.ExecuteNonQuery();
            //List<string> customers = new List<string>();

            //using (SqlDataReader sdr = com.ExecuteReader())
            //{
            //    while (sdr.Read())
            //    {
            //        customers.Add(sdr["Long_Desc"].ToString());
            //    }
            //}
            return Json(cargotype, JsonRequestBehavior.AllowGet);
            // conn.sbConn.Close();
           // return customers;
            //SqlDataAdapter da = new SqlDataAdapter(com);
            //DataTable dt = new DataTable();
            //con.Open();
            //da.Fill(dt);
            //con.Close();


           // return View();
            // var CargoType_Name = (from c in db.CargoTypeInformations
            // where c.Long_Desc.StartsWith(Prefix)
            // select new { c.Long_Desc });
            //  return Json(CargoType_Name, JsonRequestBehavior.AllowGet);

        }


        public JsonResult Get_CargoType_To_Item(string Prefix)
        {


            string constr = ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ToString();
            con = new SqlConnection(constr);
            con.Open();
            //ApplicationDbContext db = new ApplicationDbContext();
            //SqlDataReader sdr = new SqlDataReader();
            SqlCommand com = new SqlCommand("spSearchCargoType", con);
            com.CommandType = CommandType.StoredProcedure;
            //com.Parameters.add("@CargoType", SqlDbType.VarChar, 50).Value = Prefix + "%";
            com.Parameters.AddWithValue("@CargoType", '%' + Prefix + '%');
            

            //con.Open();
            SqlDataReader reader = com.ExecuteReader();
            List<string> cargotype = new List<string>();
            while (reader.Read())
            {
                cargotype.Add(reader["Cargo_Type"].ToString());
                //UserDocument UserDocument = new UserDocument();
                //UserDocument.Tax_Year = reader["Tax_Year"].ToString();
                //UserDocument.DocumentName = reader["DocumentName"].ToString();
                //UserDocument.Notes = reader["filename"].ToString();
                //userdocuments.Add(UserDocument);
            }

            //con.Open();
            //com.ExecuteNonQuery();
            //List<string> customers = new List<string>();

            //using (SqlDataReader sdr = com.ExecuteReader())
            //{
            //    while (sdr.Read())
            //    {
            //        customers.Add(sdr["Long_Desc"].ToString());
            //    }
            //}
            return Json(cargotype, JsonRequestBehavior.AllowGet);
            // conn.sbConn.Close();
            // return customers;
            //SqlDataAdapter da = new SqlDataAdapter(com);
            //DataTable dt = new DataTable();
            //con.Open();
            //da.Fill(dt);
            //con.Close();


            // return View();
            // var CargoType_Name = (from c in db.CargoTypeInformations
            // where c.Long_Desc.StartsWith(Prefix)
            // select new { c.Long_Desc });
            //  return Json(CargoType_Name, JsonRequestBehavior.AllowGet);

        }


        //Freigher Type

        public JsonResult Get_FreighterType_From_Item(string Prefix)
        {


            string constr = ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ToString();
            con = new SqlConnection(constr);
            con.Open();
            //ApplicationDbContext db = new ApplicationDbContext();
            //SqlDataReader sdr = new SqlDataReader();
            SqlCommand com = new SqlCommand("spSearchFreighterType", con);
            com.CommandType = CommandType.StoredProcedure;
            //com.Parameters.add("@CargoType", SqlDbType.VarChar, 50).Value = Prefix + "%";
            com.Parameters.AddWithValue("@FreighterType",'%'+ Prefix + '%');
         


            //con.Open();
            SqlDataReader reader = com.ExecuteReader();
            List<string> freightertype = new List<string>();
            while (reader.Read())
            {
                freightertype.Add(reader["Freighter"].ToString());
                //UserDocument UserDocument = new UserDocument();
                //UserDocument.Tax_Year = reader["Tax_Year"].ToString();
                //UserDocument.DocumentName = reader["DocumentName"].ToString();
                //UserDocument.Notes = reader["filename"].ToString();
                //userdocuments.Add(UserDocument);
            }

            //con.Open();
            //com.ExecuteNonQuery();
            //List<string> customers = new List<string>();

            //using (SqlDataReader sdr = com.ExecuteReader())
            //{
            //    while (sdr.Read())
            //    {
            //        customers.Add(sdr["Long_Desc"].ToString());
            //    }
            //}
            return Json(freightertype, JsonRequestBehavior.AllowGet);
            // conn.sbConn.Close();
            // return customers;
            //SqlDataAdapter da = new SqlDataAdapter(com);
            //DataTable dt = new DataTable();
            //con.Open();
            //da.Fill(dt);
            //con.Close();


            // return View();
            // var CargoType_Name = (from c in db.CargoTypeInformations
            // where c.Long_Desc.StartsWith(Prefix)
            // select new { c.Long_Desc });
            //  return Json(CargoType_Name, JsonRequestBehavior.AllowGet);

        }


        public JsonResult Get_FreighterType_To_Item(string Prefix)
        {


            string constr = ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ToString();
            con = new SqlConnection(constr);
            con.Open();
            //ApplicationDbContext db = new ApplicationDbContext();
            //SqlDataReader sdr = new SqlDataReader();
            SqlCommand com = new SqlCommand("spSearchFreighterType", con);
            com.CommandType = CommandType.StoredProcedure;
            //com.Parameters.add("@CargoType", SqlDbType.VarChar, 50).Value = Prefix + "%";
            com.Parameters.AddWithValue("@FreighterType", '%' + Prefix + '%');



            //con.Open();
            SqlDataReader reader = com.ExecuteReader();
            List<string> freightertype = new List<string>();
            while (reader.Read())
            {
                freightertype.Add(reader["Freighter"].ToString());
                //UserDocument UserDocument = new UserDocument();
                //UserDocument.Tax_Year = reader["Tax_Year"].ToString();
                //UserDocument.DocumentName = reader["DocumentName"].ToString();
                //UserDocument.Notes = reader["filename"].ToString();
                //userdocuments.Add(UserDocument);
            }

            //con.Open();
            //com.ExecuteNonQuery();
            //List<string> customers = new List<string>();

            //using (SqlDataReader sdr = com.ExecuteReader())
            //{
            //    while (sdr.Read())
            //    {
            //        customers.Add(sdr["Long_Desc"].ToString());
            //    }
            //}
            return Json(freightertype, JsonRequestBehavior.AllowGet);
            // conn.sbConn.Close();
            // return customers;
            //SqlDataAdapter da = new SqlDataAdapter(com);
            //DataTable dt = new DataTable();
            //con.Open();
            //da.Fill(dt);
            //con.Close();


            // return View();
            // var CargoType_Name = (from c in db.CargoTypeInformations
            // where c.Long_Desc.StartsWith(Prefix)
            // select new { c.Long_Desc });
            //  return Json(CargoType_Name, JsonRequestBehavior.AllowGet);

        }

        //Get Customer Group

        public JsonResult Get_Group_From_Item(string Prefix)
        {


            string constr = ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ToString();
            con = new SqlConnection(constr);
            con.Open();
            //ApplicationDbContext db = new ApplicationDbContext();
            //SqlDataReader sdr = new SqlDataReader();
            SqlCommand com = new SqlCommand("spSearchCustomerGroup", con);
            com.CommandType = CommandType.StoredProcedure;
            //com.Parameters.add("@CargoType", SqlDbType.VarChar, 50).Value = Prefix + "%";
            com.Parameters.AddWithValue("@CustomerGroup", '%' + Prefix + '%');
            //com.Parameters.Add(new SqlParameter("@From_Date", DBNull.Value));
            //com.Parameters.Add(new SqlParameter("@To_Date", DBNull.Value));
            //com.Parameters.Add(new SqlParameter("@Flight_From_Date", DBNull.Value));
            //com.Parameters.Add(new SqlParameter("@Flight_To_Date", DBNull.Value));
            //com.Parameters.Add(new SqlParameter("@From_Item", DBNull.Value));
            //com.Parameters.Add(new SqlParameter("@To_Item", DBNull.Value));
            //com.Parameters.Add(new SqlParameter("@CargoType", DBNull.Value));
            //com.Parameters.Add(new SqlParameter("@CustomerName", DBNull.Value));
            //com.Parameters.Add(new SqlParameter("@Group_From_Item", DBNull.Value));
            //com.Parameters.Add(new SqlParameter("@Group_To_Item", DBNull.Value));


            //con.Open();
            SqlDataReader reader = com.ExecuteReader();
            List<string> group = new List<string>();
            while (reader.Read())
            {
                group.Add(reader["Group_Code"].ToString());
                //UserDocument UserDocument = new UserDocument();
                //UserDocument.Tax_Year = reader["Tax_Year"].ToString();
                //UserDocument.DocumentName = reader["DocumentName"].ToString();
                //UserDocument.Notes = reader["filename"].ToString();
                //userdocuments.Add(UserDocument);
            }

            //con.Open();
            //com.ExecuteNonQuery();
            //List<string> customers = new List<string>();

            //using (SqlDataReader sdr = com.ExecuteReader())
            //{
            //    while (sdr.Read())
            //    {
            //        customers.Add(sdr["Long_Desc"].ToString());
            //    }
            //}
            return Json(group, JsonRequestBehavior.AllowGet);
            // conn.sbConn.Close();
            // return customers;
            //SqlDataAdapter da = new SqlDataAdapter(com);
            //DataTable dt = new DataTable();
            //con.Open();
            //da.Fill(dt);
            //con.Close();


            // return View();
            // var CargoType_Name = (from c in db.CargoTypeInformations
            // where c.Long_Desc.StartsWith(Prefix)
            // select new { c.Long_Desc });
            //  return Json(CargoType_Name, JsonRequestBehavior.AllowGet);

        }


        public JsonResult Get_Group_To_Item(string Prefix)
        {


            string constr = ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ToString();
            con = new SqlConnection(constr);
            con.Open();
            //ApplicationDbContext db = new ApplicationDbContext();
            //SqlDataReader sdr = new SqlDataReader();
            SqlCommand com = new SqlCommand("spSearchCustomerGroup", con);
            com.CommandType = CommandType.StoredProcedure;
            //com.Parameters.add("@CargoType", SqlDbType.VarChar, 50).Value = Prefix + "%";
            com.Parameters.AddWithValue("@CustomerGroup", '%' + Prefix + '%');
       

            //con.Open();
            SqlDataReader reader = com.ExecuteReader();
            List<string> group = new List<string>();
            while (reader.Read())
            {
                group.Add(reader["Group_Code"].ToString());
                //UserDocument UserDocument = new UserDocument();
                //UserDocument.Tax_Year = reader["Tax_Year"].ToString();
                //UserDocument.DocumentName = reader["DocumentName"].ToString();
                //UserDocument.Notes = reader["filename"].ToString();
                //userdocuments.Add(UserDocument);
            }

            //con.Open();
            //com.ExecuteNonQuery();
            //List<string> customers = new List<string>();

            //using (SqlDataReader sdr = com.ExecuteReader())
            //{
            //    while (sdr.Read())
            //    {
            //        customers.Add(sdr["Long_Desc"].ToString());
            //    }
            //}
            return Json(group, JsonRequestBehavior.AllowGet);
            // conn.sbConn.Close();
            // return customers;
            //SqlDataAdapter da = new SqlDataAdapter(com);
            //DataTable dt = new DataTable();
            //con.Open();
            //da.Fill(dt);
            //con.Close();


            // return View();
            // var CargoType_Name = (from c in db.CargoTypeInformations
            // where c.Long_Desc.StartsWith(Prefix)
            // select new { c.Long_Desc });
            //  return Json(CargoType_Name, JsonRequestBehavior.AllowGet);

        }



        //Destination wise
        public JsonResult Get_Destination_From_Item(string Prefix)
        {


            string constr = ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ToString();
            con = new SqlConnection(constr);
            con.Open();
            //ApplicationDbContext db = new ApplicationDbContext();
            //SqlDataReader sdr = new SqlDataReader();
            SqlCommand com = new SqlCommand("spSearchDestination", con);
            com.CommandType = CommandType.StoredProcedure;
            //com.Parameters.add("@CargoType", SqlDbType.VarChar, 50).Value = Prefix + "%";
            com.Parameters.AddWithValue("@Destination", '%' + Prefix + '%');
            //com.Parameters.Add(new SqlParameter("@From_Date", DBNull.Value));
            //com.Parameters.Add(new SqlParameter("@To_Date", DBNull.Value));
            //com.Parameters.Add(new SqlParameter("@Flight_From_Date", DBNull.Value));
            //com.Parameters.Add(new SqlParameter("@Flight_To_Date", DBNull.Value));
            //com.Parameters.Add(new SqlParameter("@From_Item", DBNull.Value));
            //com.Parameters.Add(new SqlParameter("@To_Item", DBNull.Value));
            //com.Parameters.Add(new SqlParameter("@CargoType", DBNull.Value));
            //com.Parameters.Add(new SqlParameter("@CustomerName", DBNull.Value));
            //com.Parameters.Add(new SqlParameter("@Group_From_Item", DBNull.Value));
            //com.Parameters.Add(new SqlParameter("@Group_To_Item", DBNull.Value));


            //con.Open();
            SqlDataReader reader = com.ExecuteReader();
            List<string> destination = new List<string>();
            while (reader.Read())
            {
                destination.Add(reader["Destination"].ToString());
                //UserDocument UserDocument = new UserDocument();
                //UserDocument.Tax_Year = reader["Tax_Year"].ToString();
                //UserDocument.DocumentName = reader["DocumentName"].ToString();
                //UserDocument.Notes = reader["filename"].ToString();
                //userdocuments.Add(UserDocument);
            }

            //con.Open();
            //com.ExecuteNonQuery();
            //List<string> customers = new List<string>();

            //using (SqlDataReader sdr = com.ExecuteReader())
            //{
            //    while (sdr.Read())
            //    {
            //        customers.Add(sdr["Long_Desc"].ToString());
            //    }
            //}
            return Json(destination, JsonRequestBehavior.AllowGet);
            // conn.sbConn.Close();
            // return customers;
            //SqlDataAdapter da = new SqlDataAdapter(com);
            //DataTable dt = new DataTable();
            //con.Open();
            //da.Fill(dt);
            //con.Close();


            // return View();
            // var CargoType_Name = (from c in db.CargoTypeInformations
            // where c.Long_Desc.StartsWith(Prefix)
            // select new { c.Long_Desc });
            //  return Json(CargoType_Name, JsonRequestBehavior.AllowGet);

        }


        public JsonResult Get_Destination_To_Item(string Prefix)
        {


            string constr = ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ToString();
            con = new SqlConnection(constr);
            con.Open();
            //ApplicationDbContext db = new ApplicationDbContext();
            //SqlDataReader sdr = new SqlDataReader();
            SqlCommand com = new SqlCommand("spSearchDestination", con);
            com.CommandType = CommandType.StoredProcedure;
            //com.Parameters.add("@CargoType", SqlDbType.VarChar, 50).Value = Prefix + "%";
            com.Parameters.AddWithValue("@Destination", '%' + Prefix + '%');


            //con.Open();
            SqlDataReader reader = com.ExecuteReader();
            List<string> destination = new List<string>();
            while (reader.Read())
            {
                destination.Add(reader["Destination"].ToString());
                //UserDocument UserDocument = new UserDocument();
                //UserDocument.Tax_Year = reader["Tax_Year"].ToString();
                //UserDocument.DocumentName = reader["DocumentName"].ToString();
                //UserDocument.Notes = reader["filename"].ToString();
                //userdocuments.Add(UserDocument);
            }

            //con.Open();
            //com.ExecuteNonQuery();
            //List<string> customers = new List<string>();

            //using (SqlDataReader sdr = com.ExecuteReader())
            //{
            //    while (sdr.Read())
            //    {
            //        customers.Add(sdr["Long_Desc"].ToString());
            //    }
            //}
            return Json(destination, JsonRequestBehavior.AllowGet);
            // conn.sbConn.Close();
            // return customers;
            //SqlDataAdapter da = new SqlDataAdapter(com);
            //DataTable dt = new DataTable();
            //con.Open();
            //da.Fill(dt);
            //con.Close();


            // return View();
            // var CargoType_Name = (from c in db.CargoTypeInformations
            // where c.Long_Desc.StartsWith(Prefix)
            // select new { c.Long_Desc });
            //  return Json(CargoType_Name, JsonRequestBehavior.AllowGet);

        }


        //Get Customer Name

        public JsonResult Get_Customer_Name(string Prefix)
       {


            string constr = ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ToString();
            con = new SqlConnection(constr);
            con.Open();
            //ApplicationDbContext db = new ApplicationDbContext();
            //SqlDataReader sdr = new SqlDataReader();
            SqlCommand com = new SqlCommand("spSearchAgentCustomer", con);
            com.CommandType = CommandType.StoredProcedure;
            //com.Parameters.add("@CargoType", SqlDbType.VarChar, 50).Value = Prefix + "%";
            com.Parameters.AddWithValue("@CustomerName", '%' + Prefix + '%');
            //com.Parameters.Add(new SqlParameter("@From_Date", DBNull.Value));
            //com.Parameters.Add(new SqlParameter("@To_Date", DBNull.Value));
            //com.Parameters.Add(new SqlParameter("@Flight_From_Date", DBNull.Value));
            //com.Parameters.Add(new SqlParameter("@Flight_To_Date", DBNull.Value));
           // com.Parameters.Add(new SqlParameter("@CustomerName", DBNull.Value));
            //com.Parameters.Add(new SqlParameter("@From_Item", DBNull.Value));
            //com.Parameters.Add(new SqlParameter("@To_Item", DBNull.Value));
            //com.Parameters.Add(new SqlParameter("@CargoType", DBNull.Value));
            //com.Parameters.Add(new SqlParameter("@FreighterType", DBNull.Value));

            //con.Open();
            SqlDataReader reader = com.ExecuteReader();
            List<string> customer = new List<string>();
            while (reader.Read())
            {
                customer.Add(reader["Customer"].ToString());
                //UserDocument UserDocument = new UserDocument();
                //UserDocument.Tax_Year = reader["Tax_Year"].ToString();
                //UserDocument.DocumentName = reader["DocumentName"].ToString();
                //UserDocument.Notes = reader["filename"].ToString();
                //userdocuments.Add(UserDocument);
            }

            //con.Open();
            //com.ExecuteNonQuery();
            //List<string> customers = new List<string>()

            //using (SqlDataReader sdr = com.ExecuteReader())
            //{
            //    while (sdr.Read())
            //    {
            //        customers.Add(sdr["Long_Desc"].ToString());
            //    }
            //}
            return Json(customer, JsonRequestBehavior.AllowGet);
            // conn.sbConn.Close();
            // return customers;
            //SqlDataAdapter da = new SqlDataAdapter(com);
            //DataTable dt = new DataTable();
            //con.Open();
            //da.Fill(dt);
            //con.Close();


            // return View();
            // var CargoType_Name = (from c in db.CargoTypeInformations
            // where c.Long_Desc.StartsWith(Prefix)
            // select new { c.Long_Desc });
            //  return Json(CargoType_Name, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetcargotypeCodeById(string cargotype_Name)
        {
            var cargotypecode = db.CargoTypeInformations.Where(m => m.Long_Desc == cargotype_Name).FirstOrDefault();
            return Json(cargotypecode, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Export(string fromdate, string todate, string reportname, string checkdate, string cargotypefromitem, string cargotypetoitem, bool cargotypeallitemcheck, bool freightertypeallitemcheck, string freightertypefromitem, string freightertypetoitem,bool customerallitemcheck, string customer, string freightpaymodefromitem, string freightpaymodetoitem, bool freightpaymodeallitemcheck,string clickbtn,bool allgroupcheck,string groupfromitem,string grouptoitem,bool destinationallitemcheck,string destinationfromitem,string destinationtoitem)
        {

            ReportDocument rd = new ReportDocument();
            connection();

            SqlCommand com = new SqlCommand("vwCargoSalesDetails", con);
            com.CommandType = CommandType.StoredProcedure;



            if (checkdate == "MasterDate ")
            {

                com.Parameters.Add(new SqlParameter("@From_Date", fromdate));
                com.Parameters.Add(new SqlParameter("@To_Date", todate));
                com.Parameters.Add(new SqlParameter("@Flight_From_Date", DBNull.Value));
                com.Parameters.Add(new SqlParameter("@Flight_To_Date", DBNull.Value));
            }
            else if (checkdate == "FlightDate ")
            {

                com.Parameters.Add(new SqlParameter("@Flight_From_Date", fromdate));
                com.Parameters.Add(new SqlParameter("@Flight_To_Date", todate));
                com.Parameters.Add(new SqlParameter("@From_Date", DBNull.Value));
                com.Parameters.Add(new SqlParameter("@To_Date", DBNull.Value));
            }


            if (reportname == "DAILY REPORT-DATE-ITEM-GROUP WISE(GROUP BY ITEM) ")
            {

                rd.Load(Path.Combine(Server.MapPath("~/Reports/Cargo"), "crpDateAndItemWiseCargoSalesGroupReport.rpt"));

                if (cargotypeallitemcheck == true)
                {
                    //com.Parameters.Add(new SqlParameter("@Flight_From_Date", fromdate));
                    com.Parameters.Add(new SqlParameter("@CargoType_From_Item", "%%"));
                    com.Parameters.Add(new SqlParameter("@CargoType_To_Item", "%%"));

                }
                else
                {

                    com.Parameters.Add(new SqlParameter("@CargoType_From_Item", cargotypefromitem));
                    com.Parameters.Add(new SqlParameter("@CargoType_To_Item", cargotypetoitem));
         
                }

               
                if (allgroupcheck == true)
                {
                    com.Parameters.Add(new SqlParameter("@Group_From_Item","%%"));
                    com.Parameters.Add(new SqlParameter("@Group_To_Item", "%%"));
                
                }
                else
                {
                    com.Parameters.Add(new SqlParameter("@Group_From_Item", groupfromitem));
                    com.Parameters.Add(new SqlParameter("@Group_To_Item",   grouptoitem));
                }
                //D:\project\Software\GSA Management Information System\Reports\rptTest.rpt
               
            }
            else if (reportname == "DAILY REPORT-DATE-ITEM-GROUP WISE(WITHOUT GROUP) ")
            {
                //D:\project\Software\GSA Management Information System\Reports\rptTest.rpt
                rd.Load(Path.Combine(Server.MapPath("~/Reports/Cargo"), "crpDateAndItemWiseCargoSalesWithoutGroupReport.rpt"));

                if (cargotypeallitemcheck == true)
                {
                    //com.Parameters.Add(new SqlParameter("@Flight_From_Date", fromdate));
                    com.Parameters.Add(new SqlParameter("@CargoType_From_Item", "%%"));
                    com.Parameters.Add(new SqlParameter("@CargoType_To_Item", "%%"));
                }
                else
                {

                    com.Parameters.Add(new SqlParameter("@CargoType_From_Item", cargotypefromitem));
                    com.Parameters.Add(new SqlParameter("@CargoType_To_Item", cargotypetoitem));
                }
            }
            else if (reportname == "DAILY REPORT-DATE-FREIGHTER-GROUP WISE(GROUP BY FREIGHTER)")
            {
                //D:\project\Software\GSA Management Information System\Reports\rptTest.rpt
                rd.Load(Path.Combine(Server.MapPath("~/Reports/Cargo"), "crpDateAndFreighterWiseCargoSalesGroupReport.rpt"));

                if (freightertypeallitemcheck == true)
                {
                    com.Parameters.Add(new SqlParameter("@FreighterType_From_Item", "%%"));
                    com.Parameters.Add(new SqlParameter("@FreighterType_To_Item", "%%"));
                }
                else
                {
                    com.Parameters.Add(new SqlParameter("@FreighterType_From_Item", freightertypefromitem));
                    com.Parameters.Add(new SqlParameter("@FreighterType_To_Item", freightertypetoitem));
                }
                if (allgroupcheck == true)
                {
                    com.Parameters.Add(new SqlParameter("@Group_From_Item", "%%"));
                    com.Parameters.Add(new SqlParameter("@Group_To_Item", "%%"));

                }
                else
                {
                    com.Parameters.Add(new SqlParameter("@Group_From_Item", groupfromitem));
                    com.Parameters.Add(new SqlParameter("@Group_To_Item", grouptoitem));
                }
            }
            else if (reportname == "DAILY REPORT-AGENT WISE")
            {
                rd.Load(Path.Combine(Server.MapPath("~/Reports/Cargo"), "crpDateAndItemGroupWiseCustomerDetails.rpt"));
                if (customerallitemcheck == true)
                {
                    //com.Parameters.Add(new SqlParameter("@From_Item", DBNull.Value));
                    //com.Parameters.Add(new SqlParameter("@To_Item", DBNull.Value));
                    com.Parameters.Add(new SqlParameter("@CustomerName","%%"));
                    
                }
                else
                {
                    com.Parameters.Add(new SqlParameter("@CustomerName", customer));
                    //com.Parameters.Add(new SqlParameter("@From_Item", DBNull.Value));
                    //com.Parameters.Add(new SqlParameter("@To_Item", DBNull.Value));
                    //com.Parameters.Add(new SqlParameter("@From_Item", DBNull.Value));
                    //com.Parameters.Add(new SqlParameter("@To_Item", DBNull.Value));

                }

                if (cargotypeallitemcheck == true)
                {
                    //com.Parameters.Add(new SqlParameter("@Flight_From_Date", fromdate));
                    com.Parameters.Add(new SqlParameter("@CargoType_From_Item", "%%"));
                    com.Parameters.Add(new SqlParameter("@CargoType_To_Item", "%%"));

                }
                else
                {

                    com.Parameters.Add(new SqlParameter("@CargoType_From_Item", cargotypefromitem));
                    com.Parameters.Add(new SqlParameter("@CargoType_To_Item", cargotypetoitem));

                }


                if (allgroupcheck == true)
                {
                    com.Parameters.Add(new SqlParameter("@Group_From_Item", "%%"));
                    com.Parameters.Add(new SqlParameter("@Group_To_Item", "%%"));

                }
                else
                {
                    com.Parameters.Add(new SqlParameter("@Group_From_Item", groupfromitem));
                    com.Parameters.Add(new SqlParameter("@Group_To_Item", grouptoitem));
                }
                //D:\project\Software\GSA Management Information System\Reports\rptTest.rpt

            }
            else if (reportname == "DESTINATION WISE-GROUP BY ITEM")
            {
                //D:\project\Software\GSA Management Information System\Reports\rptTest.rpt
                rd.Load(Path.Combine(Server.MapPath("~/Reports/Cargo"), "crpDestinationWiseGroupByItem.rpt"));
                if (destinationallitemcheck == true)
                {
                    //com.Parameters.Add(new SqlParameter("@Flight_From_Date", fromdate));
                    com.Parameters.Add(new SqlParameter("@Destination_From_Item", "%%"));
                    com.Parameters.Add(new SqlParameter("@Destination_To_Item", "%%"));

                }
                else
                {

                    com.Parameters.Add(new SqlParameter("@Destination_From_Item", destinationfromitem));
                    com.Parameters.Add(new SqlParameter("@Destination_To_Item ", destinationtoitem));

                }


                if (allgroupcheck == true)
                {
                    com.Parameters.Add(new SqlParameter("@Group_From_Item", "%%"));
                    com.Parameters.Add(new SqlParameter("@Group_To_Item", "%%"));

                }
                else
                {
                    com.Parameters.Add(new SqlParameter("@Group_From_Item", groupfromitem));
                    com.Parameters.Add(new SqlParameter("@Group_To_Item", grouptoitem));
                }
            }
            else if (reportname == "DESTINATION WISE-WITHOUT GROUP ")
            {
                //D:\project\Software\GSA Management Information System\Reports\rptTest.rpt
                rd.Load(Path.Combine(Server.MapPath("~/Reports/Cargo"), "crpDestinationWiseWithoutGroupReport.rpt"));
                if (destinationallitemcheck == true)
                {
                    //com.Parameters.Add(new SqlParameter("@Flight_From_Date", fromdate));
                    com.Parameters.Add(new SqlParameter("@Destination_From_Item", "%%"));
                    com.Parameters.Add(new SqlParameter("@Destination_To_Item", "%%"));

                }
                else
                {

                    com.Parameters.Add(new SqlParameter("@Destination_From_Item", cargotypefromitem));
                    com.Parameters.Add(new SqlParameter("@Destination_To_Item ", cargotypetoitem));

                }


                if (allgroupcheck == true)
                {
                    com.Parameters.Add(new SqlParameter("@Group_From_Item", "%%"));
                    com.Parameters.Add(new SqlParameter("@Group_To_Item", "%%"));

                }
                else
                {
                    com.Parameters.Add(new SqlParameter("@Group_From_Item", groupfromitem));
                    com.Parameters.Add(new SqlParameter("@Group_To_Item", grouptoitem));
                }
            }

 




           
            if (clickbtn == "btnpdf")
            {
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                //rd.SetParameterValue("@From_Date", fromdate);
                //rd.SetParameterValue("@From_Date", todate);
                // report.SetParameterValue("@Fromdate", Fromdate);
                //report.SetParameterValue("@Todate", Todate);

                // var ttt=(db.CargoSalesInformations.Select(p => new
                //{
                //  MAWB = p.MAWB,
                //Airway_No = p.Airway_No,

                // }).ToList());
                // rd.SetDataSource ( ttt);

                //rd.SetDataSource(db.CargoSalesInformations.Select(p => new
                //{
                //    MAWB = p.MAWB,
                //    Airway_No = p.Airway_No,

                //}).ToList());

                //dt.Columns.AddRange(new DataColumn[2] { new DataColumn("MAWB"), new DataColumn("Airway_No") });

                //foreach (var cargo in dt.Rows) {
                //dt.Rows.Add(cargo);
                //}
                //using (XLWorkbook wb = new XLWorkbook())
                //{
                //    wb.Worksheets.Add(dt);
                //    using (MemoryStream streamm = new MemoryStream())
                //    {
                //        wb.SaveAs(streamm);
                //        return File(streamm.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheet.sheet", "cargoitemreport.xlsx");
                //    }
                //}

                //pdf
                rd.SetDataSource(dt);
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                //return File("application/pdf", "ListProducts.pdf");
                return File(stream, "application/pdf");
            }
            else
            {
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable("ttt");
                con.Open();
                da.Fill(dt);
                con.Close();

                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt);
                    using (MemoryStream streamm = new MemoryStream())
                    {
                        wb.SaveAs(streamm);
                        return File(streamm.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheet.sheet", "cargoitemreport.xlsx");
                    }
                }
            }

            //

            //return Json(new { ttt }, JsonRequestBehavior.AllowGet);
            //return Json(File(stream, "application/pdf"), JsonRequestBehavior.AllowGet);
            //return Json(new { success = true }, JsonRequestBehavior.AllowGet);


            //excel

            //DataTable dtt = new DataTable("cargoreport");
            //dtt.Columns.AddRange(new DataColumn[2] { new DataColumn("MAWB"), new DataColumn("Airway_No") });
            //dtt.Rows.Add("vwCargoSalesDetails");
            //using (XLWorkbook wb = new XLWorkbook())
            //{
            //    wb.Worksheets.Add(dtt);
            //    using (MemoryStream streamm = new MemoryStream())
            //    {
            //        wb.SaveAs(streamm);
            //        return File(streamm.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheet.sheet", "cargoitemreport.xlsx");
            //    }
            //}

            // 


        }



    }
}