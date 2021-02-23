using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.BrandId).NotEmpty();
            RuleFor(c => c.ColorId).NotEmpty();
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.ModelYear).NotEmpty(); 
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.ModelYear).MinimumLength(4);
            RuleFor(c => c.ModelYear).MaximumLength(4);
            // If model year >= then 2019, the daily price must be >= 450. 
            //RuleFor(c => c.DailyPrice).GreaterThan(450).When(c => Int64.Parse(c.ModelYear) >= 2019);
        
        }
    }
}
