import { Component, Input } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, share } from 'rxjs/operators';
import { faUserMd, faUserInjured, faBars, faClipboard, faFilePdf, faSignOutAlt } from '@fortawesome/free-solid-svg-icons'
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { AuthenticationService } from 'src/app/Services/authentication.service';
@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent {
  //icones
  faClipboard = faClipboard;
  faBars = faBars;
  faUserMd = faUserMd;
  faUserInjured = faUserInjured;
  faFilePdf = faFilePdf;
  faSignOutAlt = faSignOutAlt;

  //abre dashboard
  opened = false;

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      share()
    );

  //a sidenav era um form em que eu podia manipular e definir o tamanho da minha sidenav 
  //por isso existe esse formgroup em que eu preenchia o tamanho e ele se adaptava automaticamente
  //apenas deixei inicializando um padrão ali no construtor que pode ser mudado e definido o tamanho
  //da sidenav.
  options: FormGroup;
  constructor(private breakpointObserver: BreakpointObserver,
    private router: Router,
    private cookieService: CookieService,
    fb: FormBuilder,
    private serviceAuth: AuthenticationService,
  ) {
  this.options = fb.group({
    'fixed': true,
    'top': 60,
    'bottom': 0,
  });
  }

  emailUser:string = this.serviceAuth.getEmailUser().split('@')[0];
  



  visiPat = false;
  visiMed = false;
  visiExam = false;
  visiFile = false;

  //ARMENGADA SAFE

  toogleMedic(value: string) {

    if (value == "med") {
      if (this.visiMed == false) {
        this.visiMed = true
        this.visiExam = false;
        this.visiPat = false;
        this.visiFile = false;
      } else {
        this.visiMed = false
      }
    }

    if (value == "pat") {
      if (this.visiPat == false) {
        this.visiPat = true
        this.visiExam = false;
        this.visiMed = false;
        this.visiFile = false;
      } else {
        this.visiPat = false
      }
    }

    if (value == "exam") {
      if (this.visiExam == false) {
        this.visiExam = true
        this.visiPat = false;
        this.visiMed = false;
        this.visiFile = false;
      } else {
        this.visiExam = false
      }
    }

    if (value == "file") {
      if (this.visiFile == false) {
        this.visiFile = true;
        this.visiExam = false;
        this.visiPat = false;
        this.visiMed = false;
      } else {
        this.visiFile = false;
      }
    }
  }

  sair() {
    this.cookieService.delete('JwtToken');
    this.cookieService.delete('token');
    this.router.navigate(['/'])
  }

}
