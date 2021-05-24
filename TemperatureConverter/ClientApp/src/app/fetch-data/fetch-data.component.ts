import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TemperatureTypes } from '../temperature-type-entity';


@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  tempType: TemperatureTypes;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<TemperatureTypes>(baseUrl + 'TemperatureConverterCtrl').subscribe(result => {
      this.tempType = result;
    }, error => console.error(error));
  }

  receiveData($event) {
    this.tempType = $event
  }
}

