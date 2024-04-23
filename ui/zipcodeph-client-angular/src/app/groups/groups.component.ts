import { Component } from '@angular/core';
import { ListHeaderComponent } from "../shared/list-header/list-header.component";

@Component({
    selector: 'app-groups',
    standalone: true,
    template: `
    <div class="content-container">
      <app-list-header ></app-list-header>
    </div>
  `,
    styles: ``,
    imports: [ListHeaderComponent]
})

export class GroupsComponent {

}
