using api.DTO.Category;
using api.Model;

namespace api.Mapper;

public static class CategoryMapper
{
    public static CategoryDto ToCategoryDto(this Category category)
    {
        return new CategoryDto
        {
            ID = category.ID,
            Name = category.Name,
        };
    }
}
