import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PizzaOrderDialogComponent } from './pizza-order-dialog.component';

describe('PizzaOrderDialogComponent', () => {
  let component: PizzaOrderDialogComponent;
  let fixture: ComponentFixture<PizzaOrderDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PizzaOrderDialogComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PizzaOrderDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
