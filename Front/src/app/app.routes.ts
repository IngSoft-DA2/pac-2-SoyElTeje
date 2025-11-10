import { Routes } from '@angular/router';
import { reflectionGuard } from './guards/reflection.guard';

export const routes: Routes = [
  {
    path: 'reflection',
    loadComponent: () => import('./reflection/reflection.component').then(m => m.ReflectionComponent),
    canActivate: [reflectionGuard]
  }
];
