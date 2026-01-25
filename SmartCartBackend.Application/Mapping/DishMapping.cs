using Mapster;
using SmartCardBackend.Application.Responses;
using SmartCardBackend.Domain.Entities;

namespace SmartCardBackend.Application.Mapping;

public class DishMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Dish, Pair<int>>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Title, src => src.Title);
    }
}