import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Forms } from './forms/forms';
import { FormsModule } from '@angular/forms';


@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Forms, FormsModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected title = 'forms-app';
}
