using DevFramework.Northwind.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Business.ValidationRules.FluentValidation
{
    public class TesisDemirbaslarValidator : AbstractValidator<TesisDemirbaslar>
    {
        public TesisDemirbaslarValidator()
        {
            RuleFor(p => p.DemirBasAdi).NotEmpty();
        }
    }
}
