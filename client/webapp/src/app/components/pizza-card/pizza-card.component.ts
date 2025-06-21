import { Component, input, output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { CustomChipComponent } from '../custom-chip/custom-chip.component';
import { MatButtonModule } from '@angular/material/button';
import { PizzaDto } from '../../api/core/services/service-proxies';
import { MatChipsModule } from '@angular/material/chips';

@Component({
  selector: 'app-pizza-card',
  imports: [
    CommonModule,
    MatCardModule,
    CustomChipComponent,
    MatButtonModule,
    MatChipsModule,
  ],
  templateUrl: './pizza-card.component.html',
  styleUrl: './pizza-card.component.scss',
})
export class PizzaCardComponent {
  items = input.required<PizzaDto[]>();
  openPizzaOrderDialog = output<PizzaDto>();

  onOrderClick(pizza: PizzaDto) {
    this.openPizzaOrderDialog.emit(pizza);
  }
}
