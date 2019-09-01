import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditexameComponent } from './editexame.component';

describe('EditexameComponent', () => {
  let component: EditexameComponent;
  let fixture: ComponentFixture<EditexameComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditexameComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditexameComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
