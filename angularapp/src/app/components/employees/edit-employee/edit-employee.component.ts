import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-edit-employee',
  templateUrl: './edit-employee.component.html',
  styleUrls: ['./edit-employee.component.css']
})
export class EditEmployeeComponent implements OnInit {

  constructor(private route:ActivatedRoute) { }

  ngOnInit() {
    this.route.paramMap.subscribe({
      next: (params) =>{
        const id = params.get('id');

        if(id)
        {
          // call api
        }
      }
    })
  }

}
