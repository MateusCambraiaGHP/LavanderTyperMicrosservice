import * as qs from 'qs';
import { get, put, post, del } from './methods';
import { Company } from '../components/company/models/company.model';
import { BaseResponse } from '../utils/models/base-response';

export const LavanderTyperApi = {
  Company: {
    getAll: () =>
      get<BaseResponse<Company>>(`/company`, {
        query: {
          correlationalId: '23123123',
        },
      }),
    getById: (id: number) =>
      get<BaseResponse<Company>>(`/company/${id}`, {
        query: {
          correlationalId: '23123123',
        },
      }),
    delete: (id: string) =>
      del<BaseResponse<Company>>(`/company/${qs.stringify({ id })}`, {
        query: {
          correlationalId: '23123123',
        },
      }),
    update: (body: Company) =>
      put<BaseResponse<Company>>(`/company`, {
        body,
        query: {
          correlationalId: '23123123',
        },
      }),
    create: (body: Company) =>
      post<BaseResponse<Company>>(`/company`, {
        body,
        query: {
          correlationalId: '23123123',
        },
      }),
  },
};
