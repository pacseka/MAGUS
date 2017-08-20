using MAGUS.Domain;
using MAGUS.Domain.Models;
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
        public IHttpActionResult CreateRanged(RangedWeaponDTO rangedWeaponDTO)
        {
            ModelState.Clear();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newWeapon = this._weaponFacade.CreateRangedWeapon(rangedWeaponDTO);

            if (string.IsNullOrEmpty(newWeapon.ID))
            {
                InternalServerError();
            }

            return Ok(newWeapon);
        }

        [HttpPost]
        public IHttpActionResult CreateMelee(MeleeWeaponDTO meleeWeaponDTO)
        {
            ModelState.Clear();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newWeapon = this._weaponFacade.CreateMeleeWeapon(meleeWeaponDTO);

            if (string.IsNullOrEmpty(newWeapon.ID))
            {
                InternalServerError();
            }

            return Ok(newWeapon);
        }

        [HttpGet]
        public WeaponDTO Get(string id)
        {
            var weapon = this._weaponFacade.GetWeapon(id);
            return weapon;
        }


        [HttpPut]
        public IHttpActionResult UpdateRanged(RangedWeaponDTO rangedWeaponDTO)
        {
            var result = false;

            result = this._weaponFacade.UpdateRangedWeapon(rangedWeaponDTO);

            IHttpActionResult rval = Ok(true);

            if (!result) rval = InternalServerError();

            return rval;
        }

        [HttpPut]
        public IHttpActionResult UpdateMelee(MeleeWeaponDTO meleeWeaponDTO)
        {
            var result = false;

            result = this._weaponFacade.UpdateMeleeWeapon(meleeWeaponDTO);

            IHttpActionResult rval = Ok(true);

            if (!result) rval = InternalServerError();

            return rval;

        }

    }
}