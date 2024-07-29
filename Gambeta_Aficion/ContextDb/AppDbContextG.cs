using Gambeta_Aficion.Models;
using Microsoft.EntityFrameworkCore;

namespace Gambeta_Aficion.ContextDb
{
	public class AppDbContextG : DbContext
	{
		public AppDbContextG(DbContextOptions options) : base(options) { }

		public DbSet<Player> Players { get; set; }
		public DbSet<Team> Teams { get; set; }
		public DbSet<PlayerStat> PlayerStats { get; set; }
		public DbSet<League> Leagues { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Player>()
				.Property(p => p.TeamId)
				.HasColumnName("team_id");

			modelBuilder.Entity<Player>()
				.HasOne(p => p.Team)
				.WithMany(t => t.Players) // Ajusta según tu configuración de la relación
				.HasForeignKey(p => p.TeamId)
				.OnDelete(DeleteBehavior.SetNull); // Ajusta el comportamiento según sea necesario
		}
	}
}
