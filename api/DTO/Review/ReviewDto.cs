namespace api.DTO.Review;

public class ReviewDto
{
    public long ID { get; set; }
    public int RatingValue { get; set; }
    public string? Comment { get; set; }
    public DateTime ReviewDate { get; set; }
    public string? StudentID { get; set; }
    public long? CourseID { get; set; }
}
