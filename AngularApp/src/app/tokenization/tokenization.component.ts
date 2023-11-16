import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { error } from 'console';

@Component({
  selector: 'app-tokenization',
  templateUrl: './tokenization.component.html',
  styleUrls: ['./tokenization.component.css']
})
export class TokenizationComponent{

  constructor(private http:HttpClient)
  {
    let httpHeaders:HttpHeaders = new HttpHeaders({
      Accept:'application/json'
    });
    this.http.post<Idata>("URL",
    {name:'user1', password:'password1'},
    {headers:httpHeaders})
    .subscribe(token=>
      {console.log(token);},
      error=>{
        console.log(error);
      })    
  }
}
interface Idata
{
  name:string
  password:string
}