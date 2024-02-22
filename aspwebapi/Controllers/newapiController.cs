using aspwebapi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.MappingViews;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace aspwebapi.Controllers
{
    public class newapiController : ApiController
    {
        humsafar_travelsEntities db=new humsafar_travelsEntities();
        [System.Web.Http.HttpGet]
        public IHttpActionResult Action()
        {
            List<admin> obj=db.admins.ToList();
            return Ok(obj);
        }

        
        [System.Web.Http.HttpPost]
        public IHttpActionResult Store(admin a )
        {
            db.admins.Add(a);
            db.SaveChanges();
            return Ok();
        }
        
    }

}