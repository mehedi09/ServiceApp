using ExpressAPI.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExpressAPI.DAL;
using System.Data;
using ExpressAPI.Utilities;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExpressAPI.Controllers

{


    [Microsoft.AspNetCore.Mvc.Route("ServiceApi/")]
    [ApiController]
    public class ServiceController : Controller
    {
        private readonly IJWTAuthenticationManager jWTAuthenticationManager;
        LoyalityServiceDAL _Loyality = new LoyalityServiceDAL();
        BasicUtilities _BasicUtilities = new BasicUtilities();

        public ServiceController(IJWTAuthenticationManager jWTAuthenticationManager)
        {
            this.jWTAuthenticationManager = jWTAuthenticationManager;
        }


        // GET: api/<NameController>
        [HttpGet("GetInfo")]
        [Authorize]

        public IEnumerable<bool>
            //bool
            GetMember(string _Mobile)
        {
            List<MemberDTO> result = _Loyality.GetUserInfo(_Mobile);
        


            if (result.Count > 0)
            {
                return new bool[] { true };
             
            }
            return new bool[] { false };
           


        }
        [HttpGet("GetDetails")]
        [Authorize]

        public ResponseModel //List<Dictionary<string, object>> //string 
            GetMemberDetails(string _Mobile)
        {
            List<MemberDTO>  result = _Loyality.GetUserInfo(_Mobile);
           
            ResponseModel _objResponseModel = new ResponseModel();
            _objResponseModel.Results = result.ToArray();
            if (result.Count > 0)
            {

                _objResponseModel.Status = true;
                _objResponseModel.Message = "Successfully Data Found";

            }
            else
            {
                _objResponseModel.Status = false;
                _objResponseModel.Message = "No Data Found";

            }
            return _objResponseModel;

            
        }
        

        [AllowAnonymous]
        [HttpPost("Authenticate")]

        [Authorize]
        public IActionResult
            Authenticate(string _UserName, string _Password)
        {
            var token = jWTAuthenticationManager.Authenticate(_UserName, _Password).ToString();

            if (token == null)
                return Unauthorized();

            TockenModel _token = new TockenModel();
            _token.Tocken = token;

            return Ok(_token);
        }



    }
}
