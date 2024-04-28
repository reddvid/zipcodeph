import { Component } from '@angular/core';

@Component({
  selector: 'app-area-item',
  standalone: true,
  imports: [],
  template: `
   <div *ngIf="!areas?.length">
    Loading data...
  </div>
  <ul class="list">
    
</ul>
  `,
  styles: ``
})
export class AreaItemComponent {

}
