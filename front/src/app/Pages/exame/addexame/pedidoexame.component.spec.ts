import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PedidoexameComponent } from './pedidoexame.component';

describe('PedidoexameComponent', () => {
  let component: PedidoexameComponent;
  let fixture: ComponentFixture<PedidoexameComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PedidoexameComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PedidoexameComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
