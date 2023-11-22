import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EmployeesService } from 'src/app/services/employees.service';
import { Employee } from 'src/app/model/employee.model';

@Component({
  selector: 'app-edit-employee',
  templateUrl: './edit-employee.component.html',
  styleUrls: ['./edit-employee.component.css']
})
export class EditEmployeeComponent implements OnInit {

  employeeDetails: Employee ={
    id: '',
    name: '',
    email: '',
    phone: 0,
    salary: 0, 
    department:''
  }
  
  constructor(private route:ActivatedRoute,  private employeeService: EmployeesService) { }

  ngOnInit() {
    this.route.paramMap.subscribe({
      next: (params) =>{
        const id = params.get('id');

        if(id)
        {
          // call api
          this.employeeService.getEmployee(id)
          .subscribe({
            next: (response)=>{
              this.employeeDetails = response;
            }
          });
        }
      }
    })
  }

}
