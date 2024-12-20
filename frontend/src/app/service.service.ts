import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../environment';

@Injectable({
  providedIn: 'root',
})
export class ServiceService {
  private path = environment.apiUrl;

  constructor(private httpClient: HttpClient) {}

  getAllPokemonData(): Observable<any> {
    const header = new HttpHeaders().set('Content-type', 'application/json');
    return this.httpClient.get(this.path + 'Pokemon/GetPokemon', {
      headers: header,
    });
  }
}
