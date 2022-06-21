import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToDoAppService } from '../to-do-app.service';
import { Observable } from 'rxjs';
import { DatePipe } from '@angular/common';
import { NgForm } from '@angular/forms';
@Component({
  selector: 'app-show-add-delete-task',
  templateUrl: './show-add-delete-task.component.html',
  styleUrls: ['./show-add-delete-task.component.css']
})
export class ShowAddDeleteTaskComponent implements OnInit {

  taskGroup:any;
  id:any;
  statusList!:Observable<any[]>;
  userList:any=[];
  userNames:any=[];
  userMap:Map<number,string> = new Map();

  constructor(private route: ActivatedRoute, private service: ToDoAppService) { }

  @Input()
  task:any;
  status: string="";
  description: string="";
  deadline:any;
  userId!: number;
  user: string="";
  taskGroupId!: number;
  minDate:any;
  taskId!:number;
  taskGroupName:string="";

  ngOnInit(): void 
  {

    this.statusList = this.service.getStatusList();
    this.userList = this.service.getUserList();
    this.id = this.route.snapshot.params['groupId']
    this.getTaskGroup();
    this.refreshUserMap();
    const datePipe = new DatePipe('en-Us');
    this.minDate = datePipe.transform(new Date(), 'yyy-MM-dd');
  }

    getTaskGroup()
    {
      this.service.getTaskGroupById(this.id).subscribe(res =>
        {
          this.taskGroup = res;
        })
    }

    addTask()
    {
      var task = 
      {
        status:this.status,
        description:this.description,
        deadline:this.deadline,
        userId:this.userId,
        taskGroupId:this.id,
      }
      this.service.addTask(task).subscribe(res =>
        {
          var closeModalBtn = document.getElementById('add-task-modal-close');
        if(closeModalBtn)
        {
          closeModalBtn.click();
        }
          this.getTaskGroup();
          var showAddSuccess = document.getElementById('add-task-success-alert');
          if(showAddSuccess)
          {
            showAddSuccess.style.display = "block";
          }
          setTimeout(function() 
          {
            if(showAddSuccess)
            {
              showAddSuccess.style.display = "none";
            }
          }, 4000);
        })
    }

    deleteTask(task:any)
    {
      if(window.confirm(`Are you sure to delete this task?`))
      {
        this.service.deleteTask(task.id).subscribe(res =>
          {
            this.getTaskGroup();
            
          })

          var showDeleteSuccess = document.getElementById('delete-task-success-alert');
          if(showDeleteSuccess)
          {
            showDeleteSuccess.style.display = "block";
          }
          setTimeout(() => {
            if(showDeleteSuccess)
            {
              showDeleteSuccess.style.display="none"
            }
          }, 4000);
      }
    }

    editTask()
    {
      var task = 
      {
        id:this.taskId,
        status:this.status,
        description:this.description,
        deadline:this.deadline,
        userId:this.userId,
        taskGroupId:this.id,
      }
      var id:number = this.task.id;
      this.service.editTask(id, task).subscribe(res =>
        {
          var closeModalBtn = document.getElementById('edit-task-modal-close');
        if(closeModalBtn)
        {
          closeModalBtn.click();
        }
        })

        var showAddSuccess = document.getElementById('edit-task-success-alert');
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

    editTaskGroupName()
    {
    var taskgroup = 
    {
      name:this.taskGroupName
    }

    this.service.editTaskGroup(this.id, taskgroup).subscribe(res =>
      {
        var closeModalBtn = document.getElementById('edit-taskGroupName-modal-close');
        if(closeModalBtn)
        {
          closeModalBtn.click();
        }

        var showAddSuccess = document.getElementById('edit-taskGroupName-success-alert');
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
      })
    }

    taskGroupNameModal()
    { 
      this.taskGroupName = this.taskGroup.name;
    }

    modalClose()
    {
      this.getTaskGroup();
    }

    modalEditTask(item:any)
    {
      this.task = item
      this.status = this.task.status;
      this.description = this.task.description;
      this.deadline = this.task.deadline;
      this.taskGroupId = this.task.taskGroupId;
      this.userId = this.task.userId;
      this.taskId = this.task.id;
    }

    refreshUserMap()
    {
      this.service.getUserList().subscribe(data =>
        {
          this.userNames = data
          for(let i=0; i<data.length; i++)
          {
            this.userMap.set(this.userNames[i].id, this.userNames[i].firstName);
          }
        })
    }

    clearForm(form: NgForm) 
    {
      form.reset();
    }


}
