import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { provideHttpClient } from '@angular/common/http';

import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common'; // Ważne dla *ngFor

import { AppComponent } from './app.component';
import { UserSelectComponent } from './components/user-select/user-select.component';
import { TaskListAssignedComponent } from './components/task-list-assigned/task-list-assigned.component';
import { TaskListAvailableComponent } from './components/task-list-available/task-list-available.component';
import { TaskAssignFormComponent } from './components/task-assign-form/task-assign-form.component';
 
@NgModule({
  declarations: [
    
  ],
    imports: [
      BrowserModule,
      FormsModule,
      CommonModule, 
      UserSelectComponent,
      TaskListAssignedComponent,
      TaskListAvailableComponent,
      TaskAssignFormComponent,
      AppComponent,
  ],
  providers: [provideHttpClient()],
  bootstrap: [AppComponent]
})
export class AppModule { }
