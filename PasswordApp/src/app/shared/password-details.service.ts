import { Injectable } from '@angular/core';
import { PasswordDetails } from './password-details.model';
import { HttpClient } from "@angular/common/http"

@Injectable({
  providedIn: 'root'
})
export class PasswordDetailsService {

  constructor(private http:HttpClient) { }

  formData:PasswordDetails = new PasswordDetails();
  list:PasswordDetails[];
  readonly baseUrl = 'http://localhost:53466/api/PasswordDetails';

  postPasswordDetails(){
    return this.http.post(this.baseUrl, this.formData);
  }

  putPasswordDetails(){
    return this.http.put(`${this.baseUrl}/${this.formData.passwordDetailsId}`, this.formData);
  }

  deletePasswordDetails(id:number){
    return this.http.delete(`${this.baseUrl}/${id}`);
  }

  refreshList(){
    this.http.get(this.baseUrl)
    .toPromise()
    .then(res => this.list = res as PasswordDetails[]);
  }
}
