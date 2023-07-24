import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError, catchError } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class BaseService<T> 
{
    constructor(
        protected http: HttpClient,
        @Inject('BASE_URL') private url: string
    )
    {}

    add(data: T): Observable<any>
    {
        return this.http
                        .post(this.url, data)
                        .pipe(
                            catchError((err: any) => {
                                console.error(err.error.Message);
                                return throwError(err);
                            })
                        );
    }
}