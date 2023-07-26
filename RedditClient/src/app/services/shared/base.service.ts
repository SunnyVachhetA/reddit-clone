import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError, catchError } from 'rxjs';
import { IResponse } from '@app/models/shared/response.interface';
import { IRegisterRequest } from '@app/models/account/register-request.interface';

@Injectable({
    providedIn: 'root'
})
export class BaseService<T>
{
    constructor(
        protected http: HttpClient,
        @Inject('BASE_URL') private url: string
    ) { }

    add(data: T): Observable<IResponse<T>> {
        debugger;
        return this.http
                    .post<IResponse<T>>(this.url, data);
    }
}