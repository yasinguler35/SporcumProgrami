using DevFramework.Core.DataAccess.EntityFramework;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.Entities.ComplexTypes;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfKusakOdemeleriDal : EfEntityRepositoryBase<KusakOdemeleri, NorthwindContext>, IKusakOdemeleriDal
    {
        public List<KusakOdemeleriDetay> GetKusakOdemleriDetay()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from ko in context.KusakOdemeleris
                             join s in context.Sporcus on ko.SporcuId  equals s.Id
                             join k in context.Kusaklars on ko.KusakId equals k.Id
                             select new KusakOdemeleriDetay
                             {
                                 Id=ko.Id,
                                 KusakId=ko.KusakId,
                                 SporcuId=ko.SporcuId,
                                 AdSoyad=s.AdSoyad,
                                 KusakAdi=k.KusakAdi,
                                 OdemeTarihi=ko.OdemeTarihi,
                                 OdemeTutari=ko.OdemeTutari
                             };
                return result.ToList();
            }
        }
    }
}
