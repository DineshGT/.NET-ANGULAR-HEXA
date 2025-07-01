import { category, course, status } from "./enum";

export interface student
{
    name: string,
    age: number,
    courseName : course,
    knowsHTML : Boolean
    courseCategory : category,
    enrollementStatus : status
}