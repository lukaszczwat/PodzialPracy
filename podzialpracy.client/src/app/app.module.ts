import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';

import { UserSelectComponent } from './components/user-select/user-select.component';
import { TaskListAssignedComponent } from './components/task-list-assigned/task-list-assigned.component';
import { TaskListAvailableComponent } from './components/task-list-available/task-list-available.component';
import { TaskAssignFormComponent } from './components/task-assign-form/task-assign-form.component';
 
@NgModule({
  declarations: [
    AppComponent,
    UserSelectComponent,
    TaskListAssignedComponent,
    TaskListAvailableComponent,
    TaskAssignFormComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
