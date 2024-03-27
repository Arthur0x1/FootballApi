using AutoMapper;
using FootballApi.Domains.Entities;
using FootballApi.Services.Interfaces;
using FootballApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FootballApi.Controllers.Api
{
	[ApiController]
	[Route("api/[controller]")]
	public class PlayerController : ControllerBase
	{
		private readonly IService<Player> _playerService;
		private readonly IMapper _mapper;

		public PlayerController(IService<Player> playerService, IMapper mapper)
		{
			_playerService = playerService;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<ActionResult<PlayerVm>> Get()
		{
			try
			{
				var players = await _playerService.GetAll();
				if (players is null) return NotFound();

				var playerVms = _mapper.Map<List<PlayerVm>>(players);
				return Ok(playerVms);
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { error = ex.Message });
			}
		}

		[HttpGet("{id:int}")]
		public async Task<ActionResult<PlayerVm>> Get(int id)
		{
			try
			{
				var player = await _playerService.FindById(id);
				if (player is null) return NotFound();

				var playerVm = _mapper.Map<PlayerVm>(player);
				return Ok(playerVm);
			}
			catch (Exception)
			{
				return StatusCode(500, new
				{
					error = "Er is een interne fout opgetreden.Neem contact op met de beheerder voor assistentie."
				});
			}
		}

		[HttpPost]
		public async Task<ActionResult<PlayerVm>> Post([FromForm] PlayerPostVm vm)
		{
			try
			{
				var player = _mapper.Map<Player>(vm);
				await _playerService.Add(player);
				return CreatedAtAction(nameof(Post), new { id = player.Id });
			}
			catch (Exception ex)
			{
				await Console.Error.WriteLineAsync(ex.Message);
				return BadRequest();
			}
		}
	}
}
