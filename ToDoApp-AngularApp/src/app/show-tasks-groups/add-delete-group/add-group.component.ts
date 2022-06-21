import { Component, Input, OnInit } from '@angular/core';
import { ToDoAppService } from 'src/app/to-do-app.service';

@Component({
  selector: 'app-add-group',
  templateUrl: './add-group.component.html',
  styleUrls: ['./add-group.component.css']
})
export class AddGroupComponent implements OnInit {

  constructor(private service:ToDoAppService) { }


  @Input() 
  taskgroup:any;
  name: string= "";


  ngOnInit(): void 
  {
    this.name = this.taskgroup.name;
  }

  addTaskGroup()
  {
    var taskgroup = 
    {
      name:this.name,
    }

    this.service.addTaskGroup(taskgroup).subscribe(res =>
      {
        var closeModalBtn = document.getElementById('add-taskgroup-modal-close');
        if(closeModalBtn)
        {
          closeModalBtn.click();
        }

        var showAddSuccess = document.getElementById('add-taskgroup-success-alert');
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

}
