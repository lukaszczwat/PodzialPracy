export enum TaskStatus {
  DoWykonania = 'DoWykonania',
  Wykonane = 'Wykonane',
}

export enum TaskType {
  Wdrozenie = 'Wdrożenie',
  Implementacja = 'Implementacja',
  Maintanance = 'Maintanance'
  }

export interface Task {
  id: number;
  tresc: string;
  skalaTrudnosci: number;
  rodzaj: TaskType;
  status: TaskStatus;
  terminRealizacji?: Date;
}
