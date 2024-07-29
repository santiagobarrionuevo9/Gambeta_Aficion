namespace Gambeta_Aficion.Models;

public partial class PlayerStat
{
	public int Id { get; set; }

	public int? PlayerId { get; set; }

	public int? Goals { get; set; }

	public int? Assists { get; set; }

	public int? MatchesPlayed { get; set; }

	public virtual Player? Player { get; set; }
}
