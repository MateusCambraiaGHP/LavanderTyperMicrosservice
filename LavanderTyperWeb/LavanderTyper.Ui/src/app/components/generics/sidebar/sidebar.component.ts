import { AfterViewInit, Component, ElementRef, Renderer2 } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [],
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.scss'
})
export class SidebarComponent implements AfterViewInit {

  
  constructor(private renderer: Renderer2, private el: ElementRef, private router: Router) {}

  ngAfterViewInit(): void {
    const sidebar = this.el.nativeElement.querySelector('#sidebar');
    const content = this.el.nativeElement.querySelector('#content');
    const sidebarCollapse = this.el.nativeElement.querySelector('#sidebarCollapse');

    if (sidebarCollapse) {
      this.renderer.listen(sidebarCollapse, 'click', () => {
        if (sidebar) {
          sidebar.classList.toggle('active');
        }
        if (content) {
          content.classList.toggle('active');
        }
      });
    }
  }

  redirectToRoute(){
    this.router.navigate(['company/grid']);
  }
}
