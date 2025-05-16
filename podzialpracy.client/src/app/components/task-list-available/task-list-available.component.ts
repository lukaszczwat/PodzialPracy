import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Task } from '../../models/task.model';

@Component({
  selector: 'app-task-list-available',
  templateUrl: './task-list-available.component.html',
  styleUrls: ['./task-list-available.component.css'],
})
export class TaskListAvailableComponent {
  @Input() tasks: Task[] = [];
  @Output() taskSelect = new EventEmitter<Task>();

  selectTask(task: Task) {
    this.taskSelect.emit(task);
  }
}
