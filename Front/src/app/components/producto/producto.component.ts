import { Component } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Observer } from 'rxjs';
import { GenericService } from 'src/app/services/generic.service';
import { CrearProductoComponent } from './crear-producto/crear-producto.component';

@Component({
  selector: 'app-producto',
  templateUrl: './producto.component.html',
  styleUrls: ['./producto.component.scss']
})
export class ProductoComponent {
  public listProducto: Array<any> = [];

  constructor(
    private serviceGeneral: GenericService,
    private modalService: NgbModal
  ) {
    this.obtenerListadoProducto();
  }

  obtenerListadoProducto() {
    const process: Observer<any> = {
      next: (data: any) => {
        this.listProducto = data;
      },
      error: (error: any) => {
        console.log(error);
      },
      complete: () => {
        console.log('se completo el proceso');
      },
    };

    this.serviceGeneral
      .get('Producto/ListadoProducto', '')
      .subscribe(process);
  }

  public openModalProducto(): void {
    const activeModal = this.modalService.open(CrearProductoComponent, {
      size: 'lg',
    });
  }
}
