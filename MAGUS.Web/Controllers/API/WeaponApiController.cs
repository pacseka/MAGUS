using MAGUS.Domain;
using MAGUS.Models;
using MAGUS.Web.Facade.Interfaces;
using MAGUS.Web.Facade.Models;
using System;
using System.Web.Http;

namespace MAGUS.Web.Controllers.API
{
    public class WeaponApiController : ApiController
    {
        private readonly IWeaponFacade _weaponFacade;

        public WeaponApiController(IWeaponFacade weaponFacade)
        {
            this._weaponFacade = weaponFacade;
        }

        [HttpPost]
        public IHttpActionResult Search(WeaponFilter weaponFilter)
        {
            try
            {
                var armory = this._weaponFacade.FindWeaponsByFilter(weaponFilter);
                return Ok(armory);
            }
            catch (Exception E)
            {
                string error = E.Message + Environment.NewLine;
                error += E.InnerException + Environment.NewLine;
                error += E.StackTrace + Environment.NewLine;
                new LogEvent(E.Message).Raise();
            }
            return InternalServerError();
        }

        [HttpPost]
        public IHttpActionResult CreateRangedWeapon(RangedWeaponDTO rangedWeaponDTO)
        {
            ModelState.Clear();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newWeapon = this._weaponFacade.CreateWeapon(rangedWeaponDTO);

            if (string.IsNullOrEmpty(newWeapon.ID))
            {
                InternalServerError();
            }

            return Ok(newWeapon);
        }


        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]WeaponDTO weapon)
        {
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put([FromBody]WeaponDTO weapon)
        {
            var result = false;

            IHttpActionResult rval = Ok();

            if (!result) rval = InternalServerError();

            return rval;
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}