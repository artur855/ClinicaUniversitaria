import { TestBed } from '@angular/core/testing';

import { ServiceService } from './service.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('ServiceService', () => {
  beforeEach(() => TestBed.configureTestingModule({
    imports: [HttpClientTestingModule]

  }));

  it('should be created', () => {
    const service: ServiceService = TestBed.get(ServiceService);
    expect(service).toBeTruthy();
  });
});
