import { Injectable } from "@angular/core";
import { Company } from "../models/company.model";
import { LavanderTyperApi } from "../../../api/lavandertyper-api";
import { BaseResponse } from "../../../utils/models/base-response";

@Injectable({
    providedIn: "root",
})
export class CompanyService {
    response: BaseResponse<Company> = {} as any;
    loading: boolean = false;

    constructor() {}

    fetchCompanies = async () => {
        this.loading = true;
        const resp = await LavanderTyperApi.Company.getAll();
        if (resp) this.response = resp;
        this.loading = false;
    };

    getById = async (id: number) => {
        this.loading = true;
        const resp = await LavanderTyperApi.Company.getById(id);
        if (resp) this.response = resp;
        this.loading = false;
    };

    create = async (product: Company) => {
        const resp = await LavanderTyperApi.Company.create(product);
        if (resp) this.fetchCompanies();
        return resp;
    };

    update = async (product: Company) => {
        const resp = await LavanderTyperApi.Company.update(product);
        if (resp) this.fetchCompanies();
        return resp;
    };

    delete = async (productId: string) => {
        const resp = await LavanderTyperApi.Company.delete(
            productId
        );
        if (resp) this.fetchCompanies();
        return resp;
    };
}