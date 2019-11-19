import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { Upload } from 'src/app/Models/Upload';

@Component({
  selector: 'app-uploadfile',
  templateUrl: './uploadfile.component.html',
  styleUrls: ['./uploadfile.component.css']
})
export class UploadfileComponent {

  constructor(public http: HttpClient,
    public router: Router) { }

  public UploadForm = new FormGroup({
    file: new FormControl(''),
    idExam: new FormControl(''),
  });

  Url = environment.url + "Exam";
  selectedFile: File = null;

  onFileSelected(event) {
    this.selectedFile = <File>event.target.files[0];
    console.log(this.selectedFile);
  }

  Voltar() {
    this.router.navigate(['dashboard']);
  }

  onSubmit() {
    const fd = new FormData();
    var date = new Date();
    var dateExam = date.getDate() + "/" + date.getMonth() + 1 + "/" + date.getFullYear();
    fd.append('ExamFile', this.selectedFile, this.selectedFile.name);
    fd.append('Exam', this.UploadForm.controls.idExam.value);
    fd.append('Exam', dateExam);
    console.log(fd);
    this.http.post(this.Url, fd)
      .subscribe(res => {
        console.log(res)
      });
  }
}
