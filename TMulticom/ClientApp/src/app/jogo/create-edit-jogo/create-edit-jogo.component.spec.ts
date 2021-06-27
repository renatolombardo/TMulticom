import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateEditJogoComponent } from './create-edit-jogo.component';

describe('CreateEditJogoComponent', () => {
  let component: CreateEditJogoComponent;
  let fixture: ComponentFixture<CreateEditJogoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateEditJogoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateEditJogoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
