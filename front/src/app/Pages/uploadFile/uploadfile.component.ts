import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormControl } from '@angular/forms';
import {Router} from '@angular/router';

@Component({
  selector: 'app-uploadfile',
  templateUrl: './uploadfile.component.html',
  styleUrls: ['./uploadfile.component.css']
})
export class UploadfileComponent {

  constructor(private http: HttpClient, private router: Router) { }

  private UploadFormForm = new FormGroup({
    file : new FormControl(''),
    expectedDate: new FormControl(''),
  });
 
  selectedFile:File = null;
  onFileSelected(event) {
    this.selectedFile = <File>event.target.files[0];
  }

  Voltar(){
    this.router.navigate(['dashboard']);
  }

  onUpload() {
    const fd = new FormData();
    fd.append('image', this.selectedFile, this.selectedFile.name);
    this.http.post('gs://clinicauniversitaria-ad189.appspot.com/uploadfile', fd)
      .subscribe(res => {
        console.log(res)
      });
  }
}
