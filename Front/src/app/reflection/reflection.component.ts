import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReflectionService } from '../services/reflection.service';
import { getAccessCounter } from '../guards/reflection.guard';

@Component({
  selector: 'app-reflection',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './reflection.component.html',
  styleUrl: './reflection.component.css',
})
export class ReflectionComponent implements OnInit {
  dllNames: string[] = [];
  isLoading = false;
  error: string | null = null;
  isEmpty = false;
  accessCounter: number = 0;

  constructor(private reflectionService: ReflectionService) {}

  ngOnInit(): void {
    this.updateCounter();
  }

  updateCounter(): void {
    this.accessCounter = getAccessCounter();
  }

  loadImporters(): void {
    this.isLoading = true;
    this.error = null;
    this.isEmpty = false;
    this.dllNames = [];

    this.reflectionService.getImporters().subscribe({
      next: (data) => {
        this.dllNames = data;
        this.isEmpty = data.length === 0;
        this.isLoading = false;
      },
      error: (err) => {
        this.error =
          'Error al cargar los importadores. Por favor, intente nuevamente.';
        this.isLoading = false;
        console.error('Error loading importers:', err);
      },
    });
  }
}
