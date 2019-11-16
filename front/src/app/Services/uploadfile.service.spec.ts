import { TestBed } from '@angular/core/testing';

import { UploadfileService } from './uploadfile.service';

describe('UploadfileService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: UploadfileService = TestBed.get(UploadfileService);
    expect(service).toBeTruthy();
  });
});
