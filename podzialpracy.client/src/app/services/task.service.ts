import { Injectable } from '@angular/core';
import { Task, TaskType, TaskStatus } from '../models/task.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class TaskService {
  private apiUrl = '/Task';
  //private apiUrl = '';

  constructor(private http: HttpClient) { }

  private mockTasks: Task[] = [
    { id: 1, tresc: 'Implementacja API', skalaTrudnosci: 5, rodzaj: TaskType.Implementacja, status: TaskStatus.DoWykonania },
    { id: 2, tresc: 'Konfiguracja serwera', skalaTrudnosci: 3, rodzaj: TaskType.Maintanance, status: TaskStatus.DoWykonania },
  ];

  getAllTasks(): Observable<Task[]> {
    //return this.mockTasks.filter(t => t.status === TaskStatus.DoWykonania).sort((a, b) => b.skalaTrudnosci - a.skalaTrudnosci).slice(0, 10);
    return this.http.get<Task[]>(`${this.apiUrl}/GetAllTasks`);
  }

  setTerminRealizacji(taskId: number, termin: Date): Observable<void> {
    return this.http.post<void>(`${this.apiUrl}/SetTerminRealizacji/${taskId}`, termin);
  }

  przypisanieTasks(userId: number, tasks: Task[]): Observable<boolean> {
    return this.http.post<boolean>(`${this.apiUrl}/PrzypisanieTask/${userId}`, { userId, tasks });
  }

  getTasksByUser(userId: number): Observable<Task[]> {
    return this.http.get<Task[]>(`${this.apiUrl}/GetTasksByUser/${userId}`);
  }
}
