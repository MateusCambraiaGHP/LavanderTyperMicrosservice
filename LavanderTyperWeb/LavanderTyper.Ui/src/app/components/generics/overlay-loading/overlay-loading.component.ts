import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { MatProgressSpinner } from '@angular/material/progress-spinner';

@Component({
  selector: 'app-overlay-loading',
  standalone: true,
  imports: [MatProgressSpinner, CommonModule],
  templateUrl: './overlay-loading.component.html',
  styleUrl: './overlay-loading.component.scss',
})
export class OverlayLoadingComponent {
  @Input() isLoading: Boolean | undefined;
  loading: boolean = true;

  constructor() {}
}
