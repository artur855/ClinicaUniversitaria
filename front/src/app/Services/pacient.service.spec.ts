import { TestBed } from '@angular/core/testing';

import { PacientService } from './pacient.service';

describe('PacientService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: PacientService = TestBed.get(PacientService);
    expect(service).toBeTruthy();
  });
});
