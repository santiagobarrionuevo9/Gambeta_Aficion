using AutoMapper;
using Gambeta_Aficion.Dtos;
using Gambeta_Aficion.Models;

namespace Gambeta_Aficion.Mappers
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<Player, PlayerDTO>().ReverseMap();
		}
	}
}
