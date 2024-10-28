import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PageNotFounrComponent } from './page-not-founr.component';

describe('PageNotFounrComponent', () => {
  let component: PageNotFounrComponent;
  let fixture: ComponentFixture<PageNotFounrComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PageNotFounrComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PageNotFounrComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
