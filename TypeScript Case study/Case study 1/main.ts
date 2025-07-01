import { deptartments } from "./Models/dept.levels.enum";
import { employeeService } from "./Services/employeeService";

const emp = new employeeService("Dinesh", 21, deptartments.HR, 12000);

emp.displayDetails();

