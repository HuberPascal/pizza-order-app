import { Component, input } from '@angular/core';
import { MatChipsModule } from '@angular/material/chips';

@Component({
  selector: 'app-custom-chip',
  imports: [MatChipsModule],
  templateUrl: './custom-chip.component.html',
  styleUrl: './custom-chip.component.scss',
})
export class CustomChipComponent {
  items = input.required<string>(); // Array
}
