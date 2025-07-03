import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { StudentFeedback } from './commonfolder/student-feedback/student-feedback';

@Component({
  selector: 'app-root',
  imports: [StudentFeedback],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected title = 'two-way-binding';
}
