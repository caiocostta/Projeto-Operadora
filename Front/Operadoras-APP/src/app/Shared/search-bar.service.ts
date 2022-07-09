import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SearchBarService {

  filter: string = '';

  constructor() { }

  getFilter(filter: string){
    this.filter = filter;
  }
}
