import { Component, OnInit,Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styles: []
})
export class NavbarComponent implements OnInit {
  files:any;
  fil;
  ced: string;
  dataresponse = undefined;
  nuevacadenahttp = ""


  constructor(private http: HttpClient) { }

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
          console.log('desde el ok')
          console.log(data)
          this.dataresponse = data
          // console.log(data['error']['error']['text'])
        }, (er)=>{
          console.log('desde el error')
          console.log(er['error']['text'])
          this.dataresponse = er['error']['text']
        })

    };
   reader.readAsText(file);

}

getCharaters(valor) {
  // http://3.19.120.22:32768/api/Persons
  //  "http://3.19.120.22:32771/api/Persons"
  // let data = "http://localhost:32768/api/Persons"
  let data = "http://localhost:32775/api/Persons"
  return this.http.get(`${data}/${valor}`)
  .pipe(
    map(res => JSON.stringify(res))
  )
}


}
