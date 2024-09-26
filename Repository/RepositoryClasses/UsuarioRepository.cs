using Domain.Models;
using Domain.Resources;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interface;


namespace Repository.RepositoryClasses
{
    public class UsuarioRepository: IUsuarioRepository
    {
        private readonly ItemContext _context;
        public UsuarioRepository(ItemContext context) 
        {
            _context = context;
        }

        public async Task AdicionarUsuarioAsync(Usuario usuario, CancellationToken cancellationToken)
        {
            await _context.Usuarios.AddAsync(usuario, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public Task<Usuario> GetUsuarioAsync(LoginResource resource, CancellationToken cancellationToken) =>
            _context.Usuarios.FirstOrDefaultAsync(x => x.Nome == resource.Nome, cancellationToken);
    }
}
