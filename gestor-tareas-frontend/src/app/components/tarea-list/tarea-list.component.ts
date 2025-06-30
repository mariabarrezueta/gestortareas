import { Component, OnInit } from '@angular/core';
import { TareaService } from '../../services/tarea.service';
import { Tarea } from '../../models/tarea.model';

@Component({
  selector: 'app-tarea-list',
  templateUrl: './tarea-list.component.html'
})
export class TareaListComponent implements OnInit {
  tareas: Tarea[] = [];
  filtro: string = 'todas';

  constructor(private tareaService: TareaService) {}

  ngOnInit() {
    this.obtenerTareas();
  }

  obtenerTareas() {
    this.tareaService.getTareas().subscribe(data => {
      this.tareas = data;
    });
  }

  get tareasFiltradas(): Tarea[] {
    if (this.filtro === 'completadas') {
      return this.tareas.filter(t => t.completada);
    } else if (this.filtro === 'pendientes') {
      return this.tareas.filter(t => !t.completada);
    }
    return this.tareas;
  }

  marcarComoCompletada(tarea: Tarea) {
    const tareaActualizada = { ...tarea, completada: true };
    this.tareaService.actualizarTarea(tarea.id!, tareaActualizada).subscribe({
      next: () => {
        alert('La tarea fue marcada como completada.');
        this.obtenerTareas();  // recarga lista
      },
      error: err => {
        console.error('Error al actualizar la tarea:', err);
        alert('Ocurrió un error al marcar la tarea como completada.');
      }
    });
  }
}
