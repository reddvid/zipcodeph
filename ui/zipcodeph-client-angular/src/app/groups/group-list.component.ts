import { Component } from '@angular/core';
import { GroupItemComponent } from "./group-item.component";

@Component({
  selector: 'app-group-list',
  standalone: true,
  template: `
  <div class="row">
    <div class="group-list-flex">
      <app-group-item class="group-item" [title]="ncr">
      </app-group-item>
      <app-group-item class="group-item" [title]="luzon">
      </app-group-item>
      <app-group-item class="group-item" [title]="visayas">
      </app-group-item>
      <app-group-item class="group-item" [title]="mindanao">
      </app-group-item>
    </div>
</div>
  `,
  styles: `
    .group-list-flex {
      display: flex;
      flex-flow: row wrap;
      flex-grow: 1;
      justify-content: center;
    }
    .group-item {
      flex-basis: 50%;
    }
    `,
  imports: [GroupItemComponent]
})


export class GroupListComponent {
  ncr = 'Metro Manila';
  luzon = 'Luzon';
  visayas = 'Visayas';
  mindanao = 'Mindanao';
}
