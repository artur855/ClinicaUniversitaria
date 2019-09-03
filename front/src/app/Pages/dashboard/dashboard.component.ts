import { Component, Input } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, share } from 'rxjs/operators';
import { faUserMd, faUserInjured, faBars, faClipboard } from '@fortawesome/free-solid-svg-icons'
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
  //abre dashboard
  opened = false;

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      share()
    );

  constructor(private breakpointObserver: BreakpointObserver) { }

  visiPat = false;
  visiMed = false;
  visiExam = false;
//ARMENGADA SAFE
  toogleMedic(value: string) {

    if (value == "med") {
      if (this.visiMed == false) {
        this.visiMed = true
        this.visiExam = false;
        this.visiPat = false;
      } else {
        this.visiMed = false
      }
    }

    if (value == "pat") {
      if (this.visiPat == false) {
        this.visiPat = true
        this.visiExam = false;
        this.visiMed = false;
      } else {
        this.visiPat = false
      }
    }

    if (value == "exam") {
      if (this.visiExam == false) {
        this.visiExam = true
        this.visiPat = false;
        this.visiMed = false;
      } else {
        this.visiExam = false
      }
    }
  }

}
