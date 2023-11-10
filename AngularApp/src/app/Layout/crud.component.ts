import { Component } from "@angular/core";
import { Console } from "console";

@Component({
    selector: "crud",
    templateUrl:'./crud.component.html'
})

export class Crud
{
    userData:object[]=[{}];
    dataHandler(event)
    {
        ids:String = event.target.value;
        switch (event)
        console.log(event.target.id);     
    }
}