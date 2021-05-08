using HMS.Areas.Dashboard.ViewModels;
using HMS.Entities;
using HMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMS.Areas.Dashboard.Controllers
{
    public class AccomodationTypesController : Controller
    {
        // GET: Dashboard/AccomodationTypes
        AccomodationTypesService accomodationTypesServices = new AccomodationTypesService();
        public ActionResult Index(string searchterm)
        {
            AccomodationTypesListingModel model = new AccomodationTypesListingModel();
            model.AccomodationTypes = accomodationTypesServices.SearchAccomodationTypes(searchterm);
            model.searchTerm = searchterm;
            return View(model);
        }

        public ActionResult Action(int? ID)
        {
            AccomodationTypeActionModel model = new AccomodationTypeActionModel();
            if(ID.HasValue)
            {
                var accomodationType = accomodationTypesServices.GetAccomodationTypeByID(ID.Value);
                model.ID = accomodationType.ID;
                model.Name = accomodationType.Name;
                model.Description = accomodationType.Description;
            }
            return PartialView("Action", model);
        }

        [HttpPost]
        public JsonResult Action(AccomodationTypeActionModel model)
        {
            JsonResult jsonResult = new JsonResult();
            jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            bool result = false;

            

            if (model.ID > 0)
            {
                var accomodationType = accomodationTypesServices.GetAccomodationTypeByID(model.ID);
                accomodationType.Name = model.Name;
                accomodationType.Description = model.Description;
                result = accomodationTypesServices.UpdateAccomodationType(accomodationType);
            }
            else
            {
                AccomodationType accomodationType = new AccomodationType();
                accomodationType.Name = model.Name;
                accomodationType.Description = model.Description;
                result = accomodationTypesServices.SaveAccomodationType(accomodationType); 
            }
            if(result)
            {
                jsonResult.Data = new { Success = true };
            }
            else
            {
                jsonResult.Data = new { Success = false, Message="Failed to upload or edit Accommodation type"};
            }
            return jsonResult;
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            AccomodationTypeActionModel model = new AccomodationTypeActionModel();

            var accomodationType = accomodationTypesServices.GetAccomodationTypeByID(ID);
            model.ID = accomodationType.ID;
            return PartialView("Delete", model);
        }

        [HttpPost]
        public JsonResult Delete(AccomodationTypeActionModel model)
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            var accomodationType = accomodationTypesServices.GetAccomodationTypeByID(model.ID);
            var deleted = accomodationTypesServices.DeleteAccomodationType(accomodationType);

            if(deleted)
            {
                result.Data = new { Success = true };
            }
            else
            {
                result.Data = new { Success = false, Message = "Accommodation Type can't be deleted" };
            }
            return result;
        }
    }
}