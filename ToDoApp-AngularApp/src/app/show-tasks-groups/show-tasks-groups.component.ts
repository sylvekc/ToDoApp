import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ToDoAppService } from '../to-do-app.service';

@Component({
  selector: 'app-show-tasks-groups',
  templateUrl: './show-tasks-groups.component.html',
  styleUrls: ['./show-tasks-groups.component.css']
})
export class ShowTasksGroupsComponent implements OnInit {


  taskGroups!:Observable<any[]>;
  orderHeader: string='';
  reverse: boolean = false;
  user:any;
  taskgroup:any;


  constructor(private service:ToDoAppService) { }
 
  ngOnInit(): void 
  {
    this.taskGroups = this.service.getTaskGroups();
  }


  modalClose()
  {
    this.taskGroups = this.service.getTaskGroups();
  }

  deleteTaskGroup(item:any)
  {
    if(window.confirm(`Are you sure to delete task group: ${item.name}?`))
    {
      this.service.deleteTaskGroup(item.id).subscribe(res =>
        {
          var closeModalBtn = document.getElementById('add-taskgroup-modal-close');
        if(closeModalBtn)
        {
          closeModalBtn.click();
        }
        })

        var showAddSuccess = document.getElementById('delete-taskgroup-success-alert');
        if(showAddSuccess)
        {
          showAddSuccess.style.display = "block";
        }
        setTimeout(() => {
          if(showAddSuccess)
          {
            showAddSuccess.style.display="none"
          }
        }, 4000);
  }
}

  sort(headerName:string)
  {
    this.orderHeader = headerName;
    this.reverse = !this.reverse;
  }


}
