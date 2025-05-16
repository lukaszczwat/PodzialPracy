import { Component, Input } from '@angular/core';
import { TaskService } from '../../services/task.service';
import { Task } from '../../models/task.model';

@Component({
  selector: 'app-task-assign-form',
  templateUrl: './task-assign-form.component.html',
  styleUrls: ['./task-assign-form.component.css'],
})
export class TaskAssignFormComponent {
  @Input() selectedTasks: Task[] = [];
  @Input() userId!: number;

  constructor(private taskService: TaskService) { }

  assignTasks() {
    if (this.selectedTasks.length >= 5 && this.selectedTasks.length <= 11) {
      this.taskService.przypisanieTasks(this.userId, this.selectedTasks);
    } else {
      alert('Liczba zadań musi być między 5 a 11');
    }
  }
}
