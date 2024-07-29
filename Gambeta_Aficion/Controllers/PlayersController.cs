using Gambeta_Aficion.Dtos;
using Gambeta_Aficion.Services.Interfaz;
using Microsoft.AspNetCore.Mvc;

namespace Gambeta_Aficion.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PlayersController : ControllerBase
	{
		private readonly IPlayerService _playerService;
		public PlayersController(IPlayerService playerService)
		{
			_playerService = playerService;
		}

		[HttpGet]
		public async Task<ActionResult<List<PlayerDTO>>> GetPlayers()
		{
			var players = await _playerService.GetAllPlayersAsync();
			return Ok(players);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<PlayerDTO>> GetPlayer(int id)
		{
			var player = await _playerService.GetPlayerByIdAsync(id);
			if (player == null)
			{
				return NotFound();
			}
			return Ok(player);
		}

		[HttpPost]
		public async Task<ActionResult> PostPlayer(PlayerDTO playerDto)
		{
			await _playerService.AddPlayerAsync(playerDto);
			return CreatedAtAction(nameof(GetPlayer), new { id = playerDto.Id }, playerDto);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> PutPlayer(int id, PlayerDTO playerDto)
		{
			if (id != playerDto.Id)
			{
				return BadRequest();
			}

			await _playerService.UpdatePlayerAsync(playerDto);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeletePlayer(int id)
		{
			await _playerService.DeletePlayerAsync(id);
			return NoContent();
		}

	}
}
