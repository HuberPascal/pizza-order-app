import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CustomCategoryFilterComponent } from '../custom-category-filter/custom-category-filter.component';
import { CustomChipComponent } from '../custom-chip/custom-chip.component';
import { MatButtonModule } from '@angular/material/button';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatCardModule } from '@angular/material/card';
import { MatChipsModule } from '@angular/material/chips';

@Component({
  selector: 'app-pizza-list',
  imports: [
    CustomCategoryFilterComponent,
    CustomChipComponent,
    MatButtonModule,
    MatButtonToggleModule,
    MatCardModule,
    MatChipsModule,
  ],
  templateUrl: './pizza-list.component.html',
  styleUrl: './pizza-list.component.scss',
})
export class PizzaListComponent {
  @Input() options: { label: string; value: any }[] = [
    { label: 'alle', value: 1 },
    { label: 'pizzas', value: 2 },
  ];
  @Input() selected: any;
  @Output() selectionChange = new EventEmitter<any>();

  onSelect(value: any) {
    this.selected = value;
    this.selectionChange.emit(value);
  }
}
