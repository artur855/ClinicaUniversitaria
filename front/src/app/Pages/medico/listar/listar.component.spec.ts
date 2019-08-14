import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';

import { ListarComponent } from './listar.component';
import { RouterTestingModule } from '@angular/router/testing';

describe('ListarComponent', () => {
  let component: ListarComponent;
  let fixture: ComponentFixture<ListarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ListarComponent],
      imports: [HttpClientTestingModule, RouterTestingModule]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
