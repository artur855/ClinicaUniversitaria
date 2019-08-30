import { Component } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, share } from 'rxjs/operators';
import { faUserMd, faUserInjured, faBars } from '@fortawesome/free-solid-svg-icons'
@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent {
  faBars = faBars;
  faUserMd = faUserMd;
  faUserInjured = faUserInjured;
  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      share()
    );

  constructor(private breakpointObserver: BreakpointObserver) { }

  visiPat = false;
  visiMed = false;;
  opened = false;

  toogleMedic(value: string) {
    if (value == "pat") {
      this.visiPat = !this.visiPat
      if (this.visiMed == true) {
        this.visiMed = false;
      }
    }
    if (value == "med") {
      this.visiMed = !this.visiMed
      if (this.visiPat == true) {
        this.visiPat = false;
      }
    }
  }
}
