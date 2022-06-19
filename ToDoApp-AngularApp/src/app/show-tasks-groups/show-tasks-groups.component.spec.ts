import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowTasksGroupsComponent } from './show-tasks-groups.component';

describe('ShowTasksGroupsComponent', () => {
  let component: ShowTasksGroupsComponent;
  let fixture: ComponentFixture<ShowTasksGroupsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowTasksGroupsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShowTasksGroupsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
