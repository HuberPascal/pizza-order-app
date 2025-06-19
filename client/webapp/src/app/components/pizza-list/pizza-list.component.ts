import { Component, effect, inject, OnInit } from '@angular/core';
import { CustomCategoryFilterComponent } from '../custom-category-filter/custom-category-filter.component';
import { PizzaCardComponent } from '../pizza-card/pizza-card.component';
import { PizzaStore } from '../../stores/pizza.store';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { PizzaOrderDialogComponent } from '../pizza-order-dialog/pizza-order-dialog.component';
import {
  ExtraToppingClient,
  PizzaDto,
} from '../../api/core/services/service-proxies';
import { ExtraToppingStore } from '../../stores/extraToppings.store';

@Component({
  selector: 'app-pizza-list',
  imports: [CustomCategoryFilterComponent, PizzaCardComponent, MatDialogModule],
  templateUrl: './pizza-list.component.html',
  styleUrl: './pizza-list.component.scss',
})
export class PizzaListComponent implements OnInit {
  readonly store = inject(PizzaStore);
  readonly extraToppingsStore = inject(ExtraToppingStore);
  readonly dialog = inject(MatDialog);

  ngOnInit() {
    this.store.loadAllPizzas();
    this.extraToppingsStore.loadAllExtraToppings();
  }

  constructor() {
    effect(() => {
      console.log(
        'ExtraToppings changed:',
        this.extraToppingsStore.extraToppings()
      );
      console.log('Loading state:', this.extraToppingsStore.loading());
      console.log('Error state:', this.extraToppingsStore.error());
    });
  }

  openDialog(pizza: PizzaDto) {
    const dialogRef = this.dialog.open(PizzaOrderDialogComponent, {
      data: {
        pizza: pizza,
        extraToppings: this.extraToppingsStore.extraToppings(),
      },
    });

    dialogRef.afterClosed().subscribe((result) => {
      console.log(`Dialog result: ${result}`);
    });
  }
}
