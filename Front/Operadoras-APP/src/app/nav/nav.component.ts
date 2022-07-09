import { Component, OnInit } from '@angular/core';
import { SearchBarService } from '../Shared/search-bar.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {

  constructor(private searchBar: SearchBarService) { }

  isCollapsed = true;

  filter: string = '';

  ngOnInit(): void {
  }

  filterLink(){
    this.searchBar.getFilter(this.filter);
  }

}
