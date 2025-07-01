"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.studentService = void 0;
const enum_1 = require("../Models/enum");
class studentService {
    constructor(name, age, courseName, KnowsHTML) {
        this.name = name;
        this.age = age;
        this.courseName = courseName;
        this.knowsHTML = KnowsHTML;
        this.category = this.findCategory();
        this.status = this.findStatus();
    }
    findCategory() {
        let stdcategory;
        switch (this.courseName) {
            case enum_1.course.Angular:
                stdcategory = enum_1.category.Frontend;
                break;
            case enum_1.course.Fullstack:
                stdcategory = enum_1.category.Both;
                break;
            case enum_1.course.Nodejs:
                stdcategory = enum_1.category.Backend;
                break;
        }
        return stdcategory;
    }
    findStatus() {
        if (this.age < 18) {
            return enum_1.status.noteligible;
        }
        if (this.courseName === enum_1.course.Angular && !this.knowsHTML) {
            return enum_1.status.noteligible;
        }
        return enum_1.status.eligible;
    }
    displayDetails() {
        console.log(`Student Name: ${this.name}`);
        console.log(`Age: ${this.age}`);
        console.log(`Course: ${this.courseName}`);
        console.log(`Knows HTML: ${this.knowsHTML}`);
        console.log(`Course Category: ${this.category}`);
        console.log(`Enrollement Status: ${this.status}`);
        console.log('------------------------');
    }
}
exports.studentService = studentService;
