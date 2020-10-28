using DevFramework.Northwind.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Business.ValidationRules.FluentValidation
{
    public class SporcuValidatior : AbstractValidator<Sporcu>
    {
        public SporcuValidatior()
        {
            RuleFor(p => p.AdSoyad).NotEmpty();
            RuleFor(p => p.TelNo).NotEmpty();
            RuleFor(p => p.KategoriAdi).NotEmpty();
        }
    }
}
