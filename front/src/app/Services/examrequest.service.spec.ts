import { TestBed } from '@angular/core/testing';

import { ExamrequestService } from './examrequest.service';

describe('ExamrequestService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ExamrequestService = TestBed.get(ExamrequestService);
    expect(service).toBeTruthy();
  });
});
