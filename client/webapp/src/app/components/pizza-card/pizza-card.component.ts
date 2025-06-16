import { Component, input } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { CustomChipComponent } from '../custom-chip/custom-chip.component';
import { MatButtonModule } from '@angular/material/button';
import { PizzaDto } from '../../api/core/services/service-proxies';

@Component({
  selector: 'app-pizza-card',
  imports: [MatCardModule, CustomChipComponent, MatButtonModule],
  templateUrl: './pizza-card.component.html',
  styleUrl: './pizza-card.component.scss',
})
export class PizzaCardComponent {
  items = input.required<PizzaDto[]>();
}
