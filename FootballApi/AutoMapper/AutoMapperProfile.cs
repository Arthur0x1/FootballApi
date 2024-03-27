using AutoMapper;
using FootballApi.Domains.Entities;
using FootballApi.ViewModels;

namespace FootballApi.AutoMapper
{
	public class AutoMapperProfile : Profile
	{
        public AutoMapperProfile()
        {
            CreateMap<PlayerVm, Player>().ForMember(
                nameof(PlayerVm.Position),
                opts => opts.MapFrom(src => src.Position)
            );
            CreateMap<Player, PlayerVm>();

            CreateMap<Position, PositionVm>();
			CreateMap<PositionVm, Position>();
		}
    }
}
