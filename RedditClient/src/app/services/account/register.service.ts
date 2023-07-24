import { BaseService } from '../shared/base.service';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '@environments/environment';
import { REGISTER_URL } from '@app/constants/config';
import { IRegisterRequest } from '@app/models/account/register-request.interface';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class RegisterService extends BaseService<IRegisterRequest>
{
    constructor(
        http: HttpClient
    ){
        super(http, `${environment.apiUrl}/${REGISTER_URL}`);
    }

    register(request: IRegisterRequest): Observable<any>
    {
        return this.add(request);
    }
}