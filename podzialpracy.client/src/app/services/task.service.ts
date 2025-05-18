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

 

  getAllTasks(page: number = 1, pageSize: number = 10): Observable<Task[]> {
    return this.http.get<Task[]>(`${this.apiUrl}/GetAllTasks?page=${page}&pageSize=${pageSize}`);
  }

  setTerminRealizacji(taskId: number, termin: Date): Observable<void> {
    return this.http.post<void>(`${this.apiUrl}/SetTerminRealizacji/${taskId}`, termin);
  }

  przypisanieTasks(userId: number, tasks: Task[]): Observable<any> {

    const payload = {
      userId,
      tasks
    };

    console.log('Payload wysyłany do backendu:', payload);

    return this.http.post<boolean>(`${this.apiUrl}/PrzypisanieTask/${userId}`, payload);
  }

  getTasksByUser(userId: number): Observable<Task[]> {
    return this.http.get<Task[]>(`${this.apiUrl}/GetTasksByUser/${userId}`);
  }
}
