import {HttpClientModule} from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { ShowTasksGroupsComponent } from './show-tasks-groups/show-tasks-groups.component';
import { AddGroupComponent } from './show-tasks-groups/add-delete-group/add-group.component';
import { AddUserComponent } from './show-tasks-groups/add-user/add-user.component';
import { ToDoAppService } from './to-do-app.service';
import { OrderModule } from 'ngx-order-pipe';
import { ShowAddDeleteTaskComponent } from './show-add-delete-task/show-add-delete-task.component';

@NgModule({
  declarations: [
    AppComponent,
    ShowTasksGroupsComponent,
    AddGroupComponent,
    AddUserComponent,
    ShowAddDeleteTaskComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    OrderModule,
    RouterModule.forRoot([
      {path: '', component: ShowTasksGroupsComponent},
      {path: 'edit/:groupId', component: ShowAddDeleteTaskComponent}
    ])
  ],
  providers: [ToDoAppService],
  bootstrap: [AppComponent]
})
export class AppModule { }
