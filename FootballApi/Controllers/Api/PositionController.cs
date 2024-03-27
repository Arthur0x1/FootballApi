using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace FootballApi.Controllers.Api
{
	[ApiController]
	[Route("api/[controller]")]
	public class PositionController : ControllerBase
	{
		private readonly IMapper _mapper;

        public PositionController(IMapper mapper)
        {
			_mapper = mapper;
        }
    }
}
