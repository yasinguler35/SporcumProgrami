using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DevFramework.Northwind.WebApi.Controllers
{
    public class KusaklarController : ApiController
    {
        private IKusaklarService _kusaklarService;
        public KusaklarController(IKusaklarService kusaklarService)
        {
            _kusaklarService = kusaklarService;
        }
        public List<Kusaklar> Get()
        {
            return _kusaklarService.GetAll() ;
        }
    }
}
