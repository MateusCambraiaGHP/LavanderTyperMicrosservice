import { Component, OnInit } from '@angular/core';
import { CompanyService } from '../services/company.service';
import { HeaderTable } from '../../generics/table/models/header-table.model';
import { TableComponent } from '../../generics/table/table.component';
import { CommonModule } from '@angular/common';
import { LayoutComponent } from '../../generics/layout/layout.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-grid',
  standalone: true,
  imports: [TableComponent, CommonModule, LayoutComponent],
  templateUrl: './grid.component.html',
  styleUrls: ['./grid.component.scss'],
})
export class GridComponent implements OnInit {
  loading = true;
  typeObject = 'company';

  headers: HeaderTable[] = [
    { title: 'Nome', prop: 'name', width: '80px' },
    {
      title: 'Nome Fantasia',
      prop: 'fantasyName',
      width: '80px',
      textAlign: 'center',
    },
    { title: 'Ativo?', prop: 'active', width: '80px', textAlign: 'center' },
    { title: 'Telefone', prop: 'phone', width: '80px', textAlign: 'center' },
    { title: 'Cadastro', prop: 'adress', width: '80px', textAlign: 'center' },
  ];

  constructor(public companyService: CompanyService, public router: Router) {}

  async ngOnInit(): Promise<void> {
    await this.companyService.fetchCompanies();
  }

  redirectUrl = () => {
    this.router.navigate(['/company/create']);
  };

  deleteProduct = (productId: string) => async () => {
    const resp = await this.companyService.delete(productId);
  };

  get products() {
    return this.companyService.response.response;
  }
}
