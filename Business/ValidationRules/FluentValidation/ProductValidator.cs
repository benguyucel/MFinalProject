﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator: AbstractValidator<Product>
    {
        public ProductValidator()
        {

            RuleSet("ProductName", () =>
            {
                RuleFor(x => x.ProductName).NotEmpty();
                RuleFor(x => x.ProductName).MinimumLength(2);

            });
            RuleFor(x => x.UnitPrice).GreaterThan(0);
            RuleFor(x => x.UnitPrice).NotEmpty();
            RuleFor(x => x.UnitPrice).GreaterThanOrEqualTo(10).When(x => x.CategoryId == 1);
            RuleFor(x => x.ProductName).Must(StartWithA);
          

        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
