using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using JobPortalApi.BuisnessLogic.Implementation;
using JobPortalApi.BuisnessLogic.Interfaces;
using JobPortalApi.Models;
using JobPortalApi.ViewModel;

namespace JobPortalApi.Controllers
{

    [RoutePrefix("Api/Register")]
    public class RegisterAPIController : ApiController
    {
        public static string image = "";
        ICountry objCountry = new CountryConcrete();
        IState objState = new StateConcrete();
        ICity objCity = new CityConcrete();
        IRegister objRegister = new RegisterConcrete();

        [HttpGet]
        [Route("AllCountryDetails")]
        public IEnumerable<CountryViewModel> GetCountry()
        {
            IEnumerable<CountryViewModel> lstCountry = new List<CountryViewModel>();
            try
            {
                lstCountry = objCountry.GetCountry();
            }
            catch (Exception)
            {
                throw;
            }
            return lstCountry;
        }

        [HttpGet]
        [Route("AllStateDetails/{countryID}")]
        public IEnumerable<State> GetState(int countryId)
        {
            IEnumerable<State> lstState = new List<State>();
            try
            {
                lstState = objState.GetState(countryId);
            }
            catch (Exception)
            {
                throw;
            }
            return lstState;
        }
        [HttpGet]
        [Route("AllCityDetails/{StateId}")]
        public IEnumerable<City> GetCity(int StateId)
        {
            IEnumerable<City> lstCity = new List<City>();
            try
            {
                lstCity = objCity.GetCity(StateId);
            }
            catch (Exception)
            {
                throw;
            }
            return lstCity;
        }
        [HttpGet]
        [Route("CheckUserName")]
        public bool GetEmail(string userName)
        {
            try
            {
                return objRegister.CheckExistUser(userName);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [Route("UploadImage")]
        [HttpPost]
        public void ImageUpload()
        {

            string imageName = null;

            var httpRequest = HttpContext.Current.Request;

            //Upload Image
            var postedFile = httpRequest.Files["Image"];
            //Create custom filename
            if (postedFile != null)
            {

                imageName = new String(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ", "-");

                imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile.FileName);

                var filePath = HttpContext.Current.Server.MapPath("~/Images/" + imageName);

                postedFile.SaveAs(filePath);

                image = imageName;
            }
        }


        [HttpPost]
        [Route("InsertRegDetails")]
        public IHttpActionResult PostUser(Register data)
        {

            if (image != "")
            {

                data.Image = image;
            }

            string result = "";

            if (!ModelState.IsValid)

            {

                return BadRequest(ModelState);
            }
            try
            {
                result = objRegister.InsertReg(data);

                image = "";

            }

            catch (Exception)
            {
                throw;
            }

            return Ok(result);
        }
    }
}

