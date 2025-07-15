import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentCatalog } from './student-catalog';

describe('StudentCatalog', () => {
  let component: StudentCatalog;
  let fixture: ComponentFixture<StudentCatalog>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [StudentCatalog]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StudentCatalog);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
