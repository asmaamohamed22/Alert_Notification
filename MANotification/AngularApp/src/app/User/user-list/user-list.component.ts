import { Component, OnInit } from '@angular/core';
import { User } from '../../Models/user';
import { HttpService } from '../../Services/http.service';
import * as signalR from '@microsoft/signalr';  
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {
  users: User[] = []; 
  errorMessage = '';

  constructor(private service: HttpService) { } 

  ngOnInit(): void {
    this.getUserData();  
  
    const connection = new signalR.HubConnectionBuilder()  
      .configureLogging(signalR.LogLevel.Information)  
      .withUrl(environment.baseUrl + 'notify')  
      .build();  
  
    connection.start().then(function () {  
      console.log('SignalR Connected! *** User');  
    }).catch(function (err) {  
      return console.error(err.toString());  
    });  
  
    connection.on("createUser", () => {  
      this.getUserData();  
    });  
  }
  
  getUserData() {  
    this.service.getUsers().subscribe(  
      userList => {  
        this.users = userList;   
      }, 
    );  
  } 
  
  
  // getUserData() {  
  //   this.service.getUsers().subscribe((data: User[])=>{
  //     this.users = data;
  //     console.log(this.users);
  //   });
  // } 

}
