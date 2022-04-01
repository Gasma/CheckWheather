import { Component, OnInit, ViewChild } from '@angular/core';
import { ForecastService } from 'src/app/services/forecast.service';
import { NgForm } from '@angular/forms';
import { ApiResultModel } from './models/period.model';
import { ErrorsApi, ErrorsValidation } from './models/erros.model';
import { MatTable, MatTableDataSource } from '@angular/material/table';
import { DatePipe } from '@angular/common';

export interface TableModel {
  icon?: string;
  day: string;
  temperature: string;
  wind: string;
  description?: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  constructor(public service: ForecastService, private datePipe: DatePipe) {}

  displayedColumns: string[] = [
    'icon',
    'day',
    'temperature',
    'wind',
    'description',
  ];

  dataSource: MatTableDataSource<TableModel> =
    new MatTableDataSource<TableModel>();
  @ViewChild(MatTable) table: MatTable<any> | undefined;

  title = 'Weather Forecast';
  dataShow: ApiResultModel = { periods: [] };
  msgs: string = '';

  ngOnInit(): void {
    this.msgs = "No data to show!";
  }

  SubmitQuery(f: NgForm) {
    this.service
      .getForecast(f.value.street, f.value.city, f.value.state, f.value.zip)
      .subscribe({
        next: (res) => {
          var filldata: TableModel[] = [];
          this.msgs = ''
          res?.periods?.forEach((item) => {
            if (item != undefined && item.isDaytime == 'true') {
              filldata.push({
                icon: item.icon,
                day: `${item.name} - ${this.datePipe.transform(
                  item.startTime,
                  'MMMM dd'
                )}`,
                temperature: `${item.temperature} - ${item.temperatureUnit}`,
                wind: `${item.windSpeed} to the ${item.windDirection}`,
                description: item.detailedForecast,
              });
            }
          });
          this.dataSource = new MatTableDataSource(filldata);
        },
        error: (err) => {
          var data = err as ErrorsApi;
          console.log(data);
        },
      });
  }
}
