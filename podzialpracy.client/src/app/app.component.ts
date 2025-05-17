import { Component, OnInit } from '@angular/core';
import { User } from './models/user.model';
import { Task } from './models/task.model';
import { TaskService } from './services/task.service';
import { UserSelectComponent } from './components/user-select/user-select.component';
import { TaskListAssignedComponent } from './components/task-list-assigned/task-list-assigned.component';
import { TaskListAvailableComponent } from './components/task-list-available/task-list-available.component';
import { TaskAssignFormComponent } from './components/task-assign-form/task-assign-form.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  standalone: true,
  imports: [
    UserSelectComponent,
    TaskListAssignedComponent,
    TaskListAvailableComponent,
    TaskAssignFormComponent,
    CommonModule,
  ],
})
export class AppComponent implements OnInit {
  selectedUser!: User;
  availableTasks: Task[] = [];
  selectedTasks: Task[] = [];
  assignedTasks: Task[] = [];

  constructor(private taskService: TaskService) { }

  ngOnInit(): void {
    this.loadAvailableTasks();
  }

  loadAvailableTasks(): void {
    this.taskService.getAllTasks().subscribe({
      next: (tasks) => {
        this.availableTasks = tasks;
        console.log('Dostępne zadania:', tasks);
      },
      error: (err) => {
        console.error('Błąd ładowania zadań:', err);
        alert('Błąd ładowania zadań:\n' + JSON.stringify(err.error));
      },
    });
  }

  onUserSelected(user: User): void {
    this.selectedUser = user;
    this.taskService.getTasksByUser(user.id).subscribe({
      next: (tasks) => {
        this.assignedTasks = tasks;
        console.log('Przypisane zadania:', tasks);
      },
      error: (err) => {
        console.error('Błąd pobierania zadań przypisanych:', err);
        alert('Błąd pobierania zadań przypisanych:\n' + JSON.stringify(err.error));
      },
    });
  }

  onTaskSelect(task: Task): void {
    if (!this.selectedTasks.includes(task)) {
      this.selectedTasks.push(task);
      console.log('Dodano zadanie do przypisania:', task);
    }
  }
}
