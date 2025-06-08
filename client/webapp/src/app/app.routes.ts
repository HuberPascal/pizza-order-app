import { Routes } from '@angular/router';
import { PizzaListComponent } from './components/pizza-list/pizza-list.component';

export const routes: Routes = [
  { path: '', redirectTo: '/pizzas', pathMatch: 'full' },
  { path: 'pizzas', component: PizzaListComponent },
];
