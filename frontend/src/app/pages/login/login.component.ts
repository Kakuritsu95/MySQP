import { Component, inject, OnInit, signal } from '@angular/core';

import { Pokemon } from '../../types/type.pokemon';
import { PokemonService } from '../../services/pokemon.service';

@Component({
  selector: 'app-login',
  imports: [],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent implements OnInit {
  pokemonService = inject(PokemonService);
  pokemons = signal<Array<Pokemon>>([]);
  ngOnInit(): void {
    this.pokemonService
      .getPokemonsFromAPI()
      .subscribe((pokemons) => this.pokemons.set(pokemons.results));
  }
}
