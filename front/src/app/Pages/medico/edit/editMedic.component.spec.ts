import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { EditMedicComponent } from './editMedic.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { RouterTestingModule } from '@angular/router/testing';

describe('EditMedicComponent', () => {
  let component: EditMedicComponent;
  let fixture: ComponentFixture<EditMedicComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [EditMedicComponent],
      imports: [HttpClientTestingModule, RouterTestingModule]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditMedicComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
