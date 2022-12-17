import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { User } from 'src/app/Models/user';
import { HttpService } from 'src/app/Services/http.service';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent implements OnInit {
  users:User[] = [];
  userForm!:FormGroup;
  message: string = '';
  alert: boolean = false;


  constructor(private httpservice :  HttpService) { }

  ngOnInit(): void {
    this.userForm =new FormGroup({
      Name :new FormControl('',Validators.required)
    });
    this.message= '';
  }

  closeAlert() {
    this.alert = false;
  }
  AddUser(){
    console.log(this.userForm.value);
    this.httpservice.createUser(this.userForm.value).subscribe(result=>{
      this.alert = true;
      this.ngOnInit();
      this.message = 'User Added Successfully';
    });
  }

}
