import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

export class Employee{
  constructor(
    public firstName: string,
    public lastName: string,
    public birthDate: Date,
    public gender: string,
    public hireDate: Date,
    public title: string,
    public salary: number
  ){
  }
}

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  employees: Employee[]
  constructor(private client: HttpClient) { }

  getEmployees(){
    this.client.get<any>("http://localhost:64803/api/employee").subscribe(
      response => {
        this.employees = response;
        console.log(response);
        console.log(this.employees);
      },
      (err)=>console.log(err)
    );
  }
}
