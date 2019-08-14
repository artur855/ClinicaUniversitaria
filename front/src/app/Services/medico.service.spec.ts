import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ServiceService } from './medico.service';

describe('ServiceService', () => {
  beforeEach(() => TestBed.configureTestingModule({
    imports: [HttpClientTestingModule]
  }));
  it('should be created', () => {
    const service: ServiceService = TestBed.get(ServiceService);
    expect(service).toBeTruthy();
  });
});
