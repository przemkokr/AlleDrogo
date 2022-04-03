import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public testData: TestData[];

  constructor(http: HttpClient, @Inject('API_URL') apiUrl: string) {
    http.get<TestData[]>(apiUrl + 'test').subscribe(result => {
      this.testData = result;
    }, error => console.error(error));
  }
}

interface TestData {
  name: string;
  description: string;
  someDecimalValue: number;
  someDate: string;
}
