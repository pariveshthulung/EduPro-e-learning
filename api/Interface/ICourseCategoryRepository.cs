﻿using api.Model;

namespace api.Interface;

public interface ICourseCategoryRepository
{
    Task<CourseCategory> GetAllAsync();
    Task<CourseCategory?> GetByIdAsync();
    Task<List<CourseCategory>> AddAsync(long courseID, List<long> categoryIDs);
    Task<CourseCategory?> Update();
    Task<CourseCategory?> Delete();
}
