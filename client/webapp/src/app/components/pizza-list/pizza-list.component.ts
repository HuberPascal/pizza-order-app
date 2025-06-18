import {
  Component,
  EventEmitter,
  inject,
  Input,
  OnInit,
  Output,
} from '@angular/core';
import { Component, inject, OnInit } from '@angular/core';
import { CustomCategoryFilterComponent } from '../custom-category-filter/custom-category-filter.component';
import { PizzaCardComponent } from '../pizza-card/pizza-card.component';
import { PizzaStore } from '../../stores/pizza.store';

@Component({
  selector: 'app-pizza-list',
  imports: [CustomCategoryFilterComponent, PizzaCardComponent],
  templateUrl: './pizza-list.component.html',
  styleUrl: './pizza-list.component.scss',
})
export class PizzaListComponent implements OnInit {
  readonly store = inject(PizzaStore);

  ngOnInit() {
    this.store.loadAllPizzas();
  }

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
