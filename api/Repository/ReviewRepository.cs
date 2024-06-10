using api.Data;
using api.Interface;
using api.Mapper;
using api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Repository;

public class ReviewRepository : IReviewRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IUserRepository _userRepository;

    public ReviewRepository(ApplicationDbContext context, IUserRepository userRepository)
    {
        _context = context;
        _userRepository = userRepository;
    }

    public async Task<Review> AddAsync(long courseId, Review review)
    {
        var userId = _userRepository.GetUserID();
        review.StudentID = userId;
        review.CourseID = courseId;
        var reviewFromDb = await _context.Reviews.Where(x => x.CourseID == review.CourseID && x.StudentID == userId).FirstOrDefaultAsync();
        if (reviewFromDb == null)
        {
            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync();
        }
        return review;
    }

    public async Task<Review?> DeleteAsync(long reviewId)
    {
        var review = await _context.Reviews.Where(x => x.ID == reviewId).FirstOrDefaultAsync();
        if (review == null) return null;
        _context.Reviews.Remove(review);
        await _context.SaveChangesAsync();
        return review;
    }

    public async Task<List<Review>> GetAllAsync(long courseId, [FromQuery] int pageNumber = 1)
    {
        // var comment = await _context.Reviews.ToListAsync()
        var pageSize = 10;
        var skipNumber = (pageNumber - 1) * pageSize;
        return await _context.Reviews.Where(x => x.CourseID == courseId).Skip(skipNumber).Take(pageSize).Include(x => x.User).ToListAsync();
    }

    public async Task<List<Review>?> GetUserReviewsAsync()
    {
        var userId = _userRepository.GetUserID();
        var userReview = await _context.Reviews.Where(x => x.StudentID == userId).ToListAsync();
        return userReview;
    }

    public async Task<Review?> UpdateAsync(long courseId, UpdateReviewRequestDto dto)
    {
        var userId = _userRepository.GetUserID();
        var reviewFromDb = await _context.Reviews.Where(x => x.CourseID == courseId && x.StudentID == userId).FirstOrDefaultAsync();
        if (reviewFromDb == null) return null;
        reviewFromDb.Comment = dto.Comment;
        reviewFromDb.RatingValue = dto.RatingValue;

        await _context.SaveChangesAsync();
        return reviewFromDb;

    }
}
