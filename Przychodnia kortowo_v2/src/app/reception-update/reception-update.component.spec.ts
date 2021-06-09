import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReceptionUpdateComponent } from './reception-update.component';

describe('ReceptionUpdateComponent', () => {
  let component: ReceptionUpdateComponent;
  let fixture: ComponentFixture<ReceptionUpdateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReceptionUpdateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ReceptionUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
