import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiResultModel } from '../models/period.model';

@Injectable({
  providedIn: 'root'
})
export class ForecastService {
  readonly BaseUrl = 'http://localhost:5140/';
  constructor(private http: HttpClient) { }

  getForecast(street: string, city: string, state: string, zip: string)
  {
    return this.http.get<ApiResultModel>(this.BaseUrl + `weatherforecast?street=${street}&city=${city}&state=${state}&zip=${zip}`);
  }
}
