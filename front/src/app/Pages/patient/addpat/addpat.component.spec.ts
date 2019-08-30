import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddpatComponent } from './addpat.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

describe('AddpatComponent', () => {
  let component: AddpatComponent;
  let fixture: ComponentFixture<AddpatComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [AddpatComponent],
      imports: [FontAwesomeModule]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddpatComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
