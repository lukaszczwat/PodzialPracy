import { Injectable } from '@angular/core';
import { User, UserType } from '../models/user.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class UserService {

  constructor(private http: HttpClient) { }

  private mockUsers: User[] = [
    { id: 1, imie: 'Jan', nazwisko: 'Kowalski',typ: UserType.Programista },
    { id: 2, imie: 'Anna', nazwisko: 'Nowak', typ: UserType.Administrator },
  ];

  getUsers(): Observable<User[]> {
    return this.http.get<User[]>('/User/GetAllUsers');
  }
}
