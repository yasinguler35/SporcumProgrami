using DevFramework.Northwind.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Business.ValidationRules.FluentValidation
{
    public class TesisFaturamValidatior : AbstractValidator<TesisFaturam>
    {
        public TesisFaturamValidatior()
        {
            RuleFor(p => p.TesisFaturaTuru).NotEmpty();
        }
    }
}
