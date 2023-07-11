import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class GenericService {
  private url = environment.url;

  constructor(private http: HttpClient) {}

  public get(modulo: string, parameters: string) {
    return this.http.get(`${this.url}${modulo}${parameters}`);
  }

  public post(modulo: string, parameters: any) {
    return this.http.post(`${this.url}${modulo}`, parameters);
  }
  public put(modulo: string, parameters: any) {
    return this.http.put(`${this.url}${modulo}`, parameters);
  }

  public delete(modulo: string, parameters: string) {
    return this.http.delete(`${this.url}${modulo}${parameters}`);
  }
}
