import { Injectable } from '@angular/core';
import { Task, TaskType, TaskStatus } from '../models/task.model';

@Injectable({
  providedIn: 'root',
})
export class TaskService {
  private mockTasks: Task[] = [
    { id: 1, tresc: 'Implementacja API', skalaTrudnosci: 5, rodzaj: TaskType.Implementacja, status: TaskStatus.DoWykonania },
    { id: 2, tresc: 'Konfiguracja serwera', skalaTrudnosci: 3, rodzaj: TaskType.Maintanance, status: TaskStatus.DoWykonania },
  ];

  getAllTasks(): Task[] {
    return this.mockTasks.filter(t => t.status === TaskStatus.DoWykonania).sort((a, b) => b.skalaTrudnosci - a.skalaTrudnosci).slice(0, 10);
  }

  przypisanieTasks(userId: number, tasks: Task[]): boolean {
    tasks.forEach(task => task.status = TaskStatus.Wykonane);
    return true;
  }
}
