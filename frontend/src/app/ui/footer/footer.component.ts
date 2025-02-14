import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'footer-component',
  imports: [CommonModule],
  templateUrl: './footer.component.html',
  styleUrl: './footer.component.css',
})
export class FooterComponent {
  age = 5;
}
