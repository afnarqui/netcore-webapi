import { Component, OnInit,Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import {ExcelService} from '../../../services/excel.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styles: [],
  providers: [ExcelService]
})
export class NavbarComponent implements OnInit {
  files:any;
  fil;
  ced: string;
  dataresponse = undefined;
  nuevacadenahttp = ""
  data

  constructor(private http: HttpClient,private excelService:ExcelService) { }

  ngOnInit() {
  }
  searchArchivo(ced,file){
    this.ced = ced.value;
    this.files = file.value
    this.readFile(this.files)
  }
  search(e){
    console.log(e)
    this.files = e.target.files[0];
    this.readFile(this.files)
  }

  readFile(file: File) {
    var reader = new FileReader();
    reader.onload = () => {
        var resultado = reader.result;
        this.fil = resultado
        var datanueva = this.fil.split('\n')

        for(let i = 0; i< datanueva.length;i++){
          console.log(datanueva[i])
           this.nuevacadenahttp+= datanueva[i] + ",";
        }
        this.getCharaters(this.nuevacadenahttp).
        subscribe((data)=>{
          this.dataresponse = data
          this.clear();
        }, (er)=>{
          this.dataresponse = er['error']['text']
         var request = JSON.stringify(this.dataresponse)
          var requestNew = request.split(";");
          this.dataresponse = requestNew;
          this.clear();
        })

    };
   reader.readAsText(file);

}

clear() {
  this.files = null;
  this.fil= null;
  this.ced= "";
  this.nuevacadenahttp= null;
  this.data= null;
}

getCharaters(valor) {
  let data = "http://3.19.120.22:81/api/Persons"
  return this.http.get(`${data}/${valor}`)
  .pipe(
    map(res => JSON.stringify(res))
  )
}

exportExcel():void {
  this.excelService.exportAsExcelFile(this.dataresponse, 'sample');
}


}
