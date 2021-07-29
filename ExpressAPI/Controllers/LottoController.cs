using Microsoft.AspNetCore.Mvc;
using System.Linq;
using RestSharp;
using ExpressAPI.DTO;
using Newtonsoft.Json;
using System.Net.Http;
using System.Collections.Generic;

//using System.Web.Mvc;

namespace ExpressAPI.Controllers
{
    public class LottoController : Controller
    {
        // public static string _BaseURL="https://localhost:44354/";
        public static string _BaseURL = "https://service.elpl.app/";

        private readonly RestClient _client;
        //    private readonly string _url = Configuration.GetValue<string>("webapibaseurl");// ConfigurationManager.AppSettings["webapibaseurl"];

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("FindData")]
        public JsonResult GetData(string _Token, string _MobileNo)
        {
            ///   https: // service.elpl.app
            //     string _url = "https://localhost:44354/";
            // string _url = "https://service.elpl.app/";
            var client = new RestClient(_BaseURL + "ServiceApi/Getinfo/?_Mobile=" + _MobileNo)
                .AddDefaultUrlSegment
                ("_Mobile", _MobileNo);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Bearer " + _Token);
            IRestResponse response = client.Execute(request);
            return Json(response.Content);
        }
        [HttpGet("MemberDetails")]
        public JsonResult GetDetails(string _Token, string _MobileNo)
        {
            var client = new RestClient(_BaseURL + "ServiceApi/GetDetails/?_Mobile=" + _MobileNo)
            //sssvar client = new RestClient(_BaseURL + "ServiceApi/Getinfo/?_Mobile=" + _MobileNo)
               .AddDefaultUrlSegment
               ("_Mobile", _MobileNo);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Bearer " + _Token);
            //   IRestResponse response = client.Execute<list<ResponseModel>>(request);// client.Execute(request);
            // ResponseModel responss = ResponseModel { 
            //}
            IRestResponse result = client.Execute<ResponseModel>(request);

             var odosRecord = JsonConvert.DeserializeObject<ResponseModel>(result.Content);

            //List<MemberDTO> aa =  (List<MemberDTO>)odosRecord.Results.t;

            ResponseModel rs = new ResponseModel();
             rs.Message = odosRecord.Message;
            rs.Status = odosRecord.Status;
             rs.Results = aa.ToArray();//odosRecord.Results;//.ToArray(); 

            //   var json = "[{\"Name\":\"John Smith\", \"Age\":35}, {\"Name\":\"Pablo Perez\", \"Age\":34}]";

            // use the built in Json deserializer to convert the string to a list of Person objects
            //var people = System.Text.Json.JsonSerializer.Deserialize<List<ResponseModel>>(result.Content);
            //ResponseModel rs = new ResponseModel();
            //foreach (var person in people)
            //{
            //    rs.Message = person.Message;
            //    rs.Results = person.Results;
            //    rs.Status = person.Status;
            //    //   Console.WriteLine(person.Name + " is " + person.Age + " years old.");
            //}
            //HttpContent content = result.Content;
            //string mycontent = await content.ReadAsStringAsync();
            ////deserialization in items
            //ResponseModel[] items = JsonConvert.DeserializeObject<ResponseModel[]>(mycontent);

            return Json(rs);


            //JArray jsonResponse = JArray.Parse(result.Content);

            //foreach (var item in jsonResponse)
            //{
            //    JObject jRaces = (JObject)item["Results"];
            //    foreach (var rItem in jRaces)
            //    {
            //        string rItemKey = rItem.Key;
            //        JObject rItemValueJson = (JObject)rItem.Value;
            //        ResponseModel rowsResult = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseModel>(rItemValueJson.ToString());
            //    }
            //}


            //var client = new RestRequest(_BaseURL + "ServiceApi/GetDetails/?_Mobile=" + _MobileNo);
            //client.Timeout = -1;
            //var request = new RestRequest(Method.GET);
            //request.AddHeader("Authorization", "Bearer " + _Token);

            //IRestResponse response = client.Execute(request);
            //return Json(response.Content);

            //var request = new RestRequest(Method.GET) { };
            //var response = _client.Execute<list<ResponseModel>>(request);

            //if (response.Data == null)
            //    throw new Exception(response.ErrorMessage);

            //return response.Data;
        }

        //[HttpGet("MemberDetails")]

        //// //IEnumerable<bool> JsonResult List<string>
        //public IEnumerable<IList> GetDetails(string _Token, string _MobileNo)
        //{

        //    var client = new RestClient(_BaseURL + "ServiceApi/GetDetails/?_Mobile=" + _MobileNo)
        //       .AddDefaultUrlSegment
        //       ("_Mobile", _MobileNo);
        //    client.Timeout = -1;
        //    var request = new RestRequest(Method.GET)
        //    { RequestFormat = DataFormat.Json };

        //    request.AddHeader("Authorization", "Bearer " + _Token);
        //    // IRestResponse response = client.Execute(request);

        //    IRestResponse<List<string>> responss = client.Execute<List<string>>(request);

        //    //      ResponseModel

        //    return (IEnumerable<IList>)Json(responss.Data);

        //    //List<string> lstAuthors = new List<string>();
        //    //foreach (KeyValuePair<int, string> keyValuePair in authors)
        //    //    lstAuthors.Add(keyValuePair.Value);
        //    //return lstAuthors;

        //    //   ArrayList myAL = new ArrayList() { response.Content };
        //    ////    myAL = response.Content.ToArray<>();

        //    //   return Json(myAL);
        //}
    }
}
