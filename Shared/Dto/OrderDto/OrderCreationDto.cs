using Shared.Dto.OrderProductDto;

namespace Shared.Dto.OrderDto;

public class OrderCreationDto
{
    public int UserId { get; set; }
    public DateTime OrderDate { get; set; } =  DateTime.UtcNow;
    public ICollection<OrderProductsCreationDto>  OrderProducts { get; set; } = new List<OrderProductsCreationDto>();
}