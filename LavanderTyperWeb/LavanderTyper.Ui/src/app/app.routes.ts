import { Routes } from '@angular/router';
import { GridComponent } from './components/company/grid/grid.component';
import { createComponent } from '@angular/core';
import { CreateCompanyComponent } from './components/company/create-company/create-company.component';

export const routes: Routes = [
    { path: 'company/grid', component: GridComponent },
    { path: 'company/create', component: CreateCompanyComponent },
];
