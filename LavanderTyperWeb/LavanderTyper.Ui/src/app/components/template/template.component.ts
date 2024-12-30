import { Component } from '@angular/core';
import { SidebarComponent } from "../generics/sidebar/sidebar.component";

@Component({
  selector: 'app-template',
  standalone: true,
  imports: [SidebarComponent],
  templateUrl: './template.component.html',
  styleUrl: './template.component.scss'
})
export class TemplateComponent {

}
