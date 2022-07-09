import { HttpClient } from '@angular/common/http';
import { Component, OnInit, SimpleChange } from '@angular/core';
import { TestBed } from '@angular/core/testing';
import { filter } from 'rxjs';
import { SearchBarService } from '../Shared/search-bar.service';
import { SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-operadoras',
  templateUrl: './operadoras.component.html',
  styleUrls: ['./operadoras.component.scss']
})
export class OperadorasComponent implements OnInit {

  public operadoras: any = [];
  public operadorasFiltradas: any = [];
  private _opFilter: string = '';
  opName: string = '';
  opNumber: string = '';
  modalDisplay: string = 'none';
  opInfo: any = [];
  formNumber: boolean = true;
  formObs: boolean = true;

  public get opFilter() {
    return this._opFilter;
  }

  setOpFilter(value: string){
    this._opFilter = value;
    this.operadorasFiltradas = this.opFilter ? this.opFill (this.opFilter) : this.operadoras;
  }

  opFill (filtrarPor: string): any {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.operadoras.filter(
      (operadora: { nomeOperadora: string; numTelefone: string; }) => operadora.nomeOperadora.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
      operadora.numTelefone.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    )
  }

  modalExit(){
    if(this.formNumber == true && this.formObs == true){
      this.opInfo = '';
    }else{
      alert('Por favor salve ou cancele as alterações pendentes')
    }
  }

  constructor(private http: HttpClient, private searchBar: SearchBarService) { }

  ngOnInit(): void {
    this.getOperadoras();
  }
  ngDoCheck() {
    this._opFilter = this.searchBar.filter;
  }
  ngAfterContentChecked(){
    this.setOpFilter(this.opFilter);
    this.modalOn();
  }


  modalOn(){
    this.opName = this.opInfo[0];
    this.opNumber = this.opInfo[1];
    if(this.opName != '' && this.opName != null && this.opName != undefined){
      this.modalDisplay = 'block'
    }else{
      this.modalDisplay = 'none';
    }
  }

  public getOperadoras(): void{
    this.operadoras = this.http.get('https://localhost:5001/api/Operadoras').subscribe(
      res => {
        this.operadoras = res;
        this.operadorasFiltradas = this.operadoras;
      },
      error => console.log (error)
      );
  }

}
