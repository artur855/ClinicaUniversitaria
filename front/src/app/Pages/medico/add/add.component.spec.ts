import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { AddComponent } from './add.component';
import { RouterTestingModule } from '@angular/router/testing';
import { ServiceService } from 'src/app/Services/medico.service';
import { Medico } from 'src/app/Models/Medico';


describe('AddComponent', () => {
  let component: AddComponent;
  let fixture: ComponentFixture<AddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [AddComponent],
      imports: [HttpClientTestingModule, RouterTestingModule],
      providers: [ServiceService, Medico]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
