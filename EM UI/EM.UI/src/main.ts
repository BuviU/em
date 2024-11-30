// import { bootstrapApplication } from '@angular/platform-browser';
// import { appConfig } from './app/app.config';
// import { AppComponent } from './app/app.component';
// import { provideHttpClient } from '@angular/common/http'; // Import provideHttpClient

// bootstrapApplication(AppComponent, {
//   ...appConfig,
//   providers: [provideHttpClient()], // Add HttpClientModule globally
// })
//   .catch((err) => console.error(err));

// import { bootstrapApplication } from '@angular/platform-browser';
// import { EmployeeListComponent } from './app/components/employee-list/employee-list.component';
// import { provideHttpClient } from '@angular/common/http';

// bootstrapApplication(EmployeeListComponent, {
//   providers: [
//     provideHttpClient(), // Provides HttpClient functionality
//   ],
// }).catch((err) => console.error(err));




import { bootstrapApplication } from '@angular/platform-browser';
import { provideRouter, Routes } from '@angular/router';
import { provideHttpClient } from '@angular/common/http';
import { EmployeeListComponent } from './app/components/employee-list/employee-list.component';
import { EmployeeFormComponent } from './app/components/employee-form/employee-form.component';

// Define routes
const appRoutes: Routes = [
  { path: '', component: EmployeeListComponent }, // Home route
  { path: 'add-employee', component: EmployeeFormComponent }, // Add Employee Form
];

// Bootstrap with routing and HttpClient
bootstrapApplication(EmployeeListComponent, {
  providers: [
    provideRouter(appRoutes), // Provide routing
    provideHttpClient(), // Provide HTTP client
  ],
}).catch((err) => console.error(err));
