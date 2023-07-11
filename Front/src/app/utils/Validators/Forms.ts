import { Injectable } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

@Injectable({
  providedIn: 'root',
})
export class FormValidators {
  constructor(private fb: FormBuilder) {}

  public datosCrearCategoria(): any {
    return this.fb.group({
      nombre: ['', Validators.required],
      descripcion: ['', Validators.required],
    });
  }

  public datosCrearProducto() {
    return this.fb.group({
      nombre: ['', Validators.required],
      descripcion: ['', Validators.required],
      idcategoria: ['', Validators.required],
      codigo: ['', Validators.required],
      precioVenta: ['', Validators.required],
      stock: ['', Validators.required],
    });
  }
}
