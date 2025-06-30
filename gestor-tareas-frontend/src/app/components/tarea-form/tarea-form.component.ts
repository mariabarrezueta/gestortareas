import { Component } from '@angular/core';
import { TareaService } from '../../services/tarea.service';
import { Tarea } from '../../models/tarea.model';

@Component({
  selector: 'app-tarea-form',
  templateUrl: './tarea-form.component.html'
})
export class TareaFormComponent {
  tarea: Tarea = {
    titulo: '',
    descripcion: '',
    fechaLimite: '',
    completada: false,
    prioridad: 0,
    categoria: ''
  };

  constructor(private tareaService: TareaService) {}

  crearTarea() {
    this.tareaService.crearTarea(this.tarea).subscribe({
      next: () => {
        alert('Tarea creada con éxito');
        // Limpiar el formulario
        this.tarea = {
          titulo: '',
          descripcion: '',
          fechaLimite: '',
          completada: false,
          prioridad: 0,
          categoria: ''
        };
      },
      error: err => {
        alert('Error al crear la tarea');
        console.error(err);
      }
    });
  }
}
