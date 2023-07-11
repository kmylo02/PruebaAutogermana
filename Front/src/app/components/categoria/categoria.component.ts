import { Component } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Observer } from 'rxjs';
import { GenericService } from 'src/app/services/generic.service';
import { CrearCategoriaComponent } from './crear-categoria/crear-categoria.component';

@Component({
  selector: 'app-categoria',
  templateUrl: './categoria.component.html',
  styleUrls: ['./categoria.component.scss'],
})
export class CategoriaComponent {
  public listCategoria: Array<any> = [];

  constructor(
    private serviceGeneral: GenericService,
    private modalService: NgbModal
  ) {
    this.obtenerListadoCategorias();
  }

  obtenerListadoCategorias() {
    const process: Observer<any> = {
      next: (data: any) => {
        this.listCategoria = data;
        console.log(this.listCategoria);
      },
      error: (error: any) => {
        console.log(error);
      },
      complete: () => {
        console.log('se completo el proceso');
      },
    };

    this.serviceGeneral
      .get('Categoria/ListadoCategoria', '')
      .subscribe(process);
  }

  public openModal(): void {
    const activeModal = this.modalService.open(CrearCategoriaComponent, {
      size: 'lg',
    });
  }
}
