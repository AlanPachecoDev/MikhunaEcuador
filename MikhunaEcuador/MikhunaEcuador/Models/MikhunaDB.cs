
//Agregado
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MikhunaEcuador.Models
{
    //Yo le agrego el DbContext
    public class MikhunaDB : DbContext
    {
        //Son las tablas, que también están en el modelo
        public DbSet<Receta> Receta { get; set; }
        public DbSet<Ingrediente> Ingrediente { get; set; }
        public DbSet<Calificacion> Calificacion { get; set; }
        public DbSet<Favoritos> Favoritos { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Pasos> Pasos { get; set; }
        public DbSet<RecetasTerminadas> RecetasTerminadas { get; set; }
        public DbSet<Comentario> Comentario { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        }

    }

}