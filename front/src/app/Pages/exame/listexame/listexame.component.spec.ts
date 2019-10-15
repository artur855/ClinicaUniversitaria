import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListexameComponent } from './listexame.component';

describe('ListexameComponent', () => {
  let component: ListexameComponent;
  let fixture: ComponentFixture<ListexameComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListexameComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListexameComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
