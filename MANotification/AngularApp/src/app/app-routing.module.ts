import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddNotificationComponent } from './Notification/add-notification/add-notification.component';
import { NotificationListComponent } from './Notification/notification-list/notification-list.component';
import { AddUserComponent } from './User/add-user/add-user.component';
import { UserListComponent } from './User/user-list/user-list.component';

const routes: Routes = [
    {path : '', component : UserListComponent},
    {path : 'list', component : NotificationListComponent},
    {path : 'adduser', component : AddUserComponent},
    {path : 'sendnotification', component : AddNotificationComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
