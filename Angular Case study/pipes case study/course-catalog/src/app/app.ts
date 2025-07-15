import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CourseCatalog } from './course-catalog/course-catalog';
import { StudentCatalog } from './student-catalog/student-catalog';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, StudentCatalog, CourseCatalog],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected title ='student-catalog';
}
