import { TestBed } from '@angular/core/testing';

import { ToDoAppService } from './to-do-app.service';

describe('ToDoAppService', () => {
  let service: ToDoAppService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ToDoAppService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
