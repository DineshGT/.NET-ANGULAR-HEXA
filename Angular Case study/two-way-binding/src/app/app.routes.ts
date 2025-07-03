import { Routes } from '@angular/router';
import { Home } from './commonfolder/home/home';
import { StudentFeedback } from './commonfolder/student-feedback/student-feedback';



export const routes: Routes = [

    {path: '', component: Home},
    {path: 'student', component:StudentFeedback}
];
