import { Component, Input } from '@angular/core';
import { Task } from '../../models/task.model';

@Component({
  selector: 'app-task-list-assigned',
  templateUrl: './task-list-assigned.component.html',
  styleUrls: ['./task-list-assigned.component.css']
})
export class TaskListAssignedComponent {
  @Input() tasks: Task[] = []; 
}
