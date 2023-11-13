import { Component } from "@angular/core";
import { NgForm } from "@angular/forms";

@Component({
    selector:'temp-form',
    templateUrl:'demo.templateform.html'

})

export class TempForm
{
    submitData(form:NgForm){
        console.log(form.value);
    }
}