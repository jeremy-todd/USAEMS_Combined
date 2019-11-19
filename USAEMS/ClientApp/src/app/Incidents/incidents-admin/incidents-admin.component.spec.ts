import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IncidentsAdminComponent } from './incidents-admin.component';

describe('IncidentsAdminComponent', () => {
  let component: IncidentsAdminComponent;
  let fixture: ComponentFixture<IncidentsAdminComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IncidentsAdminComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IncidentsAdminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
