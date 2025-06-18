import { Component, inject, OnInit } from '@angular/core';
import { CustomCategoryFilterComponent } from '../custom-category-filter/custom-category-filter.component';
import { PizzaCardComponent } from '../pizza-card/pizza-card.component';
import { PizzaStore } from '../../stores/pizza.store';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { PizzaOrderDialogComponent } from '../pizza-order-dialog/pizza-order-dialog.component';
import { PizzaDto } from '../../api/core/services/service-proxies';

@Component({
  selector: 'app-pizza-list',
  imports: [CustomCategoryFilterComponent, PizzaCardComponent, MatDialogModule],
  templateUrl: './pizza-list.component.html',
  styleUrl: './pizza-list.component.scss',
})
export class PizzaListComponent implements OnInit {
  readonly store = inject(PizzaStore);
  readonly dialog = inject(MatDialog);

  ngOnInit() {
    this.store.loadAllPizzas();
  }

  openDialog() {
    const dialogRef = this.dialog.open(PizzaOrderDialogComponent, {
      data: {
        pizza: PizzaDto,
      },
    });

    dialogRef.afterClosed().subscribe((result) => {
      console.log(`Dialog result: ${result}`);
    });
  }
}
