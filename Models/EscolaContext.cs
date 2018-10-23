using Microsoft.EntityFrameworkCore;

namespace Escola.Models
{
    public class EscolaContext : DbContext
    {
        public EscolaContext (DbContextOptions<EscolaContext> options)
            : base(options)
        {
        }

        public DbSet< Escola.Models.MinhaEscola > MinhaEscola { get; set; }
    }
}