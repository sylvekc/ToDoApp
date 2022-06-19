import {HttpClientModule} from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { ShowTasksGroupsComponent } from './show-tasks-groups/show-tasks-groups.component';
import { AddGroupComponent } from './show-tasks-groups/add-group/add-group.component';
import { AddUserComponent } from './show-tasks-groups/add-user/add-user.component';
import { ToDoAppService } from './to-do-app.service';

@NgModule({
  declarations: [
    AppComponent,
    ShowTasksGroupsComponent,
    AddGroupComponent,
    AddUserComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [ToDoAppService],
  bootstrap: [AppComponent]
})
export class AppModule { }
