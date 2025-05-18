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

  currentPage = 1;
  pageSize = 10;

  ngOnInit(): void {
    this.loadAvailableTasks();
  }

  showError(message: string, error: any): void {
    const backendMsg = error?.error || 'Nieznany błąd.';
    console.error(message, backendMsg);
    alert(`${message}\n${backendMsg}`);
  }

  loadAvailableTasks(): void {
    this.taskService.getAllTasks(this.currentPage, this.pageSize).subscribe({
      next: (tasks) => {
        this.availableTasks = tasks;
      },
      error: (err) => {
        console.error('Błąd ładowania zadań:', err);
      },
    });
  }

  nextPage(): void {
    this.currentPage++;
    this.loadAvailableTasks();
  }


  previousPage(): void {
    if (this.currentPage > 1) {
      this.currentPage--;
      this.loadAvailableTasks();
    }
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
    const index = this.selectedTasks.findIndex(t => t.id === task.id);
    if (index === -1) {
      this.selectedTasks.push(task);
    } else {
      this.selectedTasks.splice(index, 1); 
    }
  }

  resetSelectedTasks(): void {
    this.selectedTasks = [];
  }


  onAssignedTasks(): void {
    this.selectedTasks = []; // wyczyść zaznaczenia

    if (this.selectedUser) {
      this.taskService.getTasksByUser(this.selectedUser.id).subscribe({
        next: (tasks) => {
          this.assignedTasks = tasks;
          console.log('Przypisane zadania po przypisaniu:', tasks);

         
          this.loadAvailableTasks();
        },
        error: (err) => {
          console.error(' Błąd odświeżania przypisanych zadań:', err);
          alert('Nie udało się odświeżyć przypisanych zadań.');
        }
      });
    }
  }

}
