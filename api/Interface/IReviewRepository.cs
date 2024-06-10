using api.Model;

namespace api.Interface;

public interface IReviewRepository
{
    Task<List<Review>> GetAllAsync(long courseId, int pageNumber);
    Task<List<Review>?> GetUserReviewsAsync();
    Task<Review> AddAsync(long courseId, Review review);
    Task<Review?> UpdateAsync(long courseId, UpdateReviewRequestDto dto);
    Task<Review?> DeleteAsync(long reviewId);
}
