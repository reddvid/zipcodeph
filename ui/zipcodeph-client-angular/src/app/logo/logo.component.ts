import { Component } from '@angular/core';

@Component({
  selector: 'app-logo',
  standalone: true,
  imports: [],
  template: `
    <div class="row">
      <svg class="zipcodeph-logo" viewBox="0 0 64 64" version="1.1" xmlns="http://www.w3.org/2000/svg"
        xmlns:xlink="http://www.w3.org/1999/xlink" xml:space="preserve" xmlns:serif="http://www.serif.com/"
        style="fill-rule:evenodd;clip-rule:evenodd;stroke-linejoin:round;stroke-miterlimit:2;">
        <g id="zipcodeph-logo.svg" serif:id="zipcodeph-logo.svg" transform="matrix(0.115301,0,0,0.115301,32,32)">
          <g transform="matrix(1,0,0,1,-254,-292)">
            <g>
              <g id="Layer_2">
                <g id="Layer_2-2">
                  <path
                    d="M471.93,253.78C471.93,133.5 374.43,36 254.16,36L254.16,548L393.49,421.14C398.417,417.027 403.16,412.71 407.72,408.19L407.8,408.11C448.899,367.302 472.005,311.697 471.93,253.78Z"
                    style="fill:url(#_Radial1);fill-rule:nonzero;" />
                  <path
                    d="M254.16,36C133.88,36 36.38,133.5 36.38,253.78C36.319,319.259 65.851,381.379 116.67,422.67L254.16,547.87L254.16,36Z"
                    style="fill:url(#_Radial2);fill-rule:nonzero;" />
                </g>
                <g id="Stars">
                  <path
                    d="M254.16,59.54L263.18,87.3L292.37,87.3L268.75,104.46L277.78,132.23L254.16,115.07L230.54,132.23L239.56,104.46L215.94,87.3L245.14,87.3L254.16,59.54Z"
                    style="fill:rgb(255,255,51);fill-rule:nonzero;" />
                  <path
                    d="M89.09,362.87L108.63,341.18L94.03,315.9L120.7,327.77L140.24,306.07L137.19,335.11L163.86,346.98L135.3,353.05L132.25,382.09L117.65,356.8L89.09,362.87Z"
                    style="fill:rgb(255,255,51);fill-rule:nonzero;" />
                  <path
                    d="M419.22,362.87L390.67,356.8L376.07,382.09L373.02,353.05L344.46,346.98L371.13,335.11L368.08,306.07L387.61,327.77L414.28,315.9L399.69,341.18L419.22,362.87Z"
                    style="fill:rgb(255,255,51);fill-rule:nonzero;" />
                </g>
                <g id="Layer_4">
                  <circle cx="254.16" cy="253.78" r="90.3" style="fill:url(#_Linear3);" />
                </g>
              </g>
            </g>
          </g>
        </g>
        <g id="Layer1">
        </g>
        <g id="Layer-1" serif:id="Layer 1">
        </g>
        <defs>
          <radialGradient id="_Radial1" cx="0" cy="0" r="1" gradientUnits="userSpaceOnUse"
            gradientTransform="matrix(216.07,0,0,216.07,254.69,252.82)">
            <stop offset="0" style="stop-color:rgb(255,63,63);stop-opacity:1" />
            <stop offset="1" style="stop-color:rgb(255,0,0);stop-opacity:1" />
          </radialGradient>
          <radialGradient id="_Radial2" cx="0" cy="0" r="1" gradientUnits="userSpaceOnUse"
            gradientTransform="matrix(204.25,0,0,204.25,246.03,251.99)">
            <stop offset="0" style="stop-color:rgb(42,103,255);stop-opacity:1" />
            <stop offset="0.19" style="stop-color:rgb(40,99,254);stop-opacity:1" />
            <stop offset="0.39" style="stop-color:rgb(36,86,253);stop-opacity:1" />
            <stop offset="0.6" style="stop-color:rgb(28,64,250);stop-opacity:1" />
            <stop offset="1" style="stop-color:rgb(6,0,242);stop-opacity:1" />
          </radialGradient>
          <linearGradient id="_Linear3" x1="0" y1="0" x2="1" y2="0" gradientUnits="userSpaceOnUse"
            gradientTransform="matrix(180.6,0,0,180.6,163.86,253.78)">
            <stop offset="0" style="stop-color:rgb(251,255,105);stop-opacity:1" />
            <stop offset="0.09" style="stop-color:rgb(251,255,105);stop-opacity:1" />
            <stop offset="0.28" style="stop-color:rgb(251,248,97);stop-opacity:1" />
            <stop offset="0.58" style="stop-color:rgb(249,229,74);stop-opacity:1" />
            <stop offset="0.78" style="stop-color:rgb(248,212,55);stop-opacity:1" />
            <stop offset="1" style="stop-color:rgb(248,212,55);stop-opacity:1" />
          </linearGradient>
        </defs>
      </svg>
      <span>ZIP Code PH</span>
  `,
  styleUrl: './logo.component.css'
})
export class LogoComponent {

}
