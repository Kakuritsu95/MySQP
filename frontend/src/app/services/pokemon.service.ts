import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { PokemonResponse } from '../types/type.pokemon';

@Injectable({
  providedIn: 'root',
})
export class PokemonService {
  http = inject(HttpClient);
  getPokemonsFromAPI() {
    return this.http.get<PokemonResponse>('https://pokeapi.co/api/v2/pokemon');
  }
  constructor() {}
}
