import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';

let accessCounter = 0;

export const reflectionGuard: CanActivateFn = (route, state) => {
  const router = inject(Router);

  if (accessCounter >= 20) {
    router.navigate(['/']);
    return false;
  }

  accessCounter++;

  return true;
};

export function getAccessCounter(): number {
  return accessCounter;
}

export function resetAccessCounter(): void {
  accessCounter = 0;
}
