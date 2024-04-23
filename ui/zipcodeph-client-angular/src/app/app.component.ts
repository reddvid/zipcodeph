import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { LogoComponent } from './core/components/logo/logo.component';
import { GroupListComponent } from "./groups/group-list.component";
@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: './app.component.html',
    styleUrl: './app.component.css',
    imports: [RouterOutlet, LogoComponent, GroupListComponent]
})
export class AppComponent {
  title = 'ZIP Code PH';
}
