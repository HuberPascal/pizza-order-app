import { Component, signal } from '@angular/core';

@Component({
  selector: 'app-custom-category-filter',
  imports: [],
  templateUrl: './custom-category-filter.component.html',
  styleUrl: './custom-category-filter.component.scss',
})
export class CustomCategoryFilterComponent {
  categories = ['Alle', 'Klassiker', 'Spezialitäten', 'Scharf', 'Vegetarisch'];

  selectedCategory = signal<string>(this.categories[0]);

  setSelectedCategory(category: string) {
    this.selectedCategory.set(category);
  }
}
