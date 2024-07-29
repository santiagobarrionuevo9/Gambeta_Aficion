using AutoMapper;
using Gambeta_Aficion.Dtos;
using Gambeta_Aficion.Models;
using Gambeta_Aficion.Repositories.Interfaz;
using Gambeta_Aficion.Services.Interfaz;

namespace Gambeta_Aficion.Services.Impl
{
	public class PlayerService : IPlayerService
	{
		private readonly IPlayerRepository _playerRepository;
		private readonly IMapper _mapper;

		public PlayerService(IPlayerRepository playerRepository, IMapper mapper)
		{
			_playerRepository = playerRepository;
			_mapper = mapper;
		}

		public async Task<List<PlayerDTO>> GetAllPlayersAsync()
		{
			var players = await _playerRepository.GetAllPlayersAsync();
			return _mapper.Map<List<PlayerDTO>>(players);
		}

		public async Task<PlayerDTO> GetPlayerByIdAsync(int id)
		{
			var player = await _playerRepository.GetPlayerByIdAsync(id);
			return _mapper.Map<PlayerDTO>(player);
		}

		public async Task AddPlayerAsync(PlayerDTO playerDto)
		{
			var player = new Player
			{
				Name = playerDto.Name,
				Height = playerDto.Height,
				Weight = playerDto.Weight,
				Number = playerDto.Number,
				TeamId = playerDto.TeamId
			};

			await _playerRepository.AddPlayerAsync(player);
		}

		public async Task UpdatePlayerAsync(PlayerDTO playerDto)
		{
			var player = _mapper.Map<Player>(playerDto);
			await _playerRepository.UpdatePlayerAsync(player);
		}

		public async Task DeletePlayerAsync(int id)
		{
			await _playerRepository.DeletePlayerAsync(id);
		}
	}
}
