using ExpressAPI.DTO;
using ExpressAPI.Utilities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressAPI.DAL
{
    public class LoyalityServiceDAL
    {//            //DBConnection.GetConnectionString()
        public static SqlConnection conn = new SqlConnection(DBConnection.GetConnectionString());



        public List<MemberDTO> GetUserInfo(string _UserInfo)
        {
            List<MemberDTO> MemberInfo = new List<MemberDTO>();
            //List<SelectListItem> items = new List<SelectListItem>();
            DataTable dt = new DataTable();
            if (conn.State == 0)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand("SP_LOYAL_INFORMATION", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@REGNO", SqlDbType.NVarChar).Value = _UserInfo;

            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
              
                MemberInfo.Add(new MemberDTO
                {
                    ID = Convert.ToInt32(rdr["ID"]),
                    MOBILE_NO = rdr["MOBILE_NO"].ToString(),
                    CARD_NO = rdr["CARD_NO"].ToString(),
                    CUSTOMER_NAME = rdr["CUSTOMER_NAME"].ToString(),

                    GENDER = rdr["GENDER"].ToString(),
                    DOB =Convert.ToDateTime( rdr["DOB"].ToString()),

                    CARDMEMBER = rdr["CARDMEMBER"].ToString(),
                    CURRENT_PONTS = Convert.ToDouble( rdr["CURRENT_PONTS"].ToString()),
                    REDEEM_PONTS = Convert.ToDouble(rdr["REDEEM_PONTS"].ToString()),
                    CAN_REDEEM = rdr["CAN_REDEEM"].ToString()
                });
            }
            return MemberInfo;

        }
        
        public DataTable CheckService_Client(string _UserName, string _Password)
        {
 
            DataTable dt = new DataTable();
            if (conn.State == 0)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand("CheckService_Client", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = _UserName;
            cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = _Password;

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.Fill(dt);
            return dt;
        }
    }
}
