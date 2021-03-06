import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReceptionAddComponent } from './reception-add.component';

describe('ReceptionAddComponent', () => {
  let component: ReceptionAddComponent;
  let fixture: ComponentFixture<ReceptionAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReceptionAddComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ReceptionAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
