using OnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    public class ProductsController : ApiController
    {
        Context c = new Context();
        public List<Urun> Get()
        {
            var data = c.Uruns.Where(x=>x.Durum==true).ToList();
             
                return data;
        }
    }
}
