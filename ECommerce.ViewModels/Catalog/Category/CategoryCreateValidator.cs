using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.ViewModels.Catalog.Category
{
    public class CategoryCreateValidator : AbstractValidator<CategoryCreateRequest>
    {
        public CategoryCreateValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name can not be blank")
                .MaximumLength(100).WithMessage("Name can not over 100 characters");
            RuleFor(x => x.SeoTitle).NotEmpty().WithMessage("Title can not be blank")
                .MaximumLength(200).WithMessage("Title shoul nt");
        }
    }
}
