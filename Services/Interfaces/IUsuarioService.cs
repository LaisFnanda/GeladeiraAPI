using Domain.Models;
using Domain.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioResource> Registro (RegistroResource resource, CancellationToken cancellationToken);
        Task<UsuarioResource> Login (LoginResource resource, CancellationToken cancellationToken);
    }
}
