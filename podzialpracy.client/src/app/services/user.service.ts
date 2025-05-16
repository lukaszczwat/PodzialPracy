import { Injectable } from '@angular/core';
import { User, UserType } from '../models/user.model';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private mockUsers: User[] = [
    { id: 1, imie: 'Jan', nazwisko: 'Kowalski',typ: UserType.Programista },
    { id: 2, imie: 'Anna', nazwisko: 'Nowak', typ: UserType.Administrator },
  ];

  getUsers(): User[] {
    return this.mockUsers;
  }
}
