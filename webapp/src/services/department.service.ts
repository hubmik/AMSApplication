import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

export class Department{
  constructor(
    public id: number,
    public departmentName: string,
    public name: string
  ){
  }
}

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {

  departments: Department[];
  constructor(private client: HttpClient) { }

  getDepartments(){
    this.client.get<any>("http://localhost:64803/api/department").subscribe(
      response => {
        this.departments = response;
        console.log(this.departments);
      },
      (err)=>console.log(err)
    );
  }

  updateManager(data){
    return this.client.put("http://localhost:64803/api/department/UpdateManager", data);
  }
}
