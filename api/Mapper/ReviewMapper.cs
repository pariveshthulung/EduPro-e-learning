using api.DTO.Review;
using api.Model;

namespace api.Mapper;

public static class ReviewMapper
{
    public static ReviewDto ToReviewDto(this Review review)
    {
        return new ReviewDto
        {
            ID = review.ID,
            RatingValue = review.RatingValue,
            Comment = review.Comment,
            StudentID = review.StudentID,
            CourseID = review.CourseID,
            ReviewDate = review.ReviewDate,
        };
    }

    public static Review ToCreateReviewRequestDto(this CreateReviewRequestDto dto)
    {
        return new Review
        {
            RatingValue = dto.RatingValue,
            Comment = dto.Comment,
            // StudentID = dto.StudentID,
            // CourseID = dto.CourseID,
            ReviewDate = DateTime.Now,
        };
    }
}
