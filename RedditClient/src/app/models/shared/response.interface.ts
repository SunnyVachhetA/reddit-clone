export interface IResponse<T>
{
    data?: T | null,
    statusCode: number,
    success: boolean,
    message: string,
    errors: any
}