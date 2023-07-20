import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

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
}