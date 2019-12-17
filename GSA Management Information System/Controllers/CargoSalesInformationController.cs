using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GSA_Management_Information_System.Models;
using System.Data.SqlClient;
using System.Configuration;


namespace GSA_Management_Information_System.Controllers
{
    public class CargoSalesInformationController : Controller
    {
        CargoRepository cargo = new CargoRepository();
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CargoSalesInformation
        public ActionResult Index()
        {
            return View(db.CargoSalesInformations.ToList());
        }
 
        public ActionResult AddSplitter()
        {
            return View();
        }

     

        //private void Connection() {

        //public List<CargoSalesInformation> ListAll()
        //{
        //    string cs =
        //   System.Configuration.ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString; // Here is your connection string
        //    List < CargoSalesInformation> lst = new List<CargoSalesInformation>();
        //    using (SqlConnection con = new SqlConnection(cs))
        //    {
        //        con.Open();
        //        SqlCommand com = new SqlCommand("spCargoSalesDetails", con);
        //        com.CommandType = CommandType.StoredProcedure;
        //        SqlDataReader rdr = com.ExecuteReader();
        //        while (rdr.Read())
        //        {
        //            lst.Add(new CargoSalesInformation
        //            {
        //                //EmployeeID = Convert.ToInt32(rdr["EmployeeId"]),
        //                MAWB = rdr["MAWB"].ToString(),
        //                Airway_No = rdr["Airway_No"].ToString(),
        //                //Airway_No = Convert.ToInt32(rdr["Age"]),
        //                //State = rdr["State"].ToString(),
        //                //Country = rdr["Country"].ToString(),
        //            });
        //        }
        //        return lst;
        //    }
        //}
        //}

        //    public DataSet showData()
        //{
        //    string cnnString = System.Configuration.ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString; // Here is your connection string
        //    SqlConnection cnn = new SqlConnection(cnnString);
        //    SqlCommand cmd = new SqlCommand("spCargoSalesDetails", cnn);
        //     cmd.CommandType =CommandType.StoredProcedure;
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    return ds;


        //}




        public JsonResult GetData()
        {

            CargoRepository CargoRepo = new CargoRepository();
            ModelState.Clear();
            var CargoList = CargoRepo.GetAllCargo();
            


            //SqlConnection con;
            //string constr = ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ToString();
            //con = new SqlConnection(constr);
            //List<CargoViewModel> CargoList = new List<CargoViewModel>();
            //SqlCommand com = new SqlCommand("spCargoSalesDetails", con);
            //com.CommandType = CommandType.StoredProcedure;
            //SqlDataAdapter da = new SqlDataAdapter(com);
            //DataTable dt = new DataTable();
            //con.Open();
            //da.Fill(dt);
            //con.Close();

            ////Bind EmpModel generic list using LINQ 
            //CargoList = (from DataRow dr in dt.Rows

            //             select new CargoViewModel()
            //             {
            //                 CargoSalesId = Convert.ToInt32(dr["CargoSalesId"]),
            //                 MAWB = Convert.ToString(dr["MAWB"]),
            //                 Check_Digit = Convert.ToString(dr["Check_Digit"]),
            //                 Airway_No = Convert.ToString(dr["Airway_No"]),
            //                 Origin_Code = Convert.ToString(dr["Origin_Code"]),
            //                 Origin_Name = Convert.ToString(dr["OriginName"]),
            //                 // Address = Convert.ToString(dr["Address"])
            // }).ToList();


            // return CargoList;

             return Json(new { data = CargoList }, JsonRequestBehavior.AllowGet);

            //CargoRepository CargoRepo = new CargoRepository();
            //ModelState.Clear();
            //var cargoData = CargoRepo.GetAllCargo();
            // return View(EmpRepo.GetAllEmployees());
            //      string cnnString = System.Configuration.ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString; // Here is your connection string
            //    SqlConnection cnn = new SqlConnection(cnnString);
            //    SqlCommand cmd = new SqlCommand("spCargoSalesDetails", cnn);
            //     cmd.CommandType =CommandType.StoredProcedure;
            //    SqlDataAdapter da = new SqlDataAdapter(cmd);
            //    DataSet ds = new DataSet();
            //    da.Fill(ds);
            //return ds;
            // DataSet ds=
            //using (var db=new ApplicationDbContext()) { 
            // //// var cargolist = db.CargoSalesInformations.SqlQuery("select * from CargoSalesInformations").ToList();

            // var cargolist = db.CargoSalesInformations.ToList();
            //      var results = db.CargoSalesInformations.SqlQuery("exec spCargoSalesDetails").ToList();
            //      var ss=db.car

            //      //     var db = new ss();
            //      //     var data = db.spCargoSalesDetails();
            // return Json(new { data = cargolist }, JsonRequestBehavior.AllowGet);


            //CargoSalesInformation cargo = new CargoSalesInformation();
            // return Json(cargo.ListAll(), JsonRequestBehavior.AllowGet);
        }
    


