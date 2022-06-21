import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs';
import { JsonPipe } from '@angular/common';

@Injectable({
  providedIn: 'root'
})
export class ToDoAppService {

  readonly ToDoAppAPIUrl = "https://localhost:7298/api"

  constructor(private http:HttpClient) { }


///USER
  addUser(data:any)
  {
    return this.http.post(this.ToDoAppAPIUrl + '/user', data);
  }

  getUserList():Observable<any[]>
  {
    return this.http.get<any>(this.ToDoAppAPIUrl + '/user');
  }



///TaskGroup
  getTaskGroups():Observable<any[]>
  {
    return this.http.get<any>(this.ToDoAppAPIUrl + '/taskGroup');
  }

  getTaskGroupById(id:number|string)
  {
    return this.http.get(this.ToDoAppAPIUrl + `/taskGroup/${id}`);

  }

  addTaskGroup(data:any) 
  {
    return this.http.post(this.ToDoAppAPIUrl + '/taskGroup', data);
  }

  deleteTaskGroup(id:number|string)
  {
    return this.http.delete(this.ToDoAppAPIUrl + `/taskGroup/${id}`);
  }

  updateTaskGroup(id:number|string, data:any)
  {
    return this.http.patch(this.ToDoAppAPIUrl + `/taskGroup/${id}`,data)
  }

///Task

  getTasks():Observable<any[]>
  {
    return this.http.get<any>(this.ToDoAppAPIUrl + '/task');
  }

  addTask(data:any) 
  {
    return this.http.post(this.ToDoAppAPIUrl + '/task', data);
  }

  deleteTask(id:number|string)
  {
    return this.http.delete(this.ToDoAppAPIUrl + `/task/${id}`);
  }

  ///STATUS

  getStatusList():Observable<any[]>
  {
    return this.http.get<any>(this.ToDoAppAPIUrl + '/status');
  }


}
