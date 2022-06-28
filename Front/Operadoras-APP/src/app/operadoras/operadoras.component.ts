import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-operadoras',
  templateUrl: './operadoras.component.html',
  styleUrls: ['./operadoras.component.scss']
})
export class OperadorasComponent implements OnInit {

  public operadoras: any;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getOperadoras();
  }

  public getOperadoras(): void{
    this.operadoras = this.http.get('https://localhost:5001/api/Operadoras').subscribe(res => this.operadoras = res, error => console.log (error));
  }

}
