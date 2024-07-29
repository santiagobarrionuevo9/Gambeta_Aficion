using Microsoft.EntityFrameworkCore;

namespace Gambeta_Aficion.Models;

public partial class AppDbContext : DbContext
{
	public AppDbContext()
	{
	}

	public AppDbContext(DbContextOptions<AppDbContext> options)
		: base(options)
	{
	}

	public virtual DbSet<League> Leagues { get; set; }

	public virtual DbSet<Player> Players { get; set; }

	public virtual DbSet<PlayerStat> PlayerStats { get; set; }

	public virtual DbSet<Team> Teams { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
		=> optionsBuilder.UseMySql("server=roundhouse.proxy.rlwy.net;port=42493;database=railway;user=root;password=dHDeUduyLfleJZoBwxTvjxZOEvzPZvZO;connect timeout=120", Microsoft.EntityFrameworkCore.ServerVersion.Parse("9.0.1-mysql"));

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder
			.UseCollation("utf8mb4_0900_ai_ci")
			.HasCharSet("utf8mb4");

		modelBuilder.Entity<League>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PRIMARY");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.Country)
				.HasMaxLength(100)
				.HasColumnName("country");
			entity.Property(e => e.Name)
				.HasMaxLength(100)
				.HasColumnName("name");
			entity.Property(e => e.Season)
				.HasMaxLength(9)
				.HasColumnName("season");
		});

		modelBuilder.Entity<Player>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PRIMARY");

			entity.HasIndex(e => e.TeamId, "team_id");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.Height)
				.HasPrecision(5, 2)
				.HasColumnName("height");
			entity.Property(e => e.Name)
				.HasMaxLength(100)
				.HasColumnName("name");
			entity.Property(e => e.Number).HasColumnName("number");
			entity.Property(e => e.TeamId).HasColumnName("team_id");
			entity.Property(e => e.Weight)
				.HasPrecision(5, 2)
				.HasColumnName("weight");

			entity.HasOne(d => d.Team).WithMany(p => p.Players)
				.HasForeignKey(d => d.TeamId)
				.HasConstraintName("Players_ibfk_1");
		});

		modelBuilder.Entity<PlayerStat>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PRIMARY");

			entity.HasIndex(e => e.PlayerId, "player_id");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.Assists)
				.HasDefaultValueSql("'0'")
				.HasColumnName("assists");
			entity.Property(e => e.Goals)
				.HasDefaultValueSql("'0'")
				.HasColumnName("goals");
			entity.Property(e => e.MatchesPlayed)
				.HasDefaultValueSql("'0'")
				.HasColumnName("matches_played");
			entity.Property(e => e.PlayerId).HasColumnName("player_id");

			entity.HasOne(d => d.Player).WithMany(p => p.PlayerStats)
				.HasForeignKey(d => d.PlayerId)
				.HasConstraintName("PlayerStats_ibfk_1");
		});

		modelBuilder.Entity<Team>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PRIMARY");

			entity.HasIndex(e => e.LeagueId, "league_id");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.LeagueId).HasColumnName("league_id");
			entity.Property(e => e.Name)
				.HasMaxLength(100)
				.HasColumnName("name");

			entity.HasOne(d => d.League).WithMany(p => p.Teams)
				.HasForeignKey(d => d.LeagueId)
				.HasConstraintName("Teams_ibfk_1");
		});

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
