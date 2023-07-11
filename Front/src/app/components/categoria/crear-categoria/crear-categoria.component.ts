import { Component } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Observer } from 'rxjs';
import { GenericService } from 'src/app/services/generic.service';
import { FormValidators } from 'src/app/utils/Validators/Forms';

@Component({
  selector: 'app-crear-categoria',
  templateUrl: './crear-categoria.component.html',
  styleUrls: ['./crear-categoria.component.scss'],
})
export class CrearCategoriaComponent {
  public formdata: FormGroup;
  constructor(
    private serviceGeneral: GenericService,
    private activeModal: NgbActiveModal,
    private form: FormValidators
  ) {
    this.formdata = form.datosCrearCategoria();
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
      .post('Categoria/CrearCategoria', this.formdata.value)
      .subscribe(process);
  }
}
