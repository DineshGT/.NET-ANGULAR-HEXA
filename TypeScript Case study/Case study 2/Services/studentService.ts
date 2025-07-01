import { category, course, status } from "../Models/enum";



export class studentService 
{

   name: string;
  age: number;
  courseName: course;
  knowsHTML: boolean;
  category : category;
  status : status;

  constructor(name: string, age: number, courseName:course, KnowsHTML: boolean) {
    this.name = name;
    this.age = age;
    this.courseName = courseName;
    this.knowsHTML = KnowsHTML;
    this.category = this.findCategory();
    this.status = this.findStatus();
  }


  private findCategory(): category
   {
    
    let stdcategory:category

    switch (this.courseName) {
      case course.Angular:
        stdcategory = category.Frontend;
        break;
      case course.Fullstack:
        stdcategory = category.Both;
        break;
      case course.Nodejs:
        stdcategory = category.Backend;
        break;
    }

    return stdcategory;
    
  }

  
private findStatus(): status {
  if (this.age < 18) {
    return status.noteligible;
  }

  if (this.courseName === course.Angular && !this.knowsHTML) {
    return status.noteligible;
  }

  return status.eligible;
}

  
  public displayDetails(): void {
      console.log(`Student Name: ${this.name}`);
      console.log(`Age: ${this.age}`);
      console.log(`Course: ${this.courseName}`);
      console.log(`Knows HTML: ${this.knowsHTML}`);
      console.log(`Course Category: ${this.category}`);
      console.log(`Enrollement Status: ${this.status}`);
      console.log('------------------------');
    }
    



}