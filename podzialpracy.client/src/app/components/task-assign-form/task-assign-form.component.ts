import { Component, Input } from '@angular/core';
import { TaskService } from '../../services/task.service';
import { Task } from '../../models/task.model';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-task-assign-form',
  templateUrl: './task-assign-form.component.html',
  styleUrls: ['./task-assign-form.component.css'],
  standalone: true,
  imports: [FormsModule],
})
export class TaskAssignFormComponent {
  @Input() selectedTasks: Task[] = [];
  @Input() userId!: number;
  terminRealizacji: Date = new Date();  // Użytkownik wybiera datę

  constructor(private taskService: TaskService) { }

  /** 
   * Sprawdza poprawność liczby zadań (minimum 5, maksimum 11) 
   * oraz wysyła dane do backendu
   */
  przypisanieTasks(userId: number) {
    if (this.selectedTasks.length < 5 || this.selectedTasks.length > 11) {
      alert("Liczba zadań musi być między 5 a 11!");
      return;
    }

    this.taskService.przypisanieTasks(userId, this.selectedTasks)
      .subscribe(() => alert('Zadania zostały przypisane!'));
  }

  /** 
   * Ustawia termin realizacji dla zadania typu Wdrożenie lub Maintanance 
   */
  setTermin(taskId: number) {
    this.taskService.setTerminRealizacji(taskId, this.terminRealizacji)
      .subscribe(() => alert('Termin został ustawiony!'));
  }
}
