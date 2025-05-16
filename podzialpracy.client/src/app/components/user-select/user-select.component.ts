import { Component, EventEmitter, Output } from '@angular/core';
import { UserService } from '../../services/user.service';
import { User } from '../../models/user.model';

@Component({
  selector: 'app-user-select',
  templateUrl: './user-select.component.html',
  styleUrls: ['./user-select.component.css'],
})
export class UserSelectComponent {
  users: User[] = [];

  @Output() userSelected = new EventEmitter<User>();

  constructor(private userService: UserService) {
    this.users = this.userService.getUsers();
  }

  selectUser(user: User) {
    this.userSelected.emit(user);
  }
}
