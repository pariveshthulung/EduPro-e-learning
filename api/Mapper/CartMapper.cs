using System.Reflection.Metadata.Ecma335;
using api.DTO.Cart;
using api.Model;

namespace api.Mapper;

public static class CartMapper
{
    public static CartDto ToCartDto(this Cart cart)
    {
        return new CartDto
        {
            ID = cart.ID,
            StudentID = cart.StudentID,
            CourseID = cart.CourseID,
        };
    }
    public static Cart ToCreateCartRequestDto(this CreateCartRequestDto dto)
    {
        return new Cart
        {
            StudentID = dto.StudentID,
            CourseID = dto.CourseID,
        };
    }
}
