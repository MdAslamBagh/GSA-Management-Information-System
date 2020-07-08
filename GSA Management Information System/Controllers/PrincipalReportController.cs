using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;
using GSA_Management_Information_System.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using ClosedXML.Excel;

namespace GSA_Management_Information_System.Controllers
{
    public class PrincipalReportController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public SqlConnection con;

        // GET: CargoSalesReport
        public ActionResult Index()
        {
            //   var subMenuId = db.SubMenuInformations.Where(a => a.Access_Name == "Cargo Sales Report").FirstOrDefault();
            //ViewBag.ReportId = new SelectList(db.Reports.Where(a => a.SubMenuId == subMenuId.SubMenuId), "ReportId", "ReportName");
            //ViewBag.ReportName = new SelectList(db.Reports.Where(a => a.SubMenuId == subMenuId.SubMenuId), "ReportName", "ReportName");
            var subMenuId = db.SubMenuInformations.Where(a => a.SubMenuId == 1103).FirstOrDefault();
            ViewBag.ReportList = (db.Reports.Where(a => a.SubMenuId == subMenuId.SubMenuId).ToList());
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
            com.Parameters.AddWithValue("@FreighterType", Prefix + '%');



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
            com.Parameters.AddWithValue("@FreighterType", Prefix + '%');



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

            SqlCommand com = new SqlCommand("spSearchCustomerGroup", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@CustomerGroup", Prefix + '%');

            SqlDataReader reader = com.ExecuteReader();
            List<string> group = new List<string>();
            while (reader.Read())
            {
                group.Add(reader["Group_Code"].ToString());

            }
            return Json(group, JsonRequestBehavior.AllowGet);


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
            com.Parameters.AddWithValue("@CustomerGroup", Prefix + '%');


            //con.Open();
            SqlDataReader reader = com.ExecuteReader();
            List<string> group = new List<string>();
            while (reader.Read())
            {
                group.Add(reader["Group_Code"].ToString());


            }


            return Json(group, JsonRequestBehavior.AllowGet);


        }

        //Freight Paymode

        public JsonResult Get_FreightPaymode_From_Item(string Prefix)
        {


            string constr = ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ToString();
            con = new SqlConnection(constr);
            con.Open();
            //ApplicationDbContext db = new ApplicationDbContext();
            //SqlDataReader sdr = new SqlDataReader();
            SqlCommand com = new SqlCommand("spSearchFreightPaymode", con);
            com.CommandType = CommandType.StoredProcedure;
            //com.Parameters.add("@CargoType", SqlDbType.VarChar, 50).Value = Prefix + "%";
            com.Parameters.AddWithValue("@FreightPaymode", Prefix + '%');



            //con.Open();
            SqlDataReader reader = com.ExecuteReader();
            List<string> freightpaymode = new List<string>();
            while (reader.Read())
            {
                freightpaymode.Add(reader["CargoFreightPaymode"].ToString());
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
            return Json(freightpaymode, JsonRequestBehavior.AllowGet);
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


        public JsonResult Get_FreightPaymode_To_Item(string Prefix)
        {


            string constr = ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ToString();
            con = new SqlConnection(constr);
            con.Open();
            //ApplicationDbContext db = new ApplicationDbContext();
            //SqlDataReader sdr = new SqlDataReader();
            SqlCommand com = new SqlCommand("spSearchFreightPaymode", con);
            com.CommandType = CommandType.StoredProcedure;
            //com.Parameters.add("@CargoType", SqlDbType.VarChar, 50).Value = Prefix + "%";
            com.Parameters.AddWithValue("@FreightPaymode", Prefix + '%');



            //con.Open();
            SqlDataReader reader = com.ExecuteReader();
            List<string> freightpaymode = new List<string>();
            while (reader.Read())
            {
                freightpaymode.Add(reader["CargoFreightPaymode"].ToString());
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
            return Json(freightpaymode, JsonRequestBehavior.AllowGet);
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

        public ActionResult Export(DateTime fromdate, DateTime todate, int reportid, string checkdate, string cargotypefromitem, string cargotypetoitem, bool cargotypeallitemcheck, bool freightertypeallitemcheck, string freightertypefromitem, string freightertypetoitem, bool customerallitemcheck, string customer, string freightpaymodefromitem, string freightpaymodetoitem, bool freightpaymodeallitemcheck, bool allgroupcheck, string groupfromitem, string grouptoitem, bool destinationallitemcheck, string destinationfromitem, string destinationtoitem, bool regionallitemcheck, bool countryallitemcheck, bool destinationitemcheck, string region, string country, string continentdestination, string clickbtn)
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
           // PRINCIPAL REPORT-GROUP BY MODE
            if (reportid == 15)
            {
                //D:\project\Software\GSA Management Information System\Reports\rptTest.rpt
                rd.Load(Path.Combine(Server.MapPath("~/Reports/Cargo"), "crpPrincipalReportCargoSalesGroupwise.rpt"));

                if (freightpaymodeallitemcheck == true)
                {
                    //com.Parameters.Add(new SqlParameter("@Flight_From_Date", fromdate));
                    com.Parameters.Add(new SqlParameter("@FreightPaymode_From_Item", "%%"));
                    com.Parameters.Add(new SqlParameter("@FreightPaymode_To_Item", "%%"));
                }
                else
                {

                    com.Parameters.Add(new SqlParameter("@FreightPaymode_From_Item", freightpaymodefromitem));
                    com.Parameters.Add(new SqlParameter("@FreightPaymode_To_Item", freightpaymodetoitem));
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

            }


            //PRINCIPAL REPORT-WITHOUT GROUP
            else if (reportid == 16)
            {
                //D:\project\Software\GSA Management Information System\Reports\rptTest.rpt
                rd.Load(Path.Combine(Server.MapPath("~/Reports/Cargo"), "crpPrincipalReportCargoSalesWithoutGroup.rpt"));
                if (freightpaymodeallitemcheck == true)
                {
                    //com.Parameters.Add(new SqlParameter("@Flight_From_Date", fromdate));
                    com.Parameters.Add(new SqlParameter("@FreightPaymode_From_Item", "%%"));
                    com.Parameters.Add(new SqlParameter("@FreightPaymode_To_Item", "%%"));
                }
                else
                {

                    com.Parameters.Add(new SqlParameter("@FreightPaymode_From_Item", freightpaymodefromitem));
                    com.Parameters.Add(new SqlParameter("@FreightPaymode_To_Item", freightpaymodetoitem));
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


            }



            if (clickbtn == "btnpdf")
            {
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                
                con.Open();
                da.Fill(dt);
                con.Close();


                //int i = 1;
                //for (i = 1; i <= 3; i++)
                //{
                //    rowss = tbll.NewRow();
                //    //rowss[“id”] = i;
                //    rowss["From_Date"] = "From_Date" + i;
                //    rowss["To_Date"] = "To_Date" +i;
                //    tbll.Rows.Add(rowss);
                //}

                ReportDocument rept = new ReportDocument();


                //rd.SetDataSource(dt);
                //CrystalReportViewer1.ReportSource = rept;



                //TextObject txt1 = (TextObject)rd.ReportDefinition.Sections["Section1"].ReportObjects[""];


                //TextObject txt2 = (TextObject)rd.ReportDefinition.Sections["Section1"].ReportObjects["TextObject2"];



                //ParameterFields from = new ParameterFields();
                //ParameterField f = new ParameterField();
                //f.Name = "Date_From";
                //ParameterDiscreteValue val = new ParameterDiscreteValue();
                //val.Value = Date_From;


                //if (rd.DataDefinition.ParameterFields.Count > 0)
                //{
                //    foreach (ParameterFieldDefinition crDef in rd.DataDefinition.ParameterFields)
                //    {
                //        // Check for empty report name
                //        // Sub Reports will have a value, Main Report does not
                //        // Sub Report Parameters are passed by the Main Report
                //        if (crDef.ReportName == string.Empty)
                //        {
                //            object objValue = fromdate;
                //            rd.SetParameterValue(crDef.ParameterFieldName, objValue);
                //        }
                //    }
                //}

                //var tttt = fromdate.ToString("MM/dd/yyyy");
                //rept.SetParameterValue("From_Date", fromdate.ToString("MM/dd/yyyy"));
                // rept.SetParameterValue("To_Date", todate.ToString("MM/dd/yyyy"));

                //rd.SetParameterValue("Date_From", newColumn.DefaultValue);
                //rd.SetParameterValue("@From_Date", todate);
                // rd.SetParameterValue("@From_Date", newColumn);
                //rd.SetParameterValue("@To_Date", newColumn2);

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
                //string datefrom = fromdate;
                //DateTime dateto = todate.;



                //ParameterFieldDefinitions crParameterFieldDefinitions;

                // rd.SetParameterValue("Date_From", fromdate);
                // rd.SetParameterValue("Date_To", fromdate);
                //rd.SetParameterValue("@From_Date", fromdate);
                //rd.SetParameterValue("@To_Date", todate);
                //ParameterField myParam = new ParameterField();
                //ParameterDiscreteValue myDiscreteValue = new ParameterDiscreteValue();
                //myParam.ParameterFieldName = "@From_Date";
                //myDiscreteValue.Value = fromdate;
                //myParam.CurrentValues.Add(myDiscreteValue);
                //rd.ParameterFields.Add(myParam);
                // rd.SetDataSource(myDataTable);

                //ParameterFields paramFields = new ParameterFields();
                //ParameterField paramField = new ParameterField();
                //ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();
                //paramField.Name = "@From_Date";
                //paramDiscreteValue.Value = fromdate;
                //paramField.CurrentValues.Add(paramDiscreteValue);
                //paramFields.Add(paramField);

                //paramField = new ParameterField(); // <-- This line is added
                //paramDiscreteValue = new ParameterDiscreteValue();  // <-- This line is added
                //paramField.Name = "@To_Date";
                //paramDiscreteValue.Value = todate;
                //paramField.CurrentValues.Add(paramDiscreteValue);
                //paramFields.Add(paramField);

                //rd.ParameterFields.Add(paramFields);
                //rd.ParameterFields(paramFields)
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
