import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LstComponent } from './lst.component';

describe('LstComponent', () => {
  let component: LstComponent;
  let fixture: ComponentFixture<LstComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LstComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LstComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