            //    List<CargoSalesInformation> cargolist = new List<CargoSalesInformation>();

            //       string cnnString =
            //System.Configuration.ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString; // Here is your connection string
            //       SqlConnection cnn = new SqlConnection(cnnString);
            //       SqlCommand cmd = new SqlCommand();
            //       cmd.Connection = cnn;
            //       cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //       cmd.CommandText = "spCargoSalesDetails"; // Here is the name of your stored procedure
            //       cnn.Open();

            //List<CargoSalesInformation> cargodata = db.CargoSalesInformations.ToList<CargoSalesInformation>();


            //var cargolist = from cargosales in db.CargoSalesInformations join origin in db.OriginInformations on cargosales.Origin_Code equals origin.Origin_Code
            //                                                             join freighter in db.FreighterInformations on cargosales.Freighter_Code equals freighter.Freighter_Code
            //                                                          select new {
            //                                                          cargosales.MAWB,
            //                                                          cargosales.Airway_No,
            //                                                          origin.Long_Desc,
            //                                                          Frieghter_Name=freighter.Long_Desc};



        
        // GET: CargoSalesInformation/Create
        public ActionResult Create()

        {
           // String today = DateTime.Now.ToString("MM/dd/yyyy");
            String today = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            ViewBag.Entry_Date = today;

            String time = DateTime.Now.ToString("MM/dd/yyyy");
            ViewBag.Flight_Date = time;
            List<CargoSalesInformation> Informations = db.CargoSalesInformations.OrderByDescending(a => a.SalesSlno).ToList<CargoSalesInformation>();

            try
            {
                CargoSalesInformation information = new CargoSalesInformation();

                information = Informations.FirstOrDefault();
                if (information == null)
                {
                    CargoSalesInformation objinformations = new CargoSalesInformation();
                    int s = objinformations.SalesSlno + 1;
                    //ViewBag.ConsignorCode = information.Consignor_Code + 1;
                    ViewBag.SalesSlno = s.ToString();
                }
                else
                {
                    int code = information.SalesSlno + 1;
                    ViewBag.SalesSlno = code.ToString();//.PadLeft(4, '0');
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            //freighter
            List<FreighterInformation> freighterInformations = db.FreighterInformations.Where(a => a.Default_Code == true).ToList<FreighterInformation>();
            FreighterInformation informations = new FreighterInformation();
            informations = freighterInformations.FirstOrDefault();
            string f_Name = informations.Long_Desc;
            string f_Code = informations.Freighter_Code.ToString();
            ViewBag.Freighter_Name = f_Name;
            ViewBag.Freighter_Code = f_Code;

            //orgin
            List<OriginInformation> originInformations = db.OriginInformations.Where(a => a.Default_Code == true).ToList<OriginInformation>();
            OriginInformation orign = new OriginInformation();
            orign = originInformations.FirstOrDefault();
            string o_Name = orign.Long_Desc;
            string o_Code = orign.Origin_Code;
            ViewBag.Origin_Name = o_Name;
            ViewBag.Origin_Code = o_Code;

            //destination
            List<DestinationInformation> destinationInformations = db.DestinationInformations.Where(a => a.Default_Code == true).ToList<DestinationInformation>();
            DestinationInformation destination = new DestinationInformation();
            destination = destinationInformations.FirstOrDefault();
            string d_Name = destination.Long_Desc;
            string d_Code = destination.Dest_Code;
            ViewBag.Destination_Name = d_Name;
            ViewBag.Destination_Code = d_Code;

            //Continent
            List<ContinentInformation> continentInformations = db.ContinentInformations.Where(a => a.Default_Code == true).ToList<ContinentInformation>();
            ContinentInformation continent = new ContinentInformation();
            continent = continentInformations.FirstOrDefault();
            string ci_Name = continent.Long_Desc;
            string ci_Code = continent.Continent_Code.ToString();
            ViewBag.Continent_Name = ci_Name;
            ViewBag.Continent_Code = ci_Code;

            //Payment mode
            List<PaymentModeInformation> paymentmodeInformations = db.PaymentModeInformations.Where(a => a.Default_Code == true).ToList<PaymentModeInformation>();
            PaymentModeInformation paymentmode = new PaymentModeInformation();
            paymentmode = paymentmodeInformations.FirstOrDefault();
            string pm_Name = paymentmode.Long_Desc;
            string pm_mode = paymentmode.Payment_Mode;
            ViewBag.Payment_Name = pm_Name;
            ViewBag.Payment_Mode = pm_mode;

            //Cargo Freight paymode
            List<CargoFreightPaymodeInformation> cfInformations = db.CargoFreightPaymodeInformations.Where(a => a.Default_Code == true).ToList<CargoFreightPaymodeInformation>();
            CargoFreightPaymodeInformation cfpaymode = new CargoFreightPaymodeInformation();
            cfpaymode = cfInformations.FirstOrDefault();
            string cfp_Name = cfpaymode.Long_Desc;
            string cfp_Code = cfpaymode.CFPaymode_Code.ToString();
            ViewBag.Cargofreight_Name = cfp_Name;
            ViewBag.Cargofreight_Code = cfp_Code;

            //Sector
            List<RouteInformation> routeInformations = db.RouteInformations.Where(a => a.Default_Code == true).ToList<RouteInformation>();
            RouteInformation route = new RouteInformation();
            route = routeInformations.FirstOrDefault();
            string r_Name = route.Long_Desc;
            string r_Code = route.Route_Code;
            ViewBag.Route_Name = r_Name;
            ViewBag.Route_Code = r_Code;

            //customer
            List<CustomerInformation> customerInformations = db.CustomerInformations.Where(a => a.Default_Code == true).ToList<CustomerInformation>();
            CustomerInformation customer = new CustomerInformation();
            customer = customerInformations.FirstOrDefault();
            string c_Name = customer.Customer_Name;
            string c_Code = customer.Customer_Code;
            ViewBag.Customer_Name = c_Name;
            ViewBag.Customer_Code = c_Code;

            //cargotype
            List<CargoTypeInformation> cargotypeInformations = db.CargoTypeInformations.Where(a => a.Default_Code == true).ToList<CargoTypeInformation>();
            CargoTypeInformation cargotype = new CargoTypeInformation();
            cargotype = cargotypeInformations.FirstOrDefault();
            string ct_Name = cargotype.Long_Desc;
            string ct_Code = cargotype.Cargo_Code;
            ViewBag.Cargo_Name = ct_Name;
            ViewBag.Cargo_Code = ct_Code;

            //Consoignee

            List<ConsigneeInformation> consigneeInformations = db.ConsigneeInformations.Where(a => a.Default_Code == true).ToList<ConsigneeInformation>();
            ConsigneeInformation consignee = new ConsigneeInformation();
            consignee = consigneeInformations.FirstOrDefault();
            string cn_Name = consignee.Consignee_Name;
            string cn_Code = consignee.Consignee_Code;
            string cn_Address = consignee.Consignee_Address;
            ViewBag.Consignee_Name = cn_Name;
            ViewBag.Consignee_Code = cn_Code;
            ViewBag.Consignee_Address = cn_Address;


            //Consignor
            List<ConsignorInformation> consignorInformations = db.ConsignorInformations.Where(a => a.Default_Code == true).ToList<ConsignorInformation>();
            ConsignorInformation consignor = new ConsignorInformation();
            consignor = consignorInformations.FirstOrDefault();
            string con_Name = consignor.Consignor_Name;
            string con_Code = consignor.Consignor_Code;
            string con_Address = consignor.Consignor_Address;
            ViewBag.Consignor_Name = con_Name;
            ViewBag.Consignor_Code = con_Code;
            ViewBag.Consignor_Address = con_Address;

            List<UplimentTypeInformation> uplimentInformations = db.UplimentTypeInformations.Where(a => a.Default_Code == true).ToList<UplimentTypeInformation>();
            UplimentTypeInformation upliment = new UplimentTypeInformation();
            upliment = uplimentInformations.FirstOrDefault();
            string U_Name = upliment.Long_Desc;
            string U_Code = upliment.UType_Code.ToString();
            ViewBag.Upliment_Name = U_Name;
            ViewBag.Upliment_Code = U_Code;

            //Currency
            List<CurrencyInformation> currencyInformations = db.CurrencyInformations.Where(a => a.Default_Code == true).ToList<CurrencyInformation>();
            CurrencyInformation currency = new CurrencyInformation();
            currency = currencyInformations.FirstOrDefault();
            string currencyname = currency.Currency_Code.ToString();
            ViewBag.Currency = currencyname;

            //  exchange rate
            List<ExchangeInformation> exchangeInformations = db.ExchangeInformations.Where(a => a.Default_Code == true).ToList<ExchangeInformation>();
            ExchangeInformation exchange = new ExchangeInformation();
            exchange = exchangeInformations.FirstOrDefault();
            string e_Rate = exchange.Exchange_Rate.ToString();
            ViewBag.Exchange_Rate = e_Rate;

            return View();
        }

        // POST: CargoSalesInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CargoSalesInformation cargoSalesInformation)
        {
            if (!ModelState.IsValid)
            {



                //return ("GetCargoBackup");
                CargoRepository CargoRepo = new CargoRepository();
                // ModelState.Clear();
                var ssss = CargoRepo.GetCargoBackup(cargoSalesInformation);

                CargoSalesTransactionBackup transactionsss = ssss.FirstOrDefault();
                transactionsss.Trans_Type = "Save";
                db.CargoSalesTransactionBackups.Add(transactionsss);
                // transactionsss.Trans_Type = "Update";
                db.SaveChanges();

                //CargoSalesTransactionBackup cargoSalestransactionbackup = new CargoSalesTransactionBackup();

                //cargoSalestransactionbackup.CargoSalesId = cargoSalesInformation.CargoSalesId;
                //cargoSalestransactionbackup.SalesSlno = cargoSalesInformation.SalesSlno;
                //cargoSalestransactionbackup.MAWB = cargoSalesInformation.MAWB;
                //cargoSalestransactionbackup.Check_Digit = cargoSalesInformation.Check_Digit;
                //cargoSalestransactionbackup.Trans_Type="Save";
                ////transaction.Airway_No = cargoSalesInformation.Airway_No;
                //db.CargoSalesTransactionBackups.Add(cargoSalestransactionbackup);
                //db.SaveChanges();


                cargoSalesInformation.Airway_No = cargoSalesInformation.MAWB + cargoSalesInformation.Check_Digit;
                 StockIssueDetailInformations stockIssueDetailInformations = new StockIssueDetailInformations();
                 stockIssueDetailInformations = db.StockIssueDetailInformations.Where(a => a.Ticket_No.ToString() == cargoSalesInformation.MAWB).FirstOrDefault();
                 db.CargoSalesInformations.Add(cargoSalesInformation);
                 stockIssueDetailInformations.Status = "Sold";
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cargoSalesInformation);
        }
        public ActionResult Adddd()
        {
            return View();
        }
        public JsonResult Get_Consignor_Name(string Prefix)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var Consignor_Name = (from c in db.ConsignorInformations
                               where c.Consignor_Name.StartsWith(Prefix)
                               select new {c.Consignor_Name,c.Consignor_Code,c.Consignor_Address });
            return Json(Consignor_Name, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetConsignorCodeById(string consignorname)
        {

            var consignor_code = db.ConsignorInformations.Where(m => m.Consignor_Name == consignorname).FirstOrDefault();
            return Json(consignor_code, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_Consignee_Name(string Prefix)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var Consignee_Name = (from c in db.ConsigneeInformations
                                  where c.Consignee_Name.StartsWith(Prefix)
                                  select new { c.Consignee_Name});
            return Json(Consignee_Name, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetConsigneeCodeById(string consigneename)
        {
            var consignee_code = db.ConsigneeInformations.Where(m => m.Consignee_Name == consigneename).FirstOrDefault();
            return Json(consignee_code, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_Customer_Name(string Prefix)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var Customer_Name = (from c in db.CustomerInformations
                                  where c.Customer_Name.StartsWith(Prefix)
                                  select new { c.Customer_Name });
            return Json(Customer_Name, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCustomerCodeById(string customername)
        {
            var customer_code = db.CustomerInformations.Where(m => m.Customer_Name == customername).FirstOrDefault();
            return Json(customer_code, JsonRequestBehavior.AllowGet);
        }


        public JsonResult Get_Origin_Name(string Prefix)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var Origin_Name = (from c in db.OriginInformations
                                 where c.Long_Desc.StartsWith(Prefix)
                                 select new { c.Long_Desc });
            return Json(Origin_Name, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetOriginCodeById(string originname)
       {          
            var origin_code = db.OriginInformations.Where(m => m.Long_Desc == originname).FirstOrDefault();
            return Json(origin_code, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Get_Destination_Name(string Prefix)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var Destination_Name = (from c in db.DestinationInformations
                               where c.Long_Desc.StartsWith(Prefix)
                               select new { c.Long_Desc });
            return Json(Destination_Name, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetDestinationCodeById(string destinationname)
        {
            var destination_code = db.DestinationInformations.Where(m => m.Long_Desc == destinationname).FirstOrDefault();
            return Json(destination_code, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Get_Continent_Name(string Prefix)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var Continent_Name = (from c in db.ContinentInformations
                                    where c.Long_Desc.StartsWith(Prefix)
                                    select new { c.Long_Desc });
            return Json(Continent_Name, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetContinentCodeById(string continentname)
        {
            var continent_code = db.ContinentInformations.Where(m => m.Long_Desc == continentname).FirstOrDefault();
            return Json(continent_code, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_payment_Name(string Prefix)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var payment_Name = (from c in db.PaymentModeInformations
                                  where c.Long_Desc.StartsWith(Prefix)
                                  select new { c.Long_Desc });
            return Json(payment_Name, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetpaymentCodeById(string paymentname)
        {
            var payment_code = db.PaymentModeInformations.Where(m => m.Long_Desc == paymentname).FirstOrDefault();
            return Json(payment_code, JsonRequestBehavior.AllowGet);
        }
     
        public JsonResult Get_CargoType_Name(string Prefix)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var CargoType_Name = (from c in db.CargoTypeInformations
                              where c.Long_Desc.StartsWith(Prefix)
                              select new { c.Long_Desc });
            return Json(CargoType_Name, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetcargotypeCodeById(string cargotype_Name)
        {
            var cargotypecode = db.CargoTypeInformations.Where(m => m.Long_Desc == cargotype_Name).FirstOrDefault();
            return Json(cargotypecode, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_UplimentType_Name(string Prefix)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var UplimentType_Name = (from c in db.UplimentTypeInformations
                                  where c.Long_Desc.StartsWith(Prefix)
                                  select new { c.Long_Desc });
            return Json(UplimentType_Name, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetuplimenttypeCodeById(string uplimenttype_Name)
        {
            var uplimenttypecode = db.UplimentTypeInformations.Where(m => m.Long_Desc == uplimenttype_Name).FirstOrDefault();
            return Json(uplimenttypecode, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Get_Freighter_Name(string Prefix)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var Freighter_Name = (from c in db.FreighterInformations
                                     where c.Long_Desc.StartsWith(Prefix)
                                     select new { c.Long_Desc });
            return Json(Freighter_Name, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetfreighterCodeById(string freightername)
        {
            var freightercode = db.FreighterInformations.Where(m => m.Long_Desc == freightername).FirstOrDefault();
            return Json(freightercode, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_Route_Name(string Prefix)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var Route_Name = (from c in db.RouteInformations
                              where c.Long_Desc.StartsWith(Prefix)
                              select new { c.Long_Desc });
            return Json(Route_Name, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetrouteCodeById(string sectorname)
        {
            var route_code = db.RouteInformations.Where(m => m.Long_Desc == sectorname).FirstOrDefault();
            return Json(route_code, JsonRequestBehavior.AllowGet);
        }


        public JsonResult Get_CFpaymode_Name(string Prefix)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var CFpaymode_Name = (from c in db.CargoFreightPaymodeInformations
                              where c.Long_Desc.StartsWith(Prefix)
                              select new { c.Long_Desc });
            return Json(CFpaymode_Name, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetCFpaymodeById(string cfpaymodename)
        {
            var cf_code = db.CargoFreightPaymodeInformations.Where(m => m.Long_Desc == cfpaymodename).FirstOrDefault();
            return Json(cf_code, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_MAWB(string Prefix)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var MAWB = (from c in db.StockIssueDetailInformations
                               where c.Ticket_No.ToString().StartsWith(Prefix)
                        select new { c.Ticket_No });
            return Json(MAWB, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetMAWBCodeById(int mawbcode)
        {
            //var mawb_code = (from o in db.StockIssueDetailInformations
              //            where o.Ticket_No == mawbcode
                                 
                //          select o.Ticket_No).FirstOrDefault();

            var mawb_code = (from StockIssueDetailInformation in db.StockIssueDetailInformations
                         join StockIssueInformation in db.StockIssueInformations on StockIssueDetailInformation.SIssued_Code equals StockIssueInformation.SIssued_Code
                             join AirlinesInformation in db.AirlinesInformations on StockIssueInformation.Airlines_Code equals AirlinesInformation.Airlines_Code
                         where StockIssueDetailInformation.Ticket_No==mawbcode select new
             {
                             Ticket_No = StockIssueDetailInformation.Ticket_No,
                             SIssued_Code = StockIssueDetailInformation.SIssued_Code,
                             Airlines_Code = StockIssueInformation.Airlines_Code,
                             Long_Desc = AirlinesInformation.Long_Desc

                         }).FirstOrDefault();


            //var mawb_code = db.StockIssueDetailInformations.Where(m => m.Ticket_No == mawbcode).FirstOrDefault();
            return Json(mawb_code, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetReceivedCodeById(string srecieved_Code)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            //List<StockRecieveInformation> Informations = db.StockRecieveInformations.OrderByDescending(a => a.SRecievedId).ToList<StockRecieveInformation>();
            //StockRecieveInformation informationss = new StockRecieveInformation();
            //informationss.Ticket_Quantity = informationss.Ticket_Quantity.valu
            var receivedcode = db.StockRecieveInformations.Where(m => m.SRecieved_Code == srecieved_Code).FirstOrDefault();

            return Json(receivedcode, JsonRequestBehavior.AllowGet);

        }

        // GET: CargoSalesInformation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CargoSalesInformation cargoSalesInformation = db.CargoSalesInformations.Find(id);
            if (cargoSalesInformation == null)
            {
                return HttpNotFound();
            }
            return View(cargoSalesInformation);
        }

     

        // GET: CargoSalesInformation/Edit/5
        public ActionResult Edit(int? id)
        {

            CargoRepository CargoRepo = new CargoRepository();


            return View(CargoRepo.GetAllCargo().Find(Cargo => Cargo.CargoSalesId == id));
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //CargoSalesInformation cargoSalesInformation = db.CargoSalesInformations.Find(id);
            //if (cargoSalesInformation == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(cargoSalesInformation);
        }


        //public ActionResult Backup(int? id)
        //{

        //    CargoRepository CargoRepo = new CargoRepository();


        //    return View(CargoRepo.GetAllCargo().Find(Cargo => Cargo.CargoSalesId == id));
        //    //if (id == null)
        //    //{
        //    //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    //}
        //    //CargoSalesInformation cargoSalesInformation = db.CargoSalesInformations.Find(id);
        //    //if (cargoSalesInformation == null)
        //    //{
        //    //    return HttpNotFound();
        //    //}
        //    //return View(cargoSalesInformation);
        //}




        // POST: CargoSalesInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CargoSalesInformation cargoSalesInformation)
        {
            if (!ModelState.IsValid)
            {
             
                
                cargoSalesInformation.Airway_No = cargoSalesInformation.MAWB + cargoSalesInformation.Check_Digit;
                db.Entry(cargoSalesInformation).State = EntityState.Modified;
                db.SaveChanges();



                CargoSalesTransactionBackup cargoSalesTransaction = new CargoSalesTransactionBackup();



                //return ("GetCargoBackup");
                CargoRepository CargoRepo = new CargoRepository();
               // ModelState.Clear();
                 var ssss=CargoRepo.GetCargoBackup(cargoSalesInformation);

                CargoSalesTransactionBackup transactionsss = ssss.FirstOrDefault();
                transactionsss.Trans_Type = "Update";
                db.CargoSalesTransactionBackups.Add(transactionsss);
               // transactionsss.Trans_Type = "Update";
                db.SaveChanges();

                //object obj = CargoList;
                //CargoRepository CargoRepo = new CargoRepository();

                //CargoRepo.GetCargoBackup();


               // db.CargoSalesTransactionBackups.Attach(obj);
        

                

                // var CargoBackup = (CargoRepo.GetCargoBackup().Find(Cargo => Cargo.CargoSalesId == cargoSalesInformation.CargoSalesId));
               // CargoSalesTransactionBackup transactionsss = new CargoSalesTransactionBackup();
               // transactionsss = transaction;
                //transactionsss = CargoRepo.GetCargoBackup(cargoSalesInformation);

                //db.CargoSalesTransactionBackups.Add(transactionsss);
                //transaction = CargoBackup;



                //cargosss = ssss;
                //db.CargoSalesTransactionBackups.Add(cargosss);
                //transaction.SalesSlno = cargoSalesInformation.SalesSlno;
                //transaction.MAWB = cargoSalesInformation.MAWB;
                //transaction.Check_Digit = cargoSalesInformation.Check_Digit;
                //transaction.Airway_No = cargoSalesInformation.Airway_No;
                //transaction.Freighter_Code = cargoSalesInformation.Freighter_Code;
                //transaction.Origin_Code = cargoSalesInformation.Origin_Code;
                //transaction.Dest_Code = cargoSalesInformation.Dest_Code;
                //transaction.Continent_Code = cargoSalesInformation.Continent_Code;
                //transaction.CFPaymode_Code = cargoSalesInformation.CFPaymode_Code;
                //transaction.Route_Code = cargoSalesInformation.Route_Code;
                //transaction.Customer_Code = cargoSalesInformation.Customer_Code;
                //transaction.Cargo_Code = cargoSalesInformation.Cargo_Code;
                //transaction.UType_Code = cargoSalesInformation.UType_Code ;
                //transaction.MAWB = cargoSalesInformation.MAWB;
                //transaction.Check_Digit = cargoSalesInformation.Check_Digit;
                //transaction.Airway_No = cargoSalesInformation.Airway_No;



                //CargoSalesTransactionBackup ststs = new CargoSalesTransactionBackup();
                //ststs = CargoBackupData
                //db.CargoSalesTransactionBackups.Add(CargoBackupData);






                //db.CargoSalesTransactionBackups.Add(cargoSalesInformation);
                //return RedirectToAction("Index");
            }
            return View(cargoSalesInformation);
        }

       
        //public List<CargoSalesTransactionBackup> GetCargoBackup(CargoSalesInformation cargoSalesInformation)
        //{

        //    //CargoSalesInformation cargoSalesInformation = new CargoSalesInformation();

        //    List<CargoSalesTransactionBackup> CargoBackupList = new List<CargoSalesTransactionBackup>();
        //    CargoSalesTransactionBackup transaction = new CargoSalesTransactionBackup();
        //    transaction.CargoSalesId = cargoSalesInformation.CargoSalesId;
        //    transaction.SalesSlno = cargoSalesInformation.SalesSlno;
        //    transaction.MAWB = cargoSalesInformation.MAWB;
        //    transaction.Check_Digit = cargoSalesInformation.Check_Digit;


        //    CargoBackupList.Add(transaction);


        //    return CargoBackupList;



        //}

        // GET: CargoSalesInformation/Delete/5
        public ActionResult Return(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
            
                CargoSalesInformation Informations = db.CargoSalesInformations.Where(x => x.CargoSalesId == id).FirstOrDefault<CargoSalesInformation>();
                db.CargoSalesInformations.Remove(Informations);
                db.SaveChanges();

                CargoRepository CargoRepo = new CargoRepository();
                // ModelState.Clear();
                var ssss = CargoRepo.GetCargoBackup(Informations);

                CargoSalesTransactionBackup transactionsss = ssss.FirstOrDefault();
                transactionsss.Trans_Type = "Return";
                db.CargoSalesTransactionBackups.Add(transactionsss);
                // transactionsss.Trans_Type = "Update";
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }


        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
