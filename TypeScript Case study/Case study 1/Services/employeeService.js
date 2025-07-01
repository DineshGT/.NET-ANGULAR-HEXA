"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.employeeService = void 0;
const dept_levels_enum_1 = require("../Models/dept.levels.enum");
const dept_levels_enum_2 = require("../Models/dept.levels.enum");
class employeeService {
    constructor(name, age, department, baseSalary) {
        this.name = name;
        this.age = age;
        this.department = department;
        this.baseSalary = baseSalary;
        this.netSalary = this.calculateNetSalary();
        this.category = this.categorizeEmployee();
    }
    calculateNetSalary() {
        let bonusPercentage = 0;
        switch (this.department) {
            case dept_levels_enum_1.deptartments.HR:
                bonusPercentage = 0.10;
                break;
            case dept_levels_enum_1.deptartments.IT:
                bonusPercentage = 0.15;
                break;
            case dept_levels_enum_1.deptartments.Sales:
                bonusPercentage = 0.12;
                break;
        }
        return this.baseSalary + this.baseSalary * bonusPercentage;
    }
    categorizeEmployee() {
        if (this.netSalary >= 80000) {
            return dept_levels_enum_2.category.HighEarner;
        }
        else if (this.netSalary >= 50000) {
            return dept_levels_enum_2.category.MidEarner;
        }
        else {
            return dept_levels_enum_2.category.LowEarner;
        }
    }
    displayDetails() {
        console.log(`Employee Name: ${this.name}`);
        console.log(`Age: ${this.age}`);
        console.log(`Department: ${this.department}`);
        console.log(`Base Salary: ₹${this.baseSalary}`);
        console.log(`Net Salary (with bonus): ₹${this.netSalary}`);
        console.log(`Category: ${this.category}`);
        console.log('------------------------');
    }
}
exports.employeeService = employeeService;
