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
    public class EfSporcuDal: EfEntityRepositoryBase<Sporcu, NorthwindContext>, ISporcuDal
    {
        //public List<SporcuKategoriDetay> GetSporcuKategori()
        //{
        //    using (NorthwindContext context = new NorthwindContext())
        //    {
        //        var result = from s in context.Sporcus
        //                     join sk in context.SporcuKategories on s.KategoriID equals sk.Id
        //                     select new SporcuKategoriDetay
        //                     {
        //                       Id=s.Id,
        //                       AdSoyad=s.AdSoyad,
        //                       DogumTarihi=s.DogumTarihi,
        //                       TelNo=s.TelNo,
        //                       Aciklama=s.Aciklama,
        //                       VeliAdi=s.VeliAdi,
        //                       VeliTelNo=s.VeliTelNo,
        //                       KategoriAdi=sk.KategoriAdi
        //                     };

        //        return result.ToList();
        //    }

        //}
    }
}
