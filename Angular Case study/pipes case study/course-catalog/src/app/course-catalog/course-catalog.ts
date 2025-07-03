import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Course } from '../models/course';

@Component({
  selector: 'app-course-catalog',
  imports: [CommonModule],
  templateUrl: './course-catalog.html',
  styleUrl: './course-catalog.css'
})
export class CourseCatalog {
  courses: Course[] = [
    {
      id: 1,
      title: 'Angular Basics',
      instructor: 'John Doe',
      startDate: new Date('2025-07-10'),
      price: 199.99,
      description: 'Learn the basics of Angular including components, services, and routing.'
    },
    {
      id: 2,
      title: 'Advanced TypeScript',
      instructor: 'Jane Smith',
      startDate: new Date('2025-08-01'),
      price: 249.99,
      description: 'Deep dive into advanced TypeScript features and generics.'
    }
  ];
}
