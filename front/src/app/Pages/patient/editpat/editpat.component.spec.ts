import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditpatComponent } from './editpat.component';

describe('EditpatComponent', () => {
  let component: EditpatComponent;
  let fixture: ComponentFixture<EditpatComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditpatComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditpatComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
