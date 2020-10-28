using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Entities.Concrete
{
    public class Sporcu:IEntity
    {
        public virtual int Id { get; set; }
        public virtual string AdSoyad { get; set; }
        public virtual string TelNo { get; set; }
        public virtual int ?FotoID { get; set; }
        public virtual int ?LisansFotoID { get; set; }
        public virtual string VeliAdi { get; set; }
        public virtual string VeliTelNo { get; set; }
        public virtual string Aciklama { get; set; }
        public virtual string DogumTarihi { get; set; }
        public virtual string KategoriAdi { get; set; }
        public virtual string KusakSeviyesi { get; set; }

    }
}
