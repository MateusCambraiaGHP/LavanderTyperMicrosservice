import { API_URL, HEADERS } from './constants';
import { OptionsRequest } from './models/options-request.model';

export const get = <T>(route: string, options?: OptionsRequest) =>
  baseRequest<T>('GET', route, options);
export const post = <T>(route: string, options?: OptionsRequest) =>
  baseRequest<T>('POST', route, options);
export const put = <T>(route: string, options?: OptionsRequest) =>
  baseRequest<T>('PUT', route, options);
export const del = <T>(route: string, options?: OptionsRequest) =>
  baseRequest<T>('DELETE', route, options);

async function baseRequest<T>(
  method: string,
  route: string,
  options?: OptionsRequest
): Promise<T | null> {
  const body = JSON.stringify(options?.body);
  const queryParams = options?.query
    ? '?' + new URLSearchParams(options.query).toString()
    : '';

  try {
    const response = await fetch(`${API_URL}${route}${queryParams}`, {
      method,
      headers: {
        'Content-Type': 'application/json',
      },
      mode: 'cors',
      body: method !== 'GET' ? body : undefined,
    });

    if (!response.ok) {
      throw new Error(`HTTP error! Status: ${response.status}`);
    }

    const responseJson = await response.json();
    return responseJson;
  } catch (error) {
    return null;
  }
}
