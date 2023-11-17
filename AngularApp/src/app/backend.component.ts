import { Component } from "@angular/core";
import { ApiConnect } from "./BackEndConnect/backend.service";

@Component({
    selector:'crud',
    templateUrl:'./backend.component.html' 
})

export class CRUD{

    constructor(private http:ApiConnect){

    }
    nme:string="";
    location:string="";
    age:number = 0;

    handleSave(){
        let data:object= {nme:this.nme, location:this.location,age:this.age}
        console.log(this.http.SaveData());
    }

}