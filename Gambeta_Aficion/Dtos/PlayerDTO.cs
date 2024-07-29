namespace Gambeta_Aficion.Dtos
{
	public class PlayerDTO
	{
		public int? Id { get; set; }

		public string Name { get; set; } = null!;

		public decimal? Height { get; set; }

		public decimal? Weight { get; set; }

		public int? Number { get; set; }

		public int? TeamId { get; set; }

	}
}

