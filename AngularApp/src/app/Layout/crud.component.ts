import { Component } from "@angular/core";
import { Console } from "console";

@Component({
    selector: "crud",
    templateUrl:'./crud.component.html'
})

export class Crud
{
    
    indiData:object={email:" ",password:" ",isReady:false};
    userData:object[]=[{}];
    dataHandler(event)
    {
        let ids:String = event.target.id;
        let data:any = event.target.values;
        switch (ids) 
        {
            case "emId":
            this.indiData.email=data;    
            break;
            case "psId":
            this.indiData.password=data;
            break;
            case "chId":
            this.indiData.isReady=data;
            break;
            case "btn1":
                console.log(this.indiData);
                this.userData.push(indiData);
            break;
            default:
                break;

        }
        //console.log(event.target.id);     
    }
}