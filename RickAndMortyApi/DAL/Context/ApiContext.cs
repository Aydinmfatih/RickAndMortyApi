using Microsoft.EntityFrameworkCore;
using RickAndMortyApi.DAL.Entities;

namespace RickAndMortyApi.DAL.Context
{
    public class ApiContext:DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options):base(options)
        {
            
        }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Episode> Episodes { get; set; }
    }
}
