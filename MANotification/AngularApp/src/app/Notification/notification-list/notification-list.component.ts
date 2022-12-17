import { Component, OnInit } from '@angular/core';
import { HttpService } from '../../Services/http.service';
import * as signalR from '@microsoft/signalr';  
import { environment } from 'src/environments/environment';
import { NotificationModel } from '../../Models/notification';

@Component({
  selector: 'app-notification-list',
  templateUrl: './notification-list.component.html',
  styleUrls: ['./notification-list.component.css']
})
export class NotificationListComponent implements OnInit {
  notifications: NotificationModel[] = []; 
 
  errorMessage = '';

  constructor(private service: HttpService) { } 

  NotificationStatus = [
    { id: 0, name: "Succeeded" },
    { id: 1, name: "Failed" },
    { id: 2, name: "Canceled" },
    { id: 3, name: "Timeout" },
    { id: 4, name: "NotApplicable" }
  ];
 

  ngOnInit(): void {
    this.getNotificationData();  
  
    const connection = new signalR.HubConnectionBuilder()  
      .configureLogging(signalR.LogLevel.Information)  
      .withUrl(environment.baseUrl + 'notify')  
      .build();  
  
    connection.start().then(function () {  
      console.log('SignalR Connected! *** Notification');  
    }).catch(function (err) {  
      return console.error(err.toString());  
    });  
  
    connection.on("createNotification", () => {  
      this.getNotificationData();  
    });  
  }
  
  getNotificationData() {  
    this.service.getNotifications().subscribe(  
      data => {
        this.notifications = data;   
      }, 
    );  
  } 

}
