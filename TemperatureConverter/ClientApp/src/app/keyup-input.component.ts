import { Component, Input, Output, EventEmitter } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';
import { debounceTime } from 'rxjs/operators';
import { TemperatureTypes } from './temperature-type-entity';
import { getBaseUrl } from '../main';

@Component({
  selector: 'app-input-keyup',
  template: `
    <input value="{{value}}" name="{{name}}" type="text"  (keyup)="getTemperatures(this.name, $event.target.value)">
  `
})
export class InputComponent {
  @Input() name: string;
  @Input() value: string;
  @Output() passData = new EventEmitter<TemperatureTypes>();
  tempTypes: TemperatureTypes;
  
  constructor(private http: HttpClient) { }

  getTemperatures(name: string, value: string): void {

    value = value.trim();
    const options = name ?
      {
        params: new HttpParams().set('name', name).set('value', value)
      } : {};

    this.http.get<TemperatureTypes>(getBaseUrl() + 'TemperatureConverterCtrl', options).subscribe(result => {
      this.tempTypes = result;
      this.passData.emit(this.tempTypes);
    }, error => console.error(error));
    
  }

}
