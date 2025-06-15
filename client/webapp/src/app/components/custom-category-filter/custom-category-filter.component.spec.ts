import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomCategoryFilterComponent } from './custom-category-filter.component';

describe('CustomCategoryFilterComponent', () => {
  let component: CustomCategoryFilterComponent;
  let fixture: ComponentFixture<CustomCategoryFilterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CustomCategoryFilterComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CustomCategoryFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
