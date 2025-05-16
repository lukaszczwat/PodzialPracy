import { Component, OnInit } from '@angular/core';
import { User } from './models/user.model';
import { Task } from './models/task.model';
import { TaskService } from './services/task.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  selectedUser!: User;
  availableTasks: Task[] = [];
  selectedTasks: Task[] = [];
  assignedTasks: Task[] = [];

  constructor(private taskService: TaskService) { }

  ngOnInit(): void {
    this.availableTasks = this.taskService.getAllTasks();
  }

  onUserSelected(user: User) {
    this.selectedUser = user;
  }

  onTaskSelect(task: Task) {
    if (!this.selectedTasks.includes(task)) {
      this.selectedTasks.push(task);
    }
  }
}
