using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using The_World.Models;
using TheWorld.Models;
using System.Net;
using The_World.ViewModels;
using AutoMapper;

namespace The_World.Controllers.Api
{
    [Route("api/trips")]
    public class TripController : Controller
    {
        private IWorldRepository _repository;

        public TripController(IWorldRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("")]
        public JsonResult Get()
        {
            var results = Mapper.Map<IEnumerable<TripViewModel>>(_repository.GetAllTripsWithStops());

            return Json(results);
        }

        [HttpPost("")]
        public JsonResult Post([FromBody]TripViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newTrip = Mapper.Map<Trip>(vm);

                    //Save to the Database

                    Response.StatusCode = (int)HttpStatusCode.Created;
                    return Json(Mapper.Map<TripViewModel>(newTrip));
                }
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Message = ex.Message });
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new { Message = "Failed", ModelState = ModelState });
            
        }
    }
}
