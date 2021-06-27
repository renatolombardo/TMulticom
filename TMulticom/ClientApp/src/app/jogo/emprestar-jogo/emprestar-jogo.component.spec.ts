import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EmprestarJogoComponent } from './emprestar-jogo.component';

describe('EmprestarJogoComponent', () => {
  let component: EmprestarJogoComponent;
  let fixture: ComponentFixture<EmprestarJogoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EmprestarJogoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EmprestarJogoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
