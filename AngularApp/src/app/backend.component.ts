import { Component } from "@angular/core";
import { ApiConnect } from "./BackEndConnect/backend.service";

@Component({
    selector:'crud2',
    templateUrl:'./backend.component.html' 
})

export class CRUD{

    constructor(private http:ApiConnect){

    }
    EmployeeName:string="";
    DepartmentId:number= 0;
    DesignationId:number = 0;
    Salary:number = 0;
    JoinDate:string="";


    handleSave(){
        let data:object= {EmployeeName:this.EmployeeName,DepartmentId:this.DepartmentId,DesignationId:this.DesignationId,Salary:this.Salary,JoinDate:this.JoinDate}
        console.log(this.http.SaveData(data));
    }

}