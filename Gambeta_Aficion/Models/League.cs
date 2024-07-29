namespace Gambeta_Aficion.Models;

public partial class League
{
	public int Id { get; set; }

	public string Name { get; set; } = null!;

	public string? Country { get; set; }

	public string? Season { get; set; }

	public virtual ICollection<Team> Teams { get; set; } = new List<Team>();
}
