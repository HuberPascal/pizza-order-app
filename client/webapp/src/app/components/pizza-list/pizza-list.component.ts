import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatChipsModule } from '@angular/material/chips';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { CustomChipComponent } from '../custom-chip/custom-chip.component';

@Component({
  selector: 'app-pizza-list',
  imports: [
    MatCardModule,
    MatButtonModule,
    MatChipsModule,
    MatButtonToggleModule,
    CustomChipComponent,
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
