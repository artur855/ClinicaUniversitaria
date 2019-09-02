import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { MedicService } from './medico.service';

describe('ServiceService', () => {
  beforeEach(() => TestBed.configureTestingModule({
    imports: [HttpClientTestingModule]
  }));
  it('should be created', () => {
    const service: MedicService = TestBed.get(MedicService);
    expect(service).toBeTruthy();
  });
});
