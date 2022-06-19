import { formatCurrency } from '@angular/common';
import { identifierName } from '@angular/compiler';
import { Component, Input, OnInit } from '@angular/core';
import { ToDoAppService } from 'src/app/to-do-app.service';
@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent implements OnInit {

  constructor(private service:ToDoAppService) { }


  @Input() user:any;
  firstname: string= "";
  lastname: string= "";


  ngOnInit(): void {
    this.firstname = this.user.firstname;
    this.lastname = this.user.lastname;
  }

  addUser()
  {
    var user = 
    {
      firstname:this.firstname,
      lastname:this.lastname
    }

    this.service.addUser(user).subscribe(res =>
      {
        var closeModalBtn = document.getElementById('add-user-modal-close');
        if(closeModalBtn)
        {
          closeModalBtn.click();
        }

        var showAddSuccess = document.getElementById('add-user-success-alert');
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
