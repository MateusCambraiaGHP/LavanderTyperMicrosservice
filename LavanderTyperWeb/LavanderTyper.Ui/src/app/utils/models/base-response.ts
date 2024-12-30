export class BaseResponse<T> {
    response: T[] | any[] = [];
    success: boolean = false;
    message: string = "";
    validationErrors: string[] = [];
}