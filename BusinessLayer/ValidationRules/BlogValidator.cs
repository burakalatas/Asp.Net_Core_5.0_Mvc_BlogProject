using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog başlığı boş bırakılamaz!");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog içeriği boş bırakılamaz!");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Blog görseli boş bırakılamaz!");
            RuleFor(x => x.BlogTitle).MaximumLength(150).WithMessage("Blog başlığı 150 karakteri aşmamalı!");
            RuleFor(x => x.BlogTitle).MinimumLength(2).WithMessage("Blog başlığı 2 karakterden az olmamalı!");
            RuleFor(x => x.BlogContent).MinimumLength(20).WithMessage("Blog içeriği en az 20 karakter içermeli!");
            RuleFor(x => x.BlogContent).MaximumLength(2000).WithMessage("Blog içeriği en fazla 2000 karakter içermeli!");

        }
    }
}
