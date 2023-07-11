import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'Front';
  public componente: string | undefined = '2';
  constructor() {
    this.componente = localStorage.getItem('componente')?.toString();
    if (this.componente == '' || this.componente == undefined) {
      this.componente = '2';
      localStorage.setItem('componente', '2');
    }
  }

  abreComponente(compon: string) {
    localStorage.setItem('componente', compon);
    window.location.reload();
  }
}
