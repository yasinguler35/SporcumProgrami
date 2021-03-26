using DevFramework.Core.DataAccess.EntityFramework;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Northwind.Entities.ComplexTypes;

namespace DevFramework.Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfTesisFaturamDal : EfEntityRepositoryBase<TesisFaturam, NorthwindContext>, ITesisFaturamDal
    {
        public List<TesisFaturalariDetay> GetTesisFaturamDetay()
        {
            throw new NotImplementedException();
            //using (NorthwindContext context = new NorthwindContext())
            //{
            //    var result = from tf in context.TesisFaturams
            //                 join t in context. on ko.SporcuId equals s.Id
            //                 select new KusakOdemeleriDetay
            //                 {
            //                     Id = ko.Id,
            //                     KusakId = ko.KusakId,
            //                     SporcuId = ko.SporcuId,
            //                     AdSoyad = s.AdSoyad,
            //                     KusakAdi = k.KusakAdi,
            //                     OdemeTarihi = ko.OdemeTarihi,
            //                     OdemeTutari = ko.OdemeTutari
            //                 };
            //    return result.ToList();
            //}
        }
    }
}
