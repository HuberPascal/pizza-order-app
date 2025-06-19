import {
  AfterViewInit,
  Component,
  computed,
  inject,
  effect,
  signal,
} from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomChipComponent } from '../custom-chip/custom-chip.component';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatDividerModule } from '@angular/material/divider';
import {
  ExtraToppingDto,
  PizzaDto,
} from '../../api/core/services/service-proxies';

interface ExtraTopping {
  id: string;
  name: string;
  price: number;
  selected: boolean;
}

// interface ToppingsForm {
//   toppings: FormControl<ExtraTopping[]>; // Komplette Objekte mit selected-Flag
// }

interface ToppingsForm {
  selectedToppings: FormControl<string[]>;
}

@Component({
  selector: 'app-pizza-order-dialog',
  imports: [
    CommonModule,
    CustomChipComponent,
    MatButtonModule,
    MatCardModule,
    MatCheckboxModule,
    MatDividerModule,
    ReactiveFormsModule,
  ],
  templateUrl: './pizza-order-dialog.component.html',
  styleUrl: './pizza-order-dialog.component.scss',
})
export class PizzaOrderDialogComponent implements AfterViewInit {
  data: { pizza: PizzaDto; extraToppings: ExtraToppingDto[] } =
    inject(MAT_DIALOG_DATA);
  readonly dialogRef = inject(MatDialogRef<PizzaOrderDialogComponent>);

  form = new FormGroup<ToppingsForm>({
    selectedToppings: new FormControl<string[]>([], { nonNullable: true }),
  });

  extraToppings = computed(() =>
    this.getExtraToppingsFromDto(this.data.extraToppings ?? [])
  );

  originalFormValues = computed(() => this.getFormValuesFromDto());

  constructor() {
    effect(() => {
      const originalValues = this.originalFormValues();
      if (originalValues) {
        this.form.setValue(originalValues);
      }
    });
    effect(() => console.log('extratoppings: ', this.extraToppings()));
  }

  ngAfterViewInit(): void {
    console.log('dialog pizza is:', this.data.pizza);
  }

  getExtraToppingsFromDto(
    extraToppingsArray: ExtraToppingDto[]
  ): ExtraTopping[] {
    return extraToppingsArray.map((topping) => ({
      id: topping.id ?? '',
      name: topping.name ?? '',
      price: topping.price ?? 0,
      selected: false,
    }));
  }

  getFormValuesFromDto() {
    return {
      selectedToppings: [],
    };
  }
}
