using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressAPI.DTO
{
    public class MemberDTO
    {
        //      ID MOBILE_NO   CARD_NO CUSTOMER_NAME   GENDER DOB CARDMEMBER CURRENT_PONTS   REDEEM_PONTS CAN_REDEEM
        //223131	1918998570	1220753964940303	HASAN MEHEDI    Male	2021-06-26	SILVER	500	210.00	YES
        public int ID { get; set; }
        public string MOBILE_NO { get; set; }
        public string CARD_NO { get; set; }
        public string CUSTOMER_NAME { get; set; }
        public string GENDER { get; set; }
        public DateTime DOB { get; set; }
        public string CARDMEMBER { get; set; }
        public double CURRENT_PONTS { get; set; }
        public double REDEEM_PONTS { get; set; }
        public string CAN_REDEEM { get; set; }
    }

    public class ResponseModel
    {
        public string Message { set; get; }
        public bool Status { set; get; }
        public object Results { set; get; }
    }

    public class TockenModel
    {
        public string Tocken { set; get; }

    }
}
