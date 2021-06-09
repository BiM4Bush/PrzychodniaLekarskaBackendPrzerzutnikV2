import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReceptionGastrologComponent } from './reception-gastrolog.component';

describe('ReceptionGastrologComponent', () => {
  let component: ReceptionGastrologComponent;
  let fixture: ComponentFixture<ReceptionGastrologComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReceptionGastrologComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ReceptionGastrologComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
