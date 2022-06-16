using Mapster;
using OrderManagement.Core.Entities;
using OrderManagement.Core.Models;

namespace OrdersManagement.Mapper
{
    public class UserMapper : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            TypeAdapterConfig<UserDto, User>.NewConfig().TwoWays()
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Email, src => src.Email)
                .Map(dest => dest.Id, src => src.Id);

        }
    }
}
