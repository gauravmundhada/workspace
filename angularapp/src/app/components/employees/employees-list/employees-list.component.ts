import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/model/employee.model';

@Component({
  selector: 'app-employees-list',
  templateUrl: './employees-list.component.html',
  styleUrls: ['./employees-list.component.css']
})
export class EmployeesListComponent implements OnInit {

  employees:Employee[]= [{
    id: 'qaz123',
    name: 'Gaurav',
    email: 'gaurav@gmail.com',
    phone: 8530919002,
    salary: 67000,
    department: 'Banking'
  },
  {
    id: 'qaz124',
    name: 'Sarang',
    email: 'sarang@gmail.com',
    phone: 8600712770,
    salary: 500000,
    department: 'BusinessMan'    
  },
  {
    id: 'qaz125',
    name: 'Dinesh',
    email: 'dinesh@gmail.com',
    phone: 6585748545,
    salary: 3499999,
    department: 'Coder'  
  }];
  
  constructor() { }

  ngOnInit() {
  }

}