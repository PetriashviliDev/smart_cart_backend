using Mapster;
using SmartCardBackend.Application.Responses;
using SmartCardBackend.Application.Services.Identity;
using SmartCardBackend.Domain.Entities;

namespace SmartCardBackend.Application.Mapping;

public class UserMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<User, UserContext>()
            .Map(dest => dest.PreferenceDishes, src => 
                config.GetMapFunction<List<UserPreference>, List<PreferenceDishDto>>()
                    .Invoke(src.Preferences))
            .AfterMapping((_, dest) =>
            {
                using var scope = config.BuildAdapter().CreateMapContextScope();
                var identityService = scope.Context.GetService<IIdentityService>();
                
                dest.IpAddress = identityService.GetIpAddress();
                dest.UserAgent = identityService.GetUserAgent();
            });
        
        config.NewConfig<UserAllergy, Pair<int>>()
            .Map(dest => dest.Id, src => src.Allergy.Id, src => src.Allergy != null)
            .Map(dest => dest.Title, src => src.Allergy.Title, src => src.Allergy != null);
        
        config.NewConfig<UserPreference, PreferenceDishDto>()
            .Map(dest => dest.Id, src => src.Dish.Id, src => src.Dish != null)
            .Map(dest => dest.Title, src => src.Dish.Title, src => src.Dish != null)
            .Map(dest => dest.MealTypeId, src => src.Dish.MealTypeId, src => src.Dish != null);
        
        config.NewConfig<ActivityLevel, Pair<int>>()
            .Map(dest => dest.Id, src => src.Id, src => src != null)
            .Map(dest => dest.Title, src => src.Title, src => src != null);
    }
}