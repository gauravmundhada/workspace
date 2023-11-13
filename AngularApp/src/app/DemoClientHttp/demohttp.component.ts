import { HttpClient } from "@angular/common/http";
import { Component } from "@angular/core";

@Component ({
    selector:'http-client',
    template:'<h1> This is httpclient </h1>'
})

export class HttpDemo{
    _http:HttpClient = null;
    constructor(http:HttpClient){
        this._http = http;
        this._http.get("https://8080-dbfddbbbfbdfefabcaaaceeafebeccaddbefddaf.premiumproject.examly.io/WeatherForecast").subscribe((data)=>{
            console.log(data);
        },
        (failure)=>{
            console.log(failure);
        });
        
    }
}