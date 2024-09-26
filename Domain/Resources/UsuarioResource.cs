using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Resources
{
    public sealed record UsuarioResource (int ID, string Nome, string Email);

}
