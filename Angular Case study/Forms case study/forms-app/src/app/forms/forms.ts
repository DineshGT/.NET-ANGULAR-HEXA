import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { UserRegistration } from '../models/form.model';


@Component({
  selector: 'app-forms',
  imports: [CommonModule, FormsModule],
  templateUrl: './forms.html',
  styleUrl: './forms.css'
})

export class Forms {

  user: UserRegistration = {
    fullName: '',
    email: '',
    gender: '',
    country: '',
    terms: false
  }

  submittedData: UserRegistration | null = null;

  onSubmit(form: any) {
    if (form.valid) {
      this.submittedData = { ...this.user };
    }
    else 
    {
      console.log("Not found");
    }
  }
}
