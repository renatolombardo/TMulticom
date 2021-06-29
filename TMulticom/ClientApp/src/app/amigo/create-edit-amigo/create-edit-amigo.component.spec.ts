import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateEditAmigoComponent } from './create-edit-amigo.component';

describe('CreateEditAmigoComponent', () => {
  let component: CreateEditAmigoComponent;
  let fixture: ComponentFixture<CreateEditAmigoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateEditAmigoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateEditAmigoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
