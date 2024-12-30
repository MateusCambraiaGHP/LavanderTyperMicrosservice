import { Component, Input } from '@angular/core';
import { Company } from '../models/company.model';
import { RowCustom } from '../../generics/form/models/row-input-custom.model';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CompanyService } from '../services/company.service';
import { ActivatedRoute } from '@angular/router';
import { InputType } from '../../generics/form/enums/input-type.enum';
import { FormComponent } from '../../generics/form/form.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-create-company',
  standalone: true,
  imports: [FormComponent, CommonModule],
  templateUrl: './create-company.component.html',
  styleUrl: './create-company.component.scss'
})
export class CreateCompanyComponent {
  @Input() readonly = false as boolean
  @Input()
  company!: Company;
  rows: RowCustom[] = [];
  form: FormGroup = new FormGroup({});
  isDeleted = false as boolean;
  title = this.company != null 
                ? "Edit Company" 
                : this.isDeleted 
                ? "Delete Company"
                :"Create Comapny" as string;
  item: any;
  isErro = false as boolean;

  federativeUnit = [
      { text: "MG", value: "1" },
      { text: "SP", value: "1" },
  ];

  constructor(private companyService: CompanyService,
      private route: ActivatedRoute) { }

  ngOnInit(): void {
      this.route.queryParams.subscribe(params => {
          if (params['item']) {
              this.company = JSON.parse(params['item']);
          }
      });
      this.fillInputs();
  }

  fillInputs() {
      this.rows = [
          {
              inputCustom: [
                  {
                      label: "Nome",
                      formControlName: "name",
                      control: new FormControl("", [Validators.required]),
                      type: InputType.text,
                      class: "col-md-4",
                  },
                  {
                      label: "Endereço",
                      formControlName: "address",
                      control: new FormControl("", [Validators.required]),
                      type: InputType.text,
                      class: "col-md-4",
                  },
                  {
                    label: "CNPJ",
                    formControlName: "cnpj",
                    control: new FormControl("", [Validators.required]),
                    type: InputType.text,
                    class: "col-md-4",
                },
              ],
          }
      ];
  }

  submitForm = async () => {
      const company: Company = {
          ...this.company,
          ...this.form.value,
      };

      // const resp = this.productReceived
      //     ? await this.customerService.update(Customer)
      //     : await this.customerService.create(Customer);

      const resp = await this.companyService.create(company);

      // this.backendErrors = resp?.errors;
      // if (this.backendErrors)
      //     this.isErro = true;
      return resp;
  };
}
