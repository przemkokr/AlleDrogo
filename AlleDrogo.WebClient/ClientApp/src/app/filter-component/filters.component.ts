import { Component } from '@angular/core';

@Component({
  selector: 'filters',
  templateUrl: './filters.component.html',
  styleUrls: ['./filters.component.css']
})
export class Filters {
  public categories: string[] = [];
  public itemStates: string[] = [];
  public minPrice: number = 0;
  public maxPrice: number = 0;

  constructor() {
    this.fillCategories();
    this.fillItemStates();
  }

  fillCategories = () => {
    // in the futere we will fill this from enum or db probably
    this.categories = ['Samochody', 'Moda', 'Elektronika', 'Dom i ogród'];
  }

  fillItemStates = () => {
    this.itemStates = ['Nowe', 'Używane'];
  }
}
