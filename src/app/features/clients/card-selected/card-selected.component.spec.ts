import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CardSelectedComponent } from './card-selected.component';

describe('CardSelectedComponent', () => {
  let component: CardSelectedComponent;
  let fixture: ComponentFixture<CardSelectedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CardSelectedComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CardSelectedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
