import { category, deptartments } from "./dept.levels.enum";

export interface employee
{
    name: string,
    age: number,
    dept: deptartments,
    baseSalary: number,
    netSalary: number,
    category: category
    

}