import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { HttpClientModule } from "@angular/common/http";
import { HttpHeaders } from "@angular/common/http";

@Injectable({
    providedIn:'root'
})

export class ApiConnect{
    constructor(private http:HttpClient){

    }

    //To create row
    SaveData(data:any){
        let responseData:any="";
        let httpHeaders:HttpHeaders = new HttpHeaders({
            Accept:'application/json'
        })
        this.http.post("",data,{headers:httpHeaders})
        .subscribe(res=>{
            responseData=res;
        },
        err=>{
            responseData = err;
        })
        return responseData;
    }

    // To update row
    UpdateData(id:number,data:any){
        let responseData:any = "";
        
    }

    // To delete row
    DeleteData(id:number){

    }

    // To fetch a list
    GetData(){

    }
}