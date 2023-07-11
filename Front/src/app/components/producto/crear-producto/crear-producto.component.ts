import { Component } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Observer } from 'rxjs';
import { GenericService } from 'src/app/services/generic.service';
import { FormValidators } from 'src/app/utils/Validators/Forms';

@Component({
  selector: 'app-crear-producto',
  templateUrl: './crear-producto.component.html',
  styleUrls: ['./crear-producto.component.scss']
})
export class CrearProductoComponent {
  public formdataP: FormGroup;
  public listCategoria: Array<any> = [];
  constructor(
    private serviceGeneral: GenericService,
    private activeModal: NgbActiveModal,
    private form: FormValidators
  ) {
    this.formdataP = this.form.datosCrearProducto();
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

  public close() {
    this.activeModal.close();
  }

  public guardar() {
    const process: Observer<any> = {
      next: (data: any) => {
        if(data){
          window.location.reload();
        }
      },
      error: (error: any) => {
        console.log(error);
      },
      complete: () => {
        console.log('se completo el proceso');
      },
    };

    this.serviceGeneral
      .post('Producto/CrearProducto', this.formdataP.value)
      .subscribe(process);
  }
}
