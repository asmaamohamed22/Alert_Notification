import { Injectable } from '@angular/core';  
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';  
import { Observable, throwError, of } from 'rxjs';  
import { catchError, map } from 'rxjs/operators'; 
import { environment } from 'src/environments/environment';
import { User } from '../Models/user';
import { NotificationModel } from '../Models/notification';
  
@Injectable({  
  providedIn: 'root'  
})  
export class HttpService { 
  private userUrl = environment.baseUrl + 'api/Users/';  
  private notificationURL = environment.baseUrl + 'api/Notifications/';  

  httpOptions: Object = {
    headers: new HttpHeaders({
      'Accept': 'text/html',
      'Content-Type': 'application/json',
    }),
    responseType: 'text',
    withCredentials: true
  };
  
  constructor(private http: HttpClient) { } 

  getUsers(): Observable<User[]> {  
    return this.http.get<User[]>(this.userUrl +  "GetUsers")  
      .pipe(  
        catchError(this.handleError)  
      );  
  } 
    
  createUser(user: User): Observable<User> {   
    return this.http.post<User>(this.userUrl + "AddUser", user, this.httpOptions)  
      .pipe(  
        catchError(this.handleError)  
      );  
  }

  getNotifications(): Observable<NotificationModel[]> {  
    return this.http.get<NotificationModel[]>(this.notificationURL +  "GetNotifications")  
      .pipe(  
        catchError(this.handleError)  
      );  
  } 

  sendNotification(notification: NotificationModel): Observable<NotificationModel> {   
    return this.http.post<NotificationModel>(this.notificationURL + "AddNoitification", notification, this.httpOptions)  
      .pipe(  
        catchError(this.handleError)  
      );  
  }

  handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      console.error('An error occurred:', error.error.message);
    } else {
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error}`);
    }
    return throwError(
      'Something bad happened; please try again later.');
  };

}