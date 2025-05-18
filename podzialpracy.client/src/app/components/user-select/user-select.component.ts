import { Component, EventEmitter, Output } from '@angular/core';
import { UserService } from '../../services/user.service';
import { User } from '../../models/user.model';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-user-select',
  templateUrl: './user-select.component.html',
  styleUrls: ['./user-select.component.css'],
  standalone: true,
  imports: [CommonModule],
})
export class UserSelectComponent {
  users: User[] = [];
  selectedUser?: User;

  @Output() userSelected = new EventEmitter<User>();

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.userService.getUsers().subscribe(users => {
      this.users = users;
    });
  }

  selectUser(user: User): void {
    this.selectedUser = user;
    this.userSelected.emit(user);
  }
}
