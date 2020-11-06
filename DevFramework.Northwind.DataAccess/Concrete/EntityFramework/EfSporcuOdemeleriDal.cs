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
    public class EfSporcuOdemeleriDal : EfEntityRepositoryBase<SporcuOdemeleri, NorthwindContext>, ISporcuOdemeleriDal
    {
        public List<SporcuOdemeleriDetay> GetSporcuOdemeleriDetay()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from so in context.SporcuOdemeleris
                             join s in context.Sporcus
                             on so.SporcuId equals s.Id
                             //where so.SporcuId == 
                             select new SporcuOdemeleriDetay
                             {
                                 Id=so.Id,
                                 SporcuId=so.SporcuId,
                                 AdSoyad =s.AdSoyad,
                                 Ocak=so.Ocak,
                                 Subat=so.Subat,
                                 Mart=so.Mart,
                                 Nisan=so.Nisan,
                                 Mayis=so.Mayis,
                                 Haziran=so.Haziran,
                                 Temmuz=so.Temmuz,
                                 Agustos=so.Agustos,
                                 Eylul=so.Eylul,
                                 Ekim=so.Ekim,
                                 Kasim=so.Kasim,
                                 Aralik=so.Aralik,
                                 KiyafetParasi=so.KiyafetParasi,
                                 Yil=so.Yil
                                 
                             };
                return result.ToList();
            }
        }


    }
}
