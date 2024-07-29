using Gambeta_Aficion.Models;
using Gambeta_Aficion.Repositories.Interfaz;
using Microsoft.EntityFrameworkCore;
using Gambeta_Aficion.ContextDb;

namespace Gambeta_Aficion.Repositories.Impl
{
	public class PlayerRepository: IPlayerRepository
	{
		private readonly AppDbContextG _context;

		public PlayerRepository(AppDbContextG context)
		{
			_context = context;
		}

		public async Task<List<Player>> GetAllPlayersAsync()
		{
			return await _context.Players.ToListAsync();
		}

		public async Task<Player> GetPlayerByIdAsync(int id)
		{
			return await _context.Players.FindAsync(id);
		}

		public async Task AddPlayerAsync(Player player)
		{
			await _context.Players.AddAsync(player);
			await _context.SaveChangesAsync();
		}

		public async Task UpdatePlayerAsync(Player player)
		{
			_context.Players.Update(player);
			await _context.SaveChangesAsync();
		}

		public async Task DeletePlayerAsync(int id)
		{
			var player = await _context.Players.FindAsync(id);
			if (player != null)
			{
				_context.Players.Remove(player);
				await _context.SaveChangesAsync();
			}
		}
	}
}
