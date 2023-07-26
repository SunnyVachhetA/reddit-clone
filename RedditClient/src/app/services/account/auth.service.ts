import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ACCOUNT_URL, LOGIN_URL } from "@app/constants/config";
import { ILoginRequest } from "@app/models/account/login-request.interface";
import { ILoginResponse } from "@app/models/account/response/login-response.interface";
import { IResponse } from "@app/models/shared/response.interface";
import { IUser } from "@app/models/shared/user.interface";
import { environment } from "@environments/environment";
import { BehaviorSubject, Observable, Subject, map, shareReplay } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class AuthService {

    private userSubject: BehaviorSubject<IUser | null>;
    public user: Observable<IUser | null>;

    constructor(
        private http: HttpClient
    ) { 
        this.userSubject = new BehaviorSubject<IUser | null>(null);
        this.user = this.userSubject.asObservable();
    }

    loggedUser() : IUser | null
    {
        return this.userSubject.value;
    }

    login(request: ILoginRequest): Observable<IResponse<ILoginResponse>> {
        return this.http
            .post<IResponse<ILoginResponse>>(`${environment.apiUrl}/${LOGIN_URL}`, request)
            .pipe(
                map((response: IResponse<ILoginResponse>) => {

                    this.userSubject.next( 
                        { 
                          email: response.data?.email, 
                          username: response.data?.username,
                          accessToken: response.data?.accessToken
                        } as IUser
                    );

                    return response;
                })
            );
    }

    secureResource() : Observable<IResponse<string>> {
        return this.http
                    .get<IResponse<string>>(`${environment.apiUrl}/${ACCOUNT_URL}`);
    }
}