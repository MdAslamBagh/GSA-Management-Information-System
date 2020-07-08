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
    public class CargoSalesReportController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public SqlConnection con;

        // GET: CargoSalesReport
        public ActionResult Index()
        {
            var subMenuId = db.SubMenuInformations.Where(a => a.SubMenuId == 1101).FirstOrDefault();
            //var subMenuId = db.SubMenuInformations.Where(a => a.Access_Name == "Cargo Sales Report").FirstOrDefault();
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
            com.Parameters.AddWithValue("@CargoType",  Prefix + '%');
            


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
            com.Parameters.AddWithValue("@CargoType",  Prefix + '%');
            

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
            com.Parameters.AddWithValue("@FreighterType",  Prefix + '%');



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
       
            com.Parameters.AddWithValue("@CustomerGroup",  Prefix + '%');
 
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
            com.Parameters.AddWithValue("@CustomerGroup",  Prefix + '%');
       

            //con.Open();
            SqlDataReader reader = com.ExecuteReader();
            List<string> group = new List<string>();
            while (reader.Read())
            {
                group.Add(reader["Group_Code"].ToString());
               
               
            }

          
            return Json(group, JsonRequestBehavior.AllowGet);
          

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
            com.Parameters.AddWithValue("@Destination",  Prefix + '%');
           


            //con.Open();
            SqlDataReader reader = com.ExecuteReader();
            List<string> destination = new List<string>();
            while (reader.Read())
            {
                destination.Add(reader["Destination"].ToString());
             
            }

      
            return Json(destination, JsonRequestBehavior.AllowGet);
        

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
            com.Parameters.AddWithValue("@Destination",  Prefix + '%');


            //con.Open();
            SqlDataReader reader = com.ExecuteReader();
            List<string> destination = new List<string>();
            while (reader.Read())
            {
                destination.Add(reader["Destination"].ToString());
               
            }

   
            return Json(destination, JsonRequestBehavior.AllowGet);
          

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
            com.Parameters.AddWithValue("@CustomerName",  Prefix + '%');
         
            SqlDataReader reader = com.ExecuteReader();
            List<string> customer = new List<string>();
            while (reader.Read())
            {
                customer.Add(reader["Customer"].ToString());
            
            }

            return Json(customer, JsonRequestBehavior.AllowGet);
        

        }

        //Get Region
        public JsonResult Get_Region_Item(string Prefix)
        {


            string constr = ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ToString();
            con = new SqlConnection(constr);
            con.Open();
            //ApplicationDbContext db = new ApplicationDbContext();
            //SqlDataReader sdr = new SqlDataReader();
            SqlCommand com = new SqlCommand("spSearchRegion", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Region",  Prefix + '%');
        

            //con.Open();
            SqlDataReader reader = com.ExecuteReader();
            List<string> origin = new List<string>();
            while (reader.Read())
            {
                origin.Add(reader["Origin"].ToString());
          
            }

            return Json(origin, JsonRequestBehavior.AllowGet);
          

        }

        //Get Country
        public JsonResult Get_Country_Item(string Prefix)
        {


            string constr = ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ToString();
            con = new SqlConnection(constr);
            con.Open();
            
            SqlCommand com = new SqlCommand("spSearchCountry", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Country",  Prefix + '%');
       

            //con.Open();
            SqlDataReader reader = com.ExecuteReader();
            List<string> country = new List<string>();
            while (reader.Read())
            {
                country.Add(reader["Country"].ToString());
            
            }

            
            return Json(country, JsonRequestBehavior.AllowGet);
          
           

        }

        //Get Destination

        public JsonResult Get_Destination_Item(string Prefix)
        {


            string constr = ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ToString();
            con = new SqlConnection(constr);
            con.Open();
            //ApplicationDbContext db = new ApplicationDbContext();
            //SqlDataReader sdr = new SqlDataReader();
            SqlCommand com = new SqlCommand("spSearchDestination", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Destination",  Prefix + '%');
      

            //con.Open();
            SqlDataReader reader = com.ExecuteReader();
            List<string> destination = new List<string>();
            while (reader.Read())
            {
                destination.Add(reader["Destination"].ToString());
           
            }

           
            return Json(destination, JsonRequestBehavior.AllowGet);
           

        }

        public JsonResult GetcargotypeCodeById(string cargotype_Name)
        {
            var cargotypecode = db.CargoTypeInformations.Where(m => m.Long_Desc == cargotype_Name).FirstOrDefault();
            return Json(cargotypecode, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Export1(DateTime fromdate, DateTime todate, int reportid, string checkdate, string cargotypefromitem, string cargotypetoitem, bool cargotypeallitemcheck,  bool allgroupcheck, string groupfromitem, string grouptoitem, string clickbtn)
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
            // reportname == "DAILY REPORT-DATE-ITEM-GROUP WISE(GROUP BY ITEM) "
            //reportid = Convert.ToInt32(reportid);
            if (reportid == 7)
            {
                //D:\project\Software\GSA Management Information System\Reports\rptTest.rpt
                rd.Load(Path.Combine(Server.MapPath("~/Reports/Cargo"), "crpDateAndItemWiseCargoSalesGroupReport.rpt"));

                //var report = db.Reports.Where(p => p.ReportId == reportid).FirstOrDefault();
                // var reportname = report.ReportName;
                // rd.SetDataSource( reportname);
                //rd.SetDataSource(reportname);

                //rd.SetDataSource(db.Reports.Select(p => new
                //{
                //    ReportName = reportname,
                //    //Airway_No = p.Airway_No,

                //}).FirstOrDefault());
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

            }


         





            if (clickbtn == "btnpdf")
            {
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                //DataSet ds = new DataSet();
                //DataTable tbll = ds.Tables.Add("Items");
                //tbll.Columns.Add(“id”, Type.GetType(“System.Int32”));
                //dt.Columns.Add("From_Date", Type.GetType("System.String"));

                //dt.Columns.Add("To_Date", Type.GetType("System.String"));


                //DataRow rowss;
                //rowss = dt.NewRow();
                //rowss["From_Date"] = "From_Date";
                //rowss["To_Date"] = "To_Date";
                //dt.Rows.Add(rowss);
                //System.Data.DataColumn newColumn = new System.Data.DataColumn("Foo", typeof(System.String));
                //newColumn.DefaultValue = fromdate;
                //dt.Columns.Add(newColumn);
                //System.Data.DataColumn newColumn2 = new System.Data.DataColumn("Too", typeof(System.String));
                //newColumn2.DefaultValue = todate;
                //dt.Columns.Add(newColumn2);
                //CrystalReport cr = new CrystalReport();
                // DataColumn FromDate = dt.Columns.Add("FromDate", typeof(String));
                // DataColumn ToDate = dt.Columns.Add("ToDate", typeof(String));
                // System.Data.DataColumn newColumn = new System.Data.DataColumn("Foo", typeof(System.String));
                //FromDate.DefaultValue = fromdate;              
                //dt.Columns.Add(FromDate);
                //ToDate.DefaultValue = todate;
                //dt.Columns.Add(ToDate);
                //  dt.Columns.Add("From_Date", typeof(String));
                //dt.Columns.Add("To_Date", typeof(String));
                //DataRow workRow = workTable.NewRow();


                //dt.Columns.Add(new DataColumn[2] { new DataColumn("fromdate"), new DataColumn("todate") });
                //dt.AllowDBNull = false;
                //dt.Unique = true;

                //com.Parameters.Add(new SqlParameter("@Report_From_Date", fromdate));
                // com.Parameters.Add(new SqlParameter("@Report_To_Date", todate));
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

                //ReportDocument rept = new ReportDocument();


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


        public ActionResult Export(DateTime fromdate, DateTime todate, int reportid, string checkdate, string cargotypefromitem, string cargotypetoitem, bool cargotypeallitemcheck, bool freightertypeallitemcheck, string freightertypefromitem, string freightertypetoitem,bool customerallitemcheck, string customer, string freightpaymodefromitem, string freightpaymodetoitem, bool freightpaymodeallitemcheck,bool allgroupcheck,string groupfromitem, string grouptoitem, bool destinationallitemcheck, string destinationfromitem, string destinationtoitem, bool regionallitemcheck, bool countryallitemcheck, bool destinationitemcheck, string region, string country, string continentdestination, string clickbtn)
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
            // reportname == "DAILY REPORT-DATE-ITEM-GROUP WISE(GROUP BY ITEM) "
            //reportid = Convert.ToInt32(reportid);
             if (reportid == 7)
            {
                //D:\project\Software\GSA Management Information System\Reports\rptTest.rpt
                rd.Load(Path.Combine(Server.MapPath("~/Reports/Cargo"), "crpDateAndItemWiseCargoSalesGroupReport.rpt"));

                //var report = db.Reports.Where(p => p.ReportId == reportid).FirstOrDefault();
               // var reportname = report.ReportName;
               // rd.SetDataSource( reportname);
                //rd.SetDataSource(reportname);

                //rd.SetDataSource(db.Reports.Select(p => new
                //{
                //    ReportName = reportname,
                //    //Airway_No = p.Airway_No,

                //}).FirstOrDefault());
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

            }

          
            //reportname == "DAILY REPORT-DATE-ITEM-GROUP WISE(WITHOUT GROUP) 
            else if (reportid == 8)
            {
                //D:\project\Software\GSA Management Information System\Reports\rptTest.rpt
                rd.Load(Path.Combine(Server.MapPath("~/Reports/Cargo"), "crpDateAndItemWiseCargoSalesWithoutGroupReport.rpt"));
                //rd.SetDataSource(db.Reports.Select(p => new
                //{
                //    ReportName =p.ReportName,
                //    //Airway_No = p.Airway_No,

                //}).ToList());

                //var report = db.Reports.Where(p => p.ReportId == reportid).FirstOrDefault();
                //var reportname = report.ReportName;
                //rd.SetDataSource(reportname);
               

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

            }
            //reportname == "DAILY REPORT-DATE-FREIGHTER-GROUP WISE(GROUP BY FREIGHTER)
            else if (reportid == 9)
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
            //reportname == "DAILY REPORT-AGENT WISE"
            else if (reportid == 10)
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
            //reportname == "DESTINATION WISE-GROUP BY ITEM"
            else if (reportid == 11)
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
            //reportname == "DESTINATION WISE-WITHOUT GROUP "
            else if (reportid == 12)
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

            // reportname == "CONTINENT WISE-GROUP REPORT"
            else if (reportid == 13)
            {
                //D:\project\Software\GSA Management Information System\Reports\rptTest.rpt
                rd.Load(Path.Combine(Server.MapPath("~/Reports/Cargo"), "crpDateAndFreighterWiseCargoSalesGroupReport.rpt"));
                if (regionallitemcheck == true)
                {
                    //com.Parameters.Add(new SqlParameter("@From_Item", DBNull.Value));
                    //com.Parameters.Add(new SqlParameter("@To_Item", DBNull.Value));
                    com.Parameters.Add(new SqlParameter("@Region", "%%"));

                }
                else
                {
                    com.Parameters.Add(new SqlParameter("@Region", region));
                    //com.Parameters.Add(new SqlParameter("@From_Item", DBNull.Value));
                    //com.Parameters.Add(new SqlParameter("@To_Item", DBNull.Value));
                    //com.Parameters.Add(new SqlParameter("@From_Item", DBNull.Value));
                    //com.Parameters.Add(new SqlParameter("@To_Item", DBNull.Value));

                }
                if (countryallitemcheck == true)
                {
                    //com.Parameters.Add(new SqlParameter("@From_Item", DBNull.Value));
                    //com.Parameters.Add(new SqlParameter("@To_Item", DBNull.Value));
                    com.Parameters.Add(new SqlParameter("@Country", "%%"));

                }
                else
                {
                    com.Parameters.Add(new SqlParameter("@Country", country));
                    //com.Parameters.Add(new SqlParameter("@From_Item", DBNull.Value));
                    //com.Parameters.Add(new SqlParameter("@To_Item", DBNull.Value));
                    //com.Parameters.Add(new SqlParameter("@From_Item", DBNull.Value));
                    //com.Parameters.Add(new SqlParameter("@To_Item", DBNull.Value));

                }
                if (destinationitemcheck == true)
                {
                    //com.Parameters.Add(new SqlParameter("@From_Item", DBNull.Value));
                    //com.Parameters.Add(new SqlParameter("@To_Item", DBNull.Value));
                    com.Parameters.Add(new SqlParameter("@destination", "%%"));

                }
                else
                {
                    com.Parameters.Add(new SqlParameter("@Destination", continentdestination));
                    //com.Parameters.Add(new SqlParameter("@From_Item", DBNull.Value));
                    //com.Parameters.Add(new SqlParameter("@To_Item", DBNull.Value));
                    //com.Parameters.Add(new SqlParameter("@From_Item", DBNull.Value));
                    //com.Parameters.Add(new SqlParameter("@To_Item", DBNull.Value));

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
           // reportname == "CONTINENT WISE-WITHOUT GROUP REPORT"

            else if (reportid == 14)
            {
                //D:\project\Software\GSA Management Information System\Reports\rptTest.rpt
                rd.Load(Path.Combine(Server.MapPath("~/Reports/Cargo"), "crpDateAndContinentWiseCargoSalesWithoutGroupReport.rpt"));
                if (regionallitemcheck == true)
                {
                    //com.Parameters.Add(new SqlParameter("@From_Item", DBNull.Value));
                    //com.Parameters.Add(new SqlParameter("@To_Item", DBNull.Value));
                    com.Parameters.Add(new SqlParameter("@Region", "%%"));

                }
                else
                {
                    com.Parameters.Add(new SqlParameter("@Region", region));
                    //com.Parameters.Add(new SqlParameter("@From_Item", DBNull.Value));
                    //com.Parameters.Add(new SqlParameter("@To_Item", DBNull.Value));
                    //com.Parameters.Add(new SqlParameter("@From_Item", DBNull.Value));
                    //com.Parameters.Add(new SqlParameter("@To_Item", DBNull.Value));

                }
                if (countryallitemcheck == true)
                {
                    //com.Parameters.Add(new SqlParameter("@From_Item", DBNull.Value));
                    //com.Parameters.Add(new SqlParameter("@To_Item", DBNull.Value));
                    com.Parameters.Add(new SqlParameter("@Country", "%%"));

                }
                else
                {
                    com.Parameters.Add(new SqlParameter("@Country", country));
                    //com.Parameters.Add(new SqlParameter("@From_Item", DBNull.Value));
                    //com.Parameters.Add(new SqlParameter("@To_Item", DBNull.Value));
                    //com.Parameters.Add(new SqlParameter("@From_Item", DBNull.Value));
                    //com.Parameters.Add(new SqlParameter("@To_Item", DBNull.Value));

                }
                if (destinationitemcheck == true)
                {
                    //com.Parameters.Add(new SqlParameter("@From_Item", DBNull.Value));
                    //com.Parameters.Add(new SqlParameter("@To_Item", DBNull.Value));
                    com.Parameters.Add(new SqlParameter("@Destination", "%%"));

                }
                else
                {
                    com.Parameters.Add(new SqlParameter("@Destination", continentdestination));
                    //com.Parameters.Add(new SqlParameter("@From_Item", DBNull.Value));
                    //com.Parameters.Add(new SqlParameter("@To_Item", DBNull.Value));
                    //com.Parameters.Add(new SqlParameter("@From_Item", DBNull.Value));
                    //com.Parameters.Add(new SqlParameter("@To_Item", DBNull.Value));

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
                //DataSet ds = new DataSet();
                //DataTable tbll = ds.Tables.Add("Items");
                //tbll.Columns.Add(“id”, Type.GetType(“System.Int32”));
                //dt.Columns.Add("From_Date", Type.GetType("System.String"));

                //dt.Columns.Add("To_Date", Type.GetType("System.String"));
               

                //DataRow rowss;
                //rowss = dt.NewRow();
                //rowss["From_Date"] = "From_Date";
                //rowss["To_Date"] = "To_Date";
                //dt.Rows.Add(rowss);
                //System.Data.DataColumn newColumn = new System.Data.DataColumn("Foo", typeof(System.String));
                //newColumn.DefaultValue = fromdate;
                //dt.Columns.Add(newColumn);
                //System.Data.DataColumn newColumn2 = new System.Data.DataColumn("Too", typeof(System.String));
                //newColumn2.DefaultValue = todate;
                //dt.Columns.Add(newColumn2);
                //CrystalReport cr = new CrystalReport();
                // DataColumn FromDate = dt.Columns.Add("FromDate", typeof(String));
                // DataColumn ToDate = dt.Columns.Add("ToDate", typeof(String));
                // System.Data.DataColumn newColumn = new System.Data.DataColumn("Foo", typeof(System.String));
                //FromDate.DefaultValue = fromdate;              
                //dt.Columns.Add(FromDate);
                //ToDate.DefaultValue = todate;
                //dt.Columns.Add(ToDate);
                //  dt.Columns.Add("From_Date", typeof(String));
                //dt.Columns.Add("To_Date", typeof(String));
                //DataRow workRow = workTable.NewRow();


                //dt.Columns.Add(new DataColumn[2] { new DataColumn("fromdate"), new DataColumn("todate") });
                //dt.AllowDBNull = false;
                //dt.Unique = true;

                //com.Parameters.Add(new SqlParameter("@Report_From_Date", fromdate));
                // com.Parameters.Add(new SqlParameter("@Report_To_Date", todate));
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

                //ReportDocument rept = new ReportDocument();

                
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