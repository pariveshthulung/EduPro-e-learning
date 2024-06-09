using api.DTO.Wishlist;
using api.Model;

namespace api.Mapper;

public static class WishlistMapper
{
    public static WishlistDto ToWishlistDto(this Wishlist wishlist)
    {
        return new WishlistDto
        {
            ID = wishlist.ID,
            StudentID = wishlist.StudentID,
            CourseID = wishlist.CourseID,
        };
    }

    public static Wishlist ToCreateWishlistDto(this CreateWishlistRequestDto dto)
    {
        return new Wishlist
        {
            StudentID = dto.StudentID,
            CourseID = dto.CourseID,
        };
    }
}
