import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HelloWorldService } from '../ServiceUtilities/helloworld.service';

@Component({
  selector: 'app-route-component',
  template: `<h1>Welcome to Salonga</h1>`,
  styleUrls: ['./route-component.component.css']
})
export class RouteComponentComponent  {

  constructor(private route:Router, private hello:HelloWorldService) { }

  handleRoute() {
    this.hello.sayHelloWorld();
    this.route.navigate(["/form",23]);
  }

}
