﻿using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Commands;
using CleanArch.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMediator _bus;

        public CourseService(ICourseRepository courseRepository, IMediator bus)
        {
            _courseRepository = courseRepository;  
            _bus = bus;
        }

        public void Create(CourseViewModel course)
        {
            var createCourseCommand = new CreateCourseCommand(course.Name, course.Description, course.ImageUrl);
            _bus.Send(createCourseCommand);
        }

        public CourseViewModel GetCourses()
        {
            return new CourseViewModel()
            {
                Courses = _courseRepository.GetCourses()
            }; 
        }
    }
}
