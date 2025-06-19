import { patchState, signalStore, withMethods, withState } from '@ngrx/signals';
import {
  ExtraToppingClient,
  ExtraToppingDto,
} from '../api/core/services/service-proxies';
import { inject } from '@angular/core';

interface ExtraToppingState {
  extraToppings: ExtraToppingDto[];
  loading: boolean;
  error: string | null;
}

const initialState: ExtraToppingState = {
  extraToppings: [],
  loading: false,
  error: null,
};

export const ExtraToppingStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),

  withMethods((store) => {
    const extraToppingService = inject(ExtraToppingClient);

    return {
      async loadAllExtraToppings() {
        extraToppingService.getAll().subscribe({
          next: (extraToppingResult) =>
            patchState(store, { extraToppings: extraToppingResult }),
          error: (err) =>
            patchState(store, { error: err.message, loading: false }),
        });
      },
    };
  })
);
