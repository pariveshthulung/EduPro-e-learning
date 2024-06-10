
using api.DTO.CartItem;
using api.Model;

namespace api.Mapper;

public static class CartItemMapper
{
    public static CartItemDto ToCartDto(this CartItem cart)
    {
        return new CartItemDto
        {
            ID = cart.ID,
            CartID = cart.CartID,
            CourseID = cart.CourseID,
        };
    }
    public static CartItem ToCreateCartItemRequestDto(this CreateCartItemRequestDto dto)
    {
        return new CartItem
        {
            CartID = dto.CartID,
            CourseID = dto.CourseID,
        };
    }
}
