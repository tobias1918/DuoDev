import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SalasMultiplesComponent } from './salas-multiples.component';

describe('SalasMultiplesComponent', () => {
  let component: SalasMultiplesComponent;
  let fixture: ComponentFixture<SalasMultiplesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SalasMultiplesComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SalasMultiplesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
