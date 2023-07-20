export interface IResponse<T>
{
    data: T,
    statusCode: number,
    success: boolean,
    message: string,
    error: any
}