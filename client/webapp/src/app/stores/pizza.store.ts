import { patchState, signalStore, withMethods, withState } from '@ngrx/signals';
import { PizzaClient, PizzaDto } from '../api/core/services/service-proxies';
import { inject } from '@angular/core';

interface PizzaState {
  pizzas: PizzaDto[];
  loading: boolean;
  error: string | null;
}

const initialState: PizzaState = {
  pizzas: [],
  loading: false,
  error: null,
}

export const PizzaStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),

  withMethods((store) => {
    const pizzaService = inject(PizzaClient);

    return {
      async loadAllPizzas() {
        pizzaService.getAll().subscribe({
          next: (pizzaResult) => patchState(store, { pizzas: pizzaResult }),
          error: (err) =>
            patchState(store, { error: err.message, loading: false }),
        });
      },
    };
  })
);
