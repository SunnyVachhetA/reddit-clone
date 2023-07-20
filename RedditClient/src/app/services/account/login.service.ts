import { ILoginRequest } from '@app/models/account/login-request.interface';
import { BaseService } from '../shared/base.service';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '@environments/environment';
import { REGISTER_URL } from '@app/constants/config';
import { IRegisterRequest } from '@app/models/account/register-request.interface';

@Injectable({
    providedIn: 'root'
})
export class RegisterService extends BaseService<ILoginRequest>
{
    constructor(
        http: HttpClient
    ){
        super(http, `${environment.apiUrl}/${REGISTER_URL}`);
    }

    register(request: IRegisterRequest): void
    {
        console.log(request);
    }
}