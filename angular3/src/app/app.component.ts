import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterOutlet } from '@angular/router';
import { CounterComponent } from './components/counter.component.ts/counter.component.ts.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,FormsModule,CounterComponent],
  template: `
     <p>Your color preference is {{ theme }}.</p>
    <button [disabled]="isFormValid">Save</button>
    <ul [style]="listStyles"> <li>hi</li>
    <li>hlooo</li> </ul>
    <section [style]="sectionStyles" [style.height.px]="sectionHeightInPixels" [style.display]="isExpanded ? 'block' : 'none'">Lorem ipsum dolor sit amet consectetur, adipisicing elit. Deleniti porro impedit ducimus alias necessitatibus fugit praesentium facilis quod earum sint!
    <main>
      <h2>Hello {{ firstName }}!</h2>
      <input type="text" [(ngModel)]="firstName" />
    </main>
     Lorem ipsum dolor sit amet consectetur adipisicing elit. Cum voluptatem a fugiat qui blanditiis dolores debitis incidunt doloremque laborum quam.</section>
     @for(item of emp;track item.id )
     {
      {{$first}}
      {{$index}}{{item.name}} {{$count}}
      {{$last}}
     }@empty {
    <li aria-hidden="true"> There are no items. </li>
     }
    <button [class]="buttonClasses"> Click me </button>
    <main>
      <app-counter [(count)]="initialCount"></app-counter>
      <!-- @if (20 > {count}}) {
  <p>{{a}} is greater than {{b}}</p>
} -->
    </main>
    <!-- @switch (userPermissions) {
  @case ('admin') {
    <app-admin-dashboard />
  }
  @case ('reviewer') {
    <app-reviewer-dashboard />
  }
  @case ('editor') {
    <app-editor-dashboard />
  }
  @default {
    <app-viewer-dashboard />
  } 
}-->
  `,
  // templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  emp=[{id:1,name:'a'},{id:2,name:'b'},{id:3,name:'c'},{id:4,name:'d'},{id:5,name:'e'}];
  sectionHeightInPixels=400;
  theme = 'dark';
  isFormValid=true;
  listStyles = 'display: flex; padding: 8px';
  sectionStyles = {
    border: '1px solid black',
    'font-weight': 'bold',
  };
  isExpanded=true;
  buttonClasses = {
    highlighted: true,
    embiggened: false,
  };
  firstName="AShna";
  initialCount=18;
}
