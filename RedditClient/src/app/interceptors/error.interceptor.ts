import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpEvent, HttpHandler, HttpRequest, HttpErrorResponse, HTTP_INTERCEPTORS } from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';
import { IResponse } from '@app/models/shared/response.interface';
import { CustomToastrService } from '@app/services/shared/custom-toastr.service';


@Injectable({
    providedIn: 'root'
})
export class ErrorInterceptor implements HttpInterceptor {

    constructor(
        private toastrService: CustomToastrService
    ) 
    {}

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(req)
                    .pipe(
                        catchError((error: HttpErrorResponse) => {
                            console.error(error);

                            if (error.error instanceof ErrorEvent) {
                                console.error('This is client side error');
                                console.error(error.error);
                                return throwError(() => error.error);
                            }

                            const errorResponse : IResponse<any> = {
                                data: error?.error?.Data,
                                message: error?.error?.Message,
                                errors: error?.error?.Errors,
                                statusCode: error?.error?.StatusCode,
                                success: error?.error?.Success
                            };
                            
                            this.displayError(errorResponse.message, errorResponse.errors);

                            return throwError(() => errorResponse);
                        })
                    );
    }

    displayError(message: string, errors?: string[]): void
    {
        debugger;
        if( errors === undefined || errors === null )
        {
            this.toastrService.error(message);
        }
        else 
        {
            errors.forEach(error => this.toastrService.error(error));
        }
    }
}

export const CUSTOM_ERROR_INTERCEPTOR = 
{
    provide: HTTP_INTERCEPTORS,
    useClass: ErrorInterceptor,
    multi: true
}