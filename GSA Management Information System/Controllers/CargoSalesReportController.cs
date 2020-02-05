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
            SqlCommand com = new SqlCommand("vwCargoSalesDetails", con);
            com.CommandType = CommandType.StoredProcedure;
            //com.Parameters.add("@CargoType", SqlDbType.VarChar, 50).Value = Prefix + "%";
            com.Parameters.AddWithValue("@CargoType", '%' + Prefix + '%');
            com.Parameters.Add(new SqlParameter("@From_Date", DBNull.Value));
            com.Parameters.Add(new SqlParameter("@To_Date", DBNull.Value));
            com.Parameters.Add(new SqlParameter("@Flight_From_Date", DBNull.Value));
            com.Parameters.Add(new SqlParameter("@Flight_To_Date", DBNull.Value));
            com.Parameters.Add(new SqlParameter("@From_Item", DBNull.Value));
            com.Parameters.Add(new SqlParameter("@To_Item", DBNull.Value));
            com.Parameters.Add(new SqlParameter("@FreighterType", DBNull.Value));
            com.Parameters.Add(new SqlParameter("@CustomerName", DBNull.Value));


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
            SqlCommand com = new SqlCommand("vwCargoSalesDetails", con);
            com.CommandType = CommandType.StoredProcedure;
            //com.Parameters.add("@CargoType", SqlDbType.VarChar, 50).Value = Prefix + "%";
            com.Parameters.AddWithValue("@CargoType", '%' + Prefix + '%');
            com.Parameters.Add(new SqlParameter("@From_Date", DBNull.Value));
            com.Parameters.Add(new SqlParameter("@To_Date", DBNull.Value));
            com.Parameters.Add(new SqlParameter("@Flight_From_Date", DBNull.Value));
            com.Parameters.Add(new SqlParameter("@Flight_To_Date", DBNull.Value));
            com.Parameters.Add(new SqlParameter("@From_Item", DBNull.Value));
            com.Parameters.Add(new SqlParameter("@To_Item", DBNull.Value));
            com.Parameters.Add(new SqlParameter("@FreighterType", DBNull.Value));
            com.Parameters.Add(new SqlParameter("@CustomerName", DBNull.Value));

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
            SqlCommand com = new SqlCommand("vwCargoSalesDetails", con);
            com.CommandType = CommandType.StoredProcedure;
            //com.Parameters.add("@CargoType", SqlDbType.VarChar, 50).Value = Prefix + "%";
            com.Parameters.AddWithValue("@FreighterType",'%'+ Prefix + '%');
            com.Parameters.Add(new SqlParameter("@From_Date", DBNull.Value));
            com.Parameters.Add(new SqlParameter("@To_Date", DBNull.Value));
            com.Parameters.Add(new SqlParameter("@Flight_From_Date", DBNull.Value));
            com.Parameters.Add(new SqlParameter("@Flight_To_Date", DBNull.Value));
            com.Parameters.Add(new SqlParameter("@From_Item", DBNull.Value));
            com.Parameters.Add(new SqlParameter("@To_Item", DBNull.Value));
            com.Parameters.Add(new SqlParameter("@CargoType", DBNull.Value));
            com.Parameters.Add(new SqlParameter("@CustomerName", DBNull.Value));


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


        public JsonResult Get_FreigherterType_To_Item(string Prefix)
        {


            string constr = ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ToString();
            con = new SqlConnection(constr);
            con.Open();
            //ApplicationDbContext db = new ApplicationDbContext();
            //SqlDataReader sdr = new SqlDataReader();
            SqlCommand com = new SqlCommand("vwCargoSalesDetails", con);
            com.CommandType = CommandType.StoredProcedure;
            //com.Parameters.add("@CargoType", SqlDbType.VarChar, 50).Value = Prefix + "%";
            com.Parameters.AddWithValue("@FreighterType", '%' + Prefix + '%');
            com.Parameters.Add(new SqlParameter("@From_Date", DBNull.Value));
            com.Parameters.Add(new SqlParameter("@To_Date", DBNull.Value));
            com.Parameters.Add(new SqlParameter("@Flight_From_Date", DBNull.Value));
            com.Parameters.Add(new SqlParameter("@Flight_To_Date", DBNull.Value));
            com.Parameters.Add(new SqlParameter("@From_Item", DBNull.Value));
            com.Parameters.Add(new SqlParameter("@To_Item", DBNull.Value));
            com.Parameters.Add(new SqlParameter("@CargoType", DBNull.Value));
            com.Parameters.Add(new SqlParameter("@CustomerName", DBNull.Value));

            //con.Open();
            SqlDataReader reader = com.ExecuteReader();
            List<string> cargotype = new List<string>();
            while (reader.Read())
            {
                cargotype.Add(reader["Freighter"].ToString());
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


        //Get Customer Name

        public JsonResult Get_Customer_Name(string Prefix)
        {


            string constr = ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ToString();
            con = new SqlConnection(constr);
            con.Open();
            //ApplicationDbContext db = new ApplicationDbContext();
            //SqlDataReader sdr = new SqlDataReader();
            SqlCommand com = new SqlCommand("vwCargoSalesDetails", con);
            com.CommandType = CommandType.StoredProcedure;
            //com.Parameters.add("@CargoType", SqlDbType.VarChar, 50).Value = Prefix + "%";
            com.Parameters.AddWithValue("@CustomerName", '%' + Prefix + '%');
            com.Parameters.Add(new SqlParameter("@From_Date", DBNull.Value));
            com.Parameters.Add(new SqlParameter("@To_Date", DBNull.Value));
            com.Parameters.Add(new SqlParameter("@Flight_From_Date", DBNull.Value));
            com.Parameters.Add(new SqlParameter("@Flight_To_Date", DBNull.Value));
            com.Parameters.Add(new SqlParameter("@From_Item", DBNull.Value));
            com.Parameters.Add(new SqlParameter("@To_Item", DBNull.Value));
            com.Parameters.Add(new SqlParameter("@CargoType", DBNull.Value));
            com.Parameters.Add(new SqlParameter("@FreighterType", DBNull.Value));

            //con.Open();
            SqlDataReader reader = com.ExecuteReader();
            List<string> cargotype = new List<string>();
            while (reader.Read())
            {
                cargotype.Add(reader["Customer"].ToString());
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

        public JsonResult GetcargotypeCodeById(string cargotype_Name)
        {
            var cargotypecode = db.CargoTypeInformations.Where(m => m.Long_Desc == cargotype_Name).FirstOrDefault();
            return Json(cargotypecode, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Export(string fromdate, string todate, string reportname, string checkdate, string cargotypefromitem, string cargotypetoitem, bool cargotypeallitemcheck, bool freightertypeallitemcheck, string freightertypefromitem, string freightertypetoitem,bool customerallitemcheck, string customer)
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
                    com.Parameters.Add(new SqlParameter("@From_Item", DBNull.Value));
                    com.Parameters.Add(new SqlParameter("@To_Item", DBNull.Value));
                }
                else
                {

                    com.Parameters.Add(new SqlParameter("@From_Item", cargotypefromitem));
                    com.Parameters.Add(new SqlParameter("@To_Item", cargotypetoitem));
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
                    com.Parameters.Add(new SqlParameter("@From_Item", DBNull.Value));
                    com.Parameters.Add(new SqlParameter("@To_Item", DBNull.Value));
                }
                else
                {

                    com.Parameters.Add(new SqlParameter("@From_Item", cargotypefromitem));
                    com.Parameters.Add(new SqlParameter("@To_Item", cargotypetoitem));
                }
            }
            else if (reportname == "DAILY REPORT-DATE-FREIGHTER-GROUP WISE(GROUP BY FREIGHTER)")
            {
                //D:\project\Software\GSA Management Information System\Reports\rptTest.rpt
                rd.Load(Path.Combine(Server.MapPath("~/Reports/Cargo"), "crpDateAndFreighterWiseCargoSalesGroupReport.rpt"));

                if (freightertypeallitemcheck == true)
                {
                    com.Parameters.Add(new SqlParameter("@From_Item", DBNull.Value));
                    com.Parameters.Add(new SqlParameter("@To_Item", DBNull.Value));
                }
                else
                {
                    com.Parameters.Add(new SqlParameter("@From_Item", freightertypefromitem));
                    com.Parameters.Add(new SqlParameter("@To_Item", freightertypetoitem));
                }
            }
            else if (reportname == "DAILY REPORT-AGENT WISE")
            {
                rd.Load(Path.Combine(Server.MapPath("~/Reports/Cargo"), "crpDateAndItemGroupWiseCustomerDetails.rpt"));
                if (customerallitemcheck == true)
                {
                    com.Parameters.Add(new SqlParameter("@CustomerName", DBNull.Value));
                    
                }
                else
                {
                    com.Parameters.Add(new SqlParameter("@CustomerName", customer));
                    com.Parameters.Add(new SqlParameter("@From_Item", DBNull.Value));
                    com.Parameters.Add(new SqlParameter("@To_Item", DBNull.Value));

                }
                //D:\project\Software\GSA Management Information System\Reports\rptTest.rpt
               
            }
            else if (reportname == "DESTINATION WISE-GROUP BY ITEM ")
            {
                //D:\project\Software\GSA Management Information System\Reports\rptTest.rpt
                rd.Load(Path.Combine(Server.MapPath("~/Reports/Cargo"), "crpDestinationWiseGroupByItem.rpt"));
            }
            else if (reportname == "DESTINATION WISE-WITHOUT GROUP ")
            {
                //D:\project\Software\GSA Management Information System\Reports\rptTest.rpt
                rd.Load(Path.Combine(Server.MapPath("~/Reports/Cargo"), "crpDestinationWiseWithoutGroupReport.rpt"));
            }

 


            //if (cargotypefromitem != "")
            //{

            //if (reportname == "DAILY REPORT-DATE-ITEM-GROUP WISE(GROUP BY ITEM) ")
            //{
            //    if (cargotypeallitemcheck == true)
            //    {
            //        //com.Parameters.Add(new SqlParameter("@Flight_From_Date", fromdate));
            //        com.Parameters.Add(new SqlParameter("@From_Item", DBNull.Value));
            //        com.Parameters.Add(new SqlParameter("@To_Item", DBNull.Value));
            //    }
            //    else
            //    {

            //        com.Parameters.Add(new SqlParameter("@From_Item", cargotypefromitem));
            //        com.Parameters.Add(new SqlParameter("@To_Item", cargotypetoitem));
            //    }
            //}

            //else if (reportname == "DAILY REPORT-DATE-FREIGHTER-GROUP WISE(GROUP BY FREIGHTER)")
            //{
            //    if (freightertypeallitemcheck == true)
            //    {
            //        com.Parameters.Add(new SqlParameter("@From_Item", DBNull.Value));
            //        com.Parameters.Add(new SqlParameter("@To_Item", DBNull.Value));
            //    }
            //    else
            //    {
            //        com.Parameters.Add(new SqlParameter("@From_Item", freightertypefromitem));
            //        com.Parameters.Add(new SqlParameter("@To_Item", freightertypetoitem));
            //    }


            //}

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
            rd.SetDataSource(dt);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            //return File("application/pdf", "ListProducts.pdf");
            return File(stream, "application/pdf");
            //return Json(new { ttt }, JsonRequestBehavior.AllowGet);
             //return Json(File(stream, "application/pdf"), JsonRequestBehavior.AllowGet);
            //return Json(new { success = true }, JsonRequestBehavior.AllowGet);

        }



    }
}