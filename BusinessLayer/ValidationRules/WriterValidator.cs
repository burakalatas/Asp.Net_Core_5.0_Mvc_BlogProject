using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı soyadı boş geçilemez!");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter giriniz.");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail adresi boş geçilemez!");
            RuleFor(p => p.WriterMail).Matches(@"[@,.]+").WithMessage("Mail adresi @ ve . içermelidir.");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre boş geçilemez");
            RuleFor(p => p.WriterPassword).Matches(@"[A-Z]+").WithMessage("Şifre en az bir büyük harf içermelidir.");
            RuleFor(p => p.WriterPassword).Matches(@"[a-z]+").WithMessage("Şifre en az bir küçük harf içermelidir.");
            RuleFor(p => p.WriterPassword).Matches(@"[0-9]+").WithMessage("Şifre en az bir rakam içermelidir.");
        }
    }
}
