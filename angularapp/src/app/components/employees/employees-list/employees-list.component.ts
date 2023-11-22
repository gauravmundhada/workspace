import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/model/employee.model';
import { EmployeesService } from 'src/app/services/employees.service';

@Component({
  selector: 'app-employees-list',
  templateUrl: './employees-list.component.html',
  styleUrls: ['./employees-list.component.css']
})
export class EmployeesListComponent implements OnInit {

  employees:Employee[]= [];
  
  constructor(private employeeService: EmployeesService)
   { 
    this.employeeService.getAllEmployees().subscribe(data=>{this.employees=data})
    // console.log(this.employees)
  }

  ngOnInit(){
    
  }

}
