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
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from tf in context.TesisFaturams
                             join ft in context.FaturaTurleries on tf.TesisFaturaTuruId equals ft.Id
                             select new TesisFaturalariDetay
                             {
                                 Id = tf.Id,
                                 FaturaTuru=ft.FaturaTuru,
                                 IslemTarihi=tf.IslemTarihi,
                                 SonOdeme=tf.SonOdeme,
                                 TesisFaturaTuruId=tf.TesisFaturaTuruId,
                                 TesisFaturaTutari=tf.TesisFaturaTutari
                            
                             };
                return result.ToList();
            }
        }
    }
}
