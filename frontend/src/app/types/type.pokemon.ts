export interface PokemonResponse {
  results: Array<Pokemon>;
}

export type Pokemon = {
  name: string;
  url: string;
};
