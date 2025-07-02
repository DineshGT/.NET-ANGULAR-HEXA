import { Component } from '@angular/core';
import { Student } from '../models/student.model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-student-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './student-list.html',
  styleUrls: ['./student-list.css']
})


export class StudentListComponent {
  students: Student[] = [
    { name: 'Alice', marks: 72, active: true },
    { name: 'Bob', marks: 45, active: false },
    { name: 'Charlie', marks: 88, active: true },
    { name: 'Daisy', marks: 39, active: true }
  ];
}
