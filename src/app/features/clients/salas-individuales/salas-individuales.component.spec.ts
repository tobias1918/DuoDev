import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SalasIndividualesComponent } from './salas-individuales.component';

describe('SalasIndividualesComponent', () => {
  let component: SalasIndividualesComponent;
  let fixture: ComponentFixture<SalasIndividualesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SalasIndividualesComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SalasIndividualesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
