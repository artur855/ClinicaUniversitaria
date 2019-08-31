import { Component } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, share } from 'rxjs/operators';
import { faUserMd, faUserInjured, faBars, faClipboard} from '@fortawesome/free-solid-svg-icons'
@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent {
  faClipboard = faClipboard;
  faBars = faBars;
  faUserMd = faUserMd;
  faUserInjured = faUserInjured;
  opened = false;
  
  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      share()
    );

  constructor(private breakpointObserver: BreakpointObserver) { }

  visiPat = false;
  visiMed = false;;
  visiExam = false;;
  
  toogleMedic(value: string) {
    
    if (value == "exam") {
      this.visiExam = !this.visiExam
    }
  }
}
