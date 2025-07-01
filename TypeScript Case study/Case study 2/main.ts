import { course } from "./Models/enum";
import { studentService } from "./Services/studentService";


const std1 = new studentService("Dinesh", 21, course.Angular, true);
const std2 = new studentService("Arun", 22, course.Nodejs, false);
const std3 = new studentService("Mathew", 17, course.Angular, false);


std1.displayDetails();
std2.displayDetails();
std3.displayDetails();

