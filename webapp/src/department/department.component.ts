import { Component, OnInit } from '@angular/core';
import { Department, DepartmentService } from '../services/department.service';

@Component({
  selector: 'app-department',
  templateUrl: './department.component.html',
  styleUrls: ['./department.component.css']
})
export class DepartmentComponent implements OnInit {

  title = "Departments";
  constructor(public service: DepartmentService) { }

  ngOnInit() {
    this.service.getDepartments();
  }

  updateManager(selectedId: Department){
  }

}
