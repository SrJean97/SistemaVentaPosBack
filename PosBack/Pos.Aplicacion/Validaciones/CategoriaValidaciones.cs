using FluentValidation;
using Pos.Aplicacion.Dtos.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Aplicacion.Validaciones
{
    public class CategoriaValidaciones : AbstractValidator<CategoriaRequestDto>
    {
        public CategoriaValidaciones()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El nombre no puede se vacio.")
                .NotNull().WithMessage("El nombre no puede ser nulo.");
        }
    }
}
