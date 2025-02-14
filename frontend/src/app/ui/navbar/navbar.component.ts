import { Component, NgModule } from '@angular/core';
import { RouterLink } from '@angular/router';
import { UserOptionsComponent } from '../../features/user/user-options/user-options.component';

@Component({
  selector: 'nav-component',
  imports: [RouterLink, UserOptionsComponent],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css',
})
export class NavbarComponent {}
