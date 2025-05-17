import { Component, EventEmitter, Input, Output, OnChanges, SimpleChanges } from '@angular/core';
import { Task } from '../../models/task.model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-task-list-available',
  templateUrl: './task-list-available.component.html',
  styleUrls: ['./task-list-available.component.css'],
  standalone: true,
  imports: [CommonModule],
})
export class TaskListAvailableComponent implements OnChanges {
  @Input() tasks: Task[] = [];
  @Output() taskSelect = new EventEmitter<Task>();

  selectTask(task: Task) {
    this.taskSelect.emit(task);
  }

  

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['tasks']) {
      console.log('Odebrano zadania w komponencie available:', this.tasks);
    }
  }
}
