import { Component, Input } from '@angular/core';
import { TaskService } from '../../services/task.service';
import { Task } from '../../models/task.model';
import { FormsModule } from '@angular/forms';
import { Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-task-assign-form',
  templateUrl: './task-assign-form.component.html',
  styleUrls: ['./task-assign-form.component.css'],
  standalone: true,
  imports: [
    FormsModule,
    CommonModule,
  ],

})
export class TaskAssignFormComponent {
  @Input() selectedTasks: Task[] = [];
  @Input() userId!: number;
  @Output() onAssigned = new EventEmitter<void>();
  errorMessage: string = '';
  terminRealizacji: Date = new Date();  // Użytkownik wybiera datę

  constructor(private taskService: TaskService) { }

  /** 
   * Sprawdza poprawność liczby zadań (minimum 5, maksimum 11) 
   * oraz wysyła dane do backendu
   */
  przypisanieTasks(userId: number) {
    const total = this.selectedTasks.length;

    if (total < 5 || total > 11) {
      this.errorMessage = 'Liczba zadań musi być między 5 a 11!';
      return;
    }

    const trudne = this.selectedTasks.filter(t => t.skalaTrudnosci >= 4).length;
    const procentTrudne = trudne / total;

    if (procentTrudne < 0.1 || procentTrudne > 0.3) {
      this.errorMessage = `Zaznaczyłeś ${trudne} trudnych zadań z ${total}. Dozwolone: 10%–30% trudnych zadań.`;
      return;
    }

    const latwe = this.selectedTasks.filter(t => t.skalaTrudnosci <= 2).length;
    if (latwe / total > 0.5) {
      this.errorMessage = `Za dużo łatwych zadań – maksymalnie 50%.`;
      return;
    }

    this.taskService.przypisanieTasks(userId, this.selectedTasks).subscribe({
      next: () => {
        this.onAssigned.emit();
        this.errorMessage = '';
      },
      error: (err) => {
        this.errorMessage = err?.error || 'Wystąpił nieznany błąd przypisania.';
        this.selectedTasks = [];
      }
    });
  }

  get liczbaZadan(): number {
    return this.selectedTasks.length;
  }

  get trudneZadania(): number {
    return this.selectedTasks.filter(t => t.skalaTrudnosci >= 4).length;
  }

  get latweZadania(): number {
    return this.selectedTasks.filter(t => t.skalaTrudnosci <= 2).length;
  }

  get procentTrudnych(): number {
    return this.liczbaZadan > 0 ? this.trudneZadania / this.liczbaZadan : 0;
  }

  get procentLatwych(): number {
    return this.liczbaZadan > 0 ? this.latweZadania / this.liczbaZadan : 0;
  }

  /** 
   * Ustawia termin realizacji dla zadania typu Wdrożenie lub Maintanance 
   */
  setTermin(taskId: number) {
    this.taskService.setTerminRealizacji(taskId, this.terminRealizacji)
      .subscribe(() => alert('Termin został ustawiony!'));
  }
}
