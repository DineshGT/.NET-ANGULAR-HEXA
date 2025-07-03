import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CourseCatalog } from './course-catalog/course-catalog';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, CourseCatalog],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected title = 'course-catalog';
}
