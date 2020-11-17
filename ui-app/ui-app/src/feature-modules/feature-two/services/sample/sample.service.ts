import { environment } from './../../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SampleService {

  apiBaseUrl;

  constructor(private http: HttpClient) {
    this.apiBaseUrl = environment.apiBaseUrl + 'medicine';
   }

  getAllMedicinesData() : Observable<any> {
    const url = this.apiBaseUrl + '/all';
    return this.http.get(url);
  }

  getMedicineById(id: number): Observable<any> {
    const url = this.apiBaseUrl + '/' + id;
    return this.http.get(url);
  }

  addMedicine(medicine: object): Observable<any> {
    const url = this.apiBaseUrl;
    return this.http.post(url, medicine);
  }

  updateMedicine(id: number, medicine: object): Observable<any> {
    const url = this.apiBaseUrl + '/' + id;
    return this.http.put(url, medicine);
  }

  deleteMedicine(id: number): Observable<any> {
    const url = this.apiBaseUrl + '/' + id;
    return this.http.delete(url);
  }
}
