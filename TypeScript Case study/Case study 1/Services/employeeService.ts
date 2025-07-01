import { deptartments } from "../Models/dept.levels.enum";
import { employee } from "../Models/emp.models";
import { category } from "../Models/dept.levels.enum";


export class employeeService 
{

   name: string;
  age: number;
  department: deptartments;
  baseSalary: number;
  netSalary: number;
  category: category;

  constructor(name: string, age: number, department: deptartments, baseSalary: number) {
    this.name = name;
    this.age = age;
    this.department = department;
    this.baseSalary = baseSalary;
    this.netSalary = this.calculateNetSalary();
    this.category = this.categorizeEmployee();
  }


  private calculateNetSalary(): number {
    let bonusPercentage = 0;

    switch (this.department) {
      case deptartments.HR:
        bonusPercentage = 0.10;
        break;
      case deptartments.IT:
        bonusPercentage = 0.15;
        break;
      case deptartments.Sales:
        bonusPercentage = 0.12;
        break;
    }

    return this.baseSalary + this.baseSalary * bonusPercentage;
  }

  private categorizeEmployee(): category {
    if (this.netSalary >= 80000) {
      return category.HighEarner;
    } else if (this.netSalary >= 50000) {
      return category.MidEarner;
    } else {
      return category.LowEarner;
    }
  }

  
  public displayDetails(): void {
      console.log(`Employee Name: ${this.name}`);
      console.log(`Age: ${this.age}`);
      console.log(`Department: ${this.department}`);
      console.log(`Base Salary: ₹${this.baseSalary}`);
      console.log(`Net Salary (with bonus): ₹${this.netSalary}`);
      console.log(`Category: ${this.category}`);
      console.log('------------------------');
    }
    



}