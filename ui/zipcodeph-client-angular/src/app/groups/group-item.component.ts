import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-group-item',
  standalone: true,
  imports: [],
  template: `
    <div class="group-item">
      <h2>{{title}}</h2>
    </div>
  `,
  styles: `
  .group-item {
    height: 4rem;
    box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2);
    align-items: center;
    justify-content: center;
    transition: 0.3s;
  }
  h2 {
    text-align: center;
  }
  `
})
export class GroupItemComponent implements OnInit {
  @Input() title!: string;
  
  ngOnInit() { }


}
