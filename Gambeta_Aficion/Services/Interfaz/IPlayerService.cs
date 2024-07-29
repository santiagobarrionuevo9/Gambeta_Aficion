using Gambeta_Aficion.Dtos;

namespace Gambeta_Aficion.Services.Interfaz
{
	public interface IPlayerService
	{
		Task<List<PlayerDTO>> GetAllPlayersAsync();
		Task<PlayerDTO> GetPlayerByIdAsync(int id);
		Task AddPlayerAsync(PlayerDTO playerDto);
		Task UpdatePlayerAsync(PlayerDTO playerDto);
		Task DeletePlayerAsync(int id);
	}
}
