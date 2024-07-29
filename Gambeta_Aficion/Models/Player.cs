namespace Gambeta_Aficion.Models;

public partial class Player
{
	public int Id { get; set; }

	public string Name { get; set; } = null!;

	public decimal? Height { get; set; }

	public decimal? Weight { get; set; }

	public int? Number { get; set; }

	public int? TeamId { get; set; }

	public virtual ICollection<PlayerStat> PlayerStats { get; set; } = new List<PlayerStat>();

	public virtual Team? Team { get; set; }
}
