using api.DTO.Review;
using api.Interface;
using api.Mapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api;
[ApiController]
[Route("api/review")]
public class ReviewController : ControllerBase
{
    private readonly IReviewRepository _reviewRepo;

    public ReviewController(IReviewRepository reviewRepository)
    {
        _reviewRepo = reviewRepository;
    }
    [HttpGet]
    [Route("{courseId}")]
    public async Task<IActionResult> GetAll([FromRoute] long courseId, [FromQuery] int pageNumber = 1)
    {
        var reviews = await _reviewRepo.GetAllAsync(courseId, pageNumber);
        var reviewsDto = reviews.Select(r => r.ToReviewDto());
        return Ok(reviewsDto);
    }

    [HttpGet]
    [Authorize]

    public async Task<IActionResult> GetUserReviews()
    {
        var reviews = await _reviewRepo.GetUserReviewsAsync();
        var reviewsDto = reviews.Select(r => r.ToReviewDto());

        return Ok(reviewsDto);
    }

    [HttpPost("{courseId}")]
    // [Route("courseId:long")]
    [Authorize]
    public async Task<IActionResult> PostUserReviews([FromRoute] long courseId, [FromBody] CreateReviewRequestDto dto)
    {
        await _reviewRepo.AddAsync(courseId, dto.ToCreateReviewRequestDto());
        return Ok(dto);
    }

    [HttpPut("{courseId}")]
    [Authorize]
    public async Task<IActionResult> UpdateUserReview([FromRoute] long courseId, [FromBody] UpdateReviewRequestDto dto)
    {
        var review = await _reviewRepo.UpdateAsync(courseId, dto);
        return Ok(review.ToReviewDto());
    }

    [Authorize]
    [HttpDelete("{reviewId}")]
    public async Task<IActionResult> DeleteUserReview([FromRoute] long reviewId)
    {
        var review = await _reviewRepo.DeleteAsync(reviewId);
        if (review == null) return NotFound();
        return NoContent();
    }

}
