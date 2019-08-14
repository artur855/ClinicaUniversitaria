import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';

import { ListMedicComponent } from './listMedic.component';
import { RouterTestingModule } from '@angular/router/testing';

describe('ListMedicComponent', () => {
  let component: ListMedicComponent;
  let fixture: ComponentFixture<ListMedicComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ListMedicComponent],
      imports: [HttpClientTestingModule, RouterTestingModule]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListMedicComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
