import { Component, Input } from '@angular/core';
import { Task } from '../../models/task.model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-task-list-assigned',
  templateUrl: './task-list-assigned.component.html',
  styleUrls: ['./task-list-assigned.component.css'],
  standalone: true,
  imports: [CommonModule],
})
export class TaskListAssignedComponent {
  @Input() tasks: Task[] = []; 
}
