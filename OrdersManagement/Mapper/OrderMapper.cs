using Mapster;
using OrderManagement.Core.Entities;
using OrderManagement.Core.Models;

namespace OrdersManagement.Mapper
{
    public class OrderMapper:IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            TypeAdapterConfig<OrderDto, Order>.NewConfig().TwoWays()
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest=>dest.UserId,src=>src.UserId)
                .Map(dest => dest.Id, src => src.Id);

        }
    }
}
