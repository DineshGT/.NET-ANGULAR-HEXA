import { Component } from '@angular/core';
import { StudentListComponent } from './student-list/student-list';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [StudentListComponent],
  templateUrl: './app.html'
})
export class AppComponent {}
