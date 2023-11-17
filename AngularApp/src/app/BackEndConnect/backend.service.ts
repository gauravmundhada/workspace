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
        this.http.post("https://8080-dbfddbbbfbdfefabcaaaceeafebeccaddbefddaf.premiumproject.examly.io/api/Employee",data,{headers:httpHeaders})
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
        let httpHeaders:HttpHeaders = new HttpHeaders({
            Accept:'application/json'
        }) 
        this.http.put("https://8080-dbfddbbbfbdfefabcaaaceeafebeccaddbefddaf.premiumproject.examly.io/api/Employee",data,{headers:httpHeaders})
        .subscribe(success=>{
            responseData = success;
        }, error=>{
            responseData = error;
        })

    }

    // To delete row
    DeleteData(id:number){
        let responseData:any = "";
        let httpHeaders:HttpHeaders = new HttpHeaders({
            Accept:'application/json'
        })

        this.http.delete("https://8080-dbfddbbbfbdfefabcaaaceeafebeccaddbefddaf.premiumproject.examly.io/api/Employee"+id,{headers:httpHeaders})
        .subscribe(success=>{
            responseData = success;
        }, error=>{
            responseData = error;
        })
        return responseData;
    }

    // To fetch a list
    GetData(){
        let responseData:any = "";
        let httpHeaders:HttpHeaders = new HttpHeaders({
            Accept:'application/json'
        })  
        let listUserData:IUserData[] = [];
        this.http.get<IUserData[]>("https://8080-dbfddbbbfbdfefabcaaaceeafebeccaddbefddaf.premiumproject.examly.io/api/Employee",{headers:httpHeaders})
        .subscribe(success=>{
            listUserData = success;
        })
        return listUserData;
    }
}
export interface IUserData{
    username:string;
    password:string;
}