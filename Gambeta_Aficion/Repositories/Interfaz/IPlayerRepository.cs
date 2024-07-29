using Gambeta_Aficion.Models;

namespace Gambeta_Aficion.Repositories.Interfaz
{
	public interface IPlayerRepository
	{
		Task<List<Player>> GetAllPlayersAsync();
		Task<Player> GetPlayerByIdAsync(int id);
		Task AddPlayerAsync(Player player);
		Task UpdatePlayerAsync(Player player);
		Task DeletePlayerAsync(int id);
	}
}
