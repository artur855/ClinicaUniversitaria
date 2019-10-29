import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { AddMedicComponent } from './addMedic.component';
import { RouterTestingModule } from '@angular/router/testing';
import { MedicService } from 'src/app/Services/medico.service';
import { Medico } from 'src/app/Models/Medico';


describe('AddMedicComponent', () => {
  let component: AddMedicComponent;
  let fixture: ComponentFixture<AddMedicComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [AddMedicComponent],
      imports: [HttpClientTestingModule, RouterTestingModule],
      providers: [MedicService, Medico]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddMedicComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
