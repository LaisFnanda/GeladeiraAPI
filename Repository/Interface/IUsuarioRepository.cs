using Domain.Models;
using Domain.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IUsuarioRepository
    {
        Task AdicionarUsuarioAsync(Usuario usuario, CancellationToken cancellationToken);
        Task<Usuario> GetUsuarioAsync(LoginResource resource, CancellationToken cancellationToken);
    }
}
