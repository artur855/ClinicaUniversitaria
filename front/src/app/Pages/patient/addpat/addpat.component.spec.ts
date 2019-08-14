import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddpatComponent } from './addpat.component';

describe('AddpatComponent', () => {
  let component: AddpatComponent;
  let fixture: ComponentFixture<AddpatComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddpatComponent ]
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
