import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalEditSalaComponent } from './modal-edit-sala.component';

describe('ModalEditSalaComponent', () => {
  let component: ModalEditSalaComponent;
  let fixture: ComponentFixture<ModalEditSalaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ModalEditSalaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ModalEditSalaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
