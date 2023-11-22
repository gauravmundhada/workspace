import { HttpClient,HttpHeaders} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from '../model/employee.model';

@Injectable({
  providedIn: 'root'
})
export class EmployeesService {

  url="https://8080-dbfddbbbfbdfefabcaaaceeafebecebbffdafdefabcc.premiumproject.examly.io"
  constructor(private http: HttpClient) { }

  getAllEmployees():Observable<Employee[]>
  {
    return this.http.get<Employee[]>(this.url + '/api/Employee'); 
  }

  addEmployee(addEmployeeRequest:Employee):Observable<Employee>
  {
    return this.http.post<Employee>(this.url + '/api/Employee', addEmployeeRequest);
  }
}
