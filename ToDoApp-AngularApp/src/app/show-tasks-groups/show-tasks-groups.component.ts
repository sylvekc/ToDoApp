import { Component, OnInit } from '@angular/core';
import { fakeAsync } from '@angular/core/testing';
import { Observable } from 'rxjs';
import { ToDoAppService } from '../to-do-app.service';

@Component({
  selector: 'app-show-tasks-groups',
  templateUrl: './show-tasks-groups.component.html',
  styleUrls: ['./show-tasks-groups.component.css']
})
export class ShowTasksGroupsComponent implements OnInit {


  taskGroups!:Observable<any[]>;

  constructor(private service:ToDoAppService) { }

  ngOnInit(): void {
    this.taskGroups = this.service.getTaskGroups();
  }



}
