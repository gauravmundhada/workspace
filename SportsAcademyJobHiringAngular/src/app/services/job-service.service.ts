import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { JobPosition } from '../models/job-position';

@Injectable({
  providedIn: 'root'
})
export class JobServiceService {

  constructor(private http: HttpClient) { }
  private url="https://8080-dbfddbbbfbdfefabcaaaceeafebecebbffdafdefabcc.premiumproject.examly.io/api/job"

  getJobPostings(): Observable<any>
  {
    return this.http.get<any>(this.url + "/positions");
  }

  getJobApplications(): Observable<any>
  {
    return this.http.get<any>(this.url + "/applications");
  }

  getPositionTitles(): Observable<any>
  {
    return this.http.get<any>(this.url + "/position_title");
  }

  createJobPosition(createJobRequest: JobPosition): Observable<JobPosition>
  {
    return this.http.post<JobPosition>(this.url + "/position/add", createJobRequest);
  }

  
}
