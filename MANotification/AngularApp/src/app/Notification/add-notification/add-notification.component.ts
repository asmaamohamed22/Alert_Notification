import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { HttpService } from 'src/app/Services/http.service';

@Component({
  selector: 'app-add-notification',
  templateUrl: './add-notification.component.html',
  styleUrls: ['./add-notification.component.css']
})
export class AddNotificationComponent implements OnInit {
  notifications! : Notification[];
  contactForm! : FormGroup;
  message: string = '';
  alert: boolean = false;
 
  NotificationStatus = [
    { id: 0, name: "Succeeded" },
    { id: 1, name: "Failed" },
    { id: 2, name: "Canceled" },
    { id: 3, name: "Timeout" },
    { id: 4, name: "NotApplicable" }
  ];
 

  constructor(private httpservice :  HttpService) { }

  ngOnInit(): void {
    this.contactForm =new FormGroup({
      AlertTitle:new FormControl('',Validators.required),
      SentTime:new FormControl('',Validators.required),
      Status: new FormControl('',Validators.required)
    });
    this.message = '';
  }

  closeAlert() {
    this.alert = false;
  }

  submit(){
    console.log(this.contactForm.value)
    this.httpservice.sendNotification(this.contactForm.value).subscribe(result=>{
      this.alert = true;
      this.ngOnInit();
      this.message = 'Notification Added Successfully';
      });
  }
}
