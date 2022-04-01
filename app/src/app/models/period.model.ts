export class ApiResultModel {
  periods : Period[] | undefined;
}

export class Period {
  number : number | undefined;
  name : string | undefined;
  startTime: string | undefined;
  endTime : string | undefined;
  isDaytime : string | undefined;
  temperature : string | undefined;
  temperatureUnit : string | undefined;
  temperatureTrend : string | undefined;
  windSpeed : string | undefined;
  windDirection : string | undefined;
  icon : string | undefined;
  shortForecast : string | undefined;
  detailedForecast : string | undefined;
}
