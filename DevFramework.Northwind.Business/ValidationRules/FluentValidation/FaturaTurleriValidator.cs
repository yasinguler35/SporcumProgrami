using DevFramework.Northwind.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Business.ValidationRules.FluentValidation
{
    public class FaturaTurleriValidator : AbstractValidator<FaturaTurleri>
    {
        public FaturaTurleriValidator()
        {
            RuleFor(p => p.FaturaTuru).NotEmpty();
        }
    }
}
