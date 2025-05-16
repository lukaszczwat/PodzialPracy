import { Injectable } from '@angular/core';
import { CanDeactivate } from '@angular/router';
import { TaskAssignFormComponent } from '../components/task-assign-form/task-assign-form.component';

@Injectable({
  providedIn: 'root',
})
export class UnsavedChangesGuard implements CanDeactivate<TaskAssignFormComponent> {
  canDeactivate(component: TaskAssignFormComponent): boolean {
    return confirm('Masz niezapisane zmiany. Czy na pewno chcesz opuścić stronę?');
  }
}
