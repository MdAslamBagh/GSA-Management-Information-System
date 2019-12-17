//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Data;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Web;

//namespace GSA_Management_Information_System.Models
//{
//    public class EmpRepository
//    {

//        private SqlConnection con;
//        //To Handle connection related activities
//        private void connection()
//        {
//            string constr = ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ToString();
//            con = new SqlConnection(constr);

//        }
//        ////To Add Employee details
//        //public bool AddEmployee(EmpModel obj)
//        //{

//        //    connection();
//        //    SqlCommand com = new SqlCommand("AddNewEmpDetails", con);
//        //    com.CommandType = CommandType.StoredProcedure;
//        //    com.Parameters.AddWithValue("@Name", obj.Name);
//        //    com.Parameters.AddWithValue("@City", obj.City);
//        //    com.Parameters.AddWithValue("@Address", obj.Address);

//        //    con.Open();
//        //    int i = com.ExecuteNonQuery();
//        //    con.Close();
//        //    if (i >= 1)
//        //    {

//        //        return true;

//        //    }
//        //    else
//        //    {

//        //        return false;
//        //    }


//        //}
//        //To view employee details with generic list 
//        public List<EditCargoViewModel> GetAllEmployees()
//        {
//            connection();
//            List<EditCargoViewModel> EmpList = new List<EditCargoViewModel>();
//            SqlCommand com = new SqlCommand("spCargoSalesDetails", con);
//            com.CommandType = CommandType.StoredProcedure;
//            SqlDataAdapter da = new SqlDataAdapter(com);
//            DataTable dt = new DataTable();
//            con.Open();
//            da.Fill(dt);
//            con.Close();

//            //Bind EmpModel generic list using LINQ 
//            EmpList = (from DataRow dr in dt.Rows

//                       select new EditCargoViewModel()
//                       {
//                           CargoSalesId = Convert.ToInt32(dr["CargoSalesId"]),
//                           MAWB = Convert.ToString(dr["MAWB"]),
//                           Origin_Code = Convert.ToString(dr["Origin_Code"]),
//                           Origin_Name = Convert.ToString(dr["OriginName"]),
//                           //Address = Convert.ToString(dr["Address"])
//                       }).ToList();


//            return EmpList;


//        }
//        //To Update Employee details
//        //public bool UpdateEmployee(EmpModel obj)
//        //{

//        //    connection();
//        //    SqlCommand com = new SqlCommand("UpdateEmpDetails", con);

//        //    com.CommandType = CommandType.StoredProcedure;
//        //    com.Parameters.AddWithValue("@EmpId", obj.Empid);
//        //    com.Parameters.AddWithValue("@Name", obj.Name);
//        //    com.Parameters.AddWithValue("@City", obj.City);
//        //    com.Parameters.AddWithValue("@Address", obj.Address);
//        //    con.Open();
//        //    int i = com.ExecuteNonQuery();
//        //    con.Close();
//        //    if (i >= 1)
//        //    {

//        //        return true;

//        //    }
//        //    else
//        //    {

//        //        return false;
//        //    }


//        //}
//        //To delete Employee details
//        public bool DeleteEmployee(int Id)
//        {

//            connection();
//            SqlCommand com = new SqlCommand("DeleteEmpById", con);

//            com.CommandType = CommandType.StoredProcedure;
//            com.Parameters.AddWithValue("@EmpId", Id);

//            con.Open();
//            int i = com.ExecuteNonQuery();
//            con.Close();
//            if (i >= 1)
//            {

//                return true;

//            }
//            else
//            {

//                return false;
//            }


//        }
//    }
//}
