import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PatientAddinfoComponent } from './patient-addinfo.component';

describe('PatientAddinfoComponent', () => {
  let component: PatientAddinfoComponent;
  let fixture: ComponentFixture<PatientAddinfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PatientAddinfoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PatientAddinfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
