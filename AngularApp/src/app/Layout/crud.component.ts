import { Component } from "@angular/core";


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
        let data:any = event.target.value;
        switch (ids) 
        {
            case "emId":
            this.indiData={...this.indiData,email:data};    
            break;
            case "psId":
            this.indiData={...this.indiData,password:data};
            break;
            case "chId":
                let chkVal = event.target.checked
            this.indiData={...this.indiData,isReady:data};
            break;
            case "btn1":
                //console.log(this.indiData);
                this.userData.push(this.indiData);
                //console.log(this.userData);
            
            break;
            case "upbtn":
                let value = this.userData.find(x=>x.email == this.indiData.email);
                console.log(value);
                this.userData.push(this.indiData);

            default:
                break;

        }
        console.log(event.target.id);     
    }
}