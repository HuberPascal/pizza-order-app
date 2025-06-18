import { AfterViewInit, Component, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-pizza-order-dialog',
  imports: [MatCardModule, MatButtonModule],
  templateUrl: './pizza-order-dialog.component.html',
  styleUrl: './pizza-order-dialog.component.scss',
})
export class PizzaOrderDialogComponent implements AfterViewInit {
  pizza = inject(MAT_DIALOG_DATA);

  readonly dialogRef = inject(MatDialogRef<PizzaOrderDialogComponent>);

  ngAfterViewInit(): void {
    console.log('dialog pizza is:', this.pizza);
  }
}
