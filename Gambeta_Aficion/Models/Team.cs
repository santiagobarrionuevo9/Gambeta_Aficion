namespace Gambeta_Aficion.Models;

public partial class Team
{
	public int Id { get; set; }

	public string Name { get; set; } = null!;

	public int? LeagueId { get; set; }

	public virtual League? League { get; set; }

	public virtual ICollection<Player> Players { get; set; } = new List<Player>();
}
