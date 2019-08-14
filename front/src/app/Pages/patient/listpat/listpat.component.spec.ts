import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListpatComponent } from './listpat.component';

describe('ListpatComponent', () => {
  let component: ListpatComponent;
  let fixture: ComponentFixture<ListpatComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListpatComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListpatComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
