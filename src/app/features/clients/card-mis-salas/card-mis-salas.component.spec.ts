import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CardMisSalasComponent } from './card-mis-salas.component';

describe('CardMisSalasComponent', () => {
  let component: CardMisSalasComponent;
  let fixture: ComponentFixture<CardMisSalasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CardMisSalasComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CardMisSalasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
