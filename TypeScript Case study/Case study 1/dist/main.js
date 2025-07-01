"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const dept_levels_enum_1 = require("./Models/dept.levels.enum");
const employeeService_1 = require("./Services/employeeService");
const emp = new employeeService_1.employeeService("Dinesh", 21, dept_levels_enum_1.deptartments.HR, 12000);
emp.displayDetails;
