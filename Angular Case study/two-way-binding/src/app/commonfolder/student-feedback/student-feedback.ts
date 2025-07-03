import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { students } from '../../models/student-interface';

@Component({
  selector: 'app-student-feedback',
  imports: [CommonModule, FormsModule],
  templateUrl: './student-feedback.html',
  styleUrl: './student-feedback.css'
})


export class StudentFeedback {
  feedback: students = {
    studentName: '',
    courseName: '',
    rating: 1,
    comments: ''
  };
  courses: string[] = ['Angular', 'React', 'Vue', 'Node.js'];
}
