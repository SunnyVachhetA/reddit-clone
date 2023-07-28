import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ACCOUNT_URL, LOGIN_URL } from "@app/constants/config";
import { ILoginRequest } from "@app/models/account/login-request.interface";
import { ILoginResponse } from "@app/models/account/response/login-response.interface";
import { IResponse } from "@app/models/shared/response.interface";
import { IUser } from "@app/models/shared/user.interface";
import { environment } from "@environments/environment";
import { BehaviorSubject, Observable, map } from "rxjs";
import { LocalStorageService } from "../shared/local-storage.service";
import { LocalStorageKeys } from "@app/constants/local-storage-keys";

@Injectable({
    providedIn: 'root'
})
export class AuthService {
    private userSubject: BehaviorSubject<IUser | null>;
    public user: Observable<IUser | null>;

    constructor(
        private http: HttpClient,
        private storageService: LocalStorageService
    ) {
        this.userSubject = new BehaviorSubject<IUser | null>(
            this.storageService.getItem( LocalStorageKeys.USER_KEY )
        );
        this.user = this.userSubject.asObservable();
    }

    loggedUser(): IUser | null {
        return this.userSubject.value;
    }

    login(request: ILoginRequest): Observable<IResponse<ILoginResponse>> {
        return this.http
            .post<IResponse<ILoginResponse>>(`${environment.apiUrl}/${LOGIN_URL}`, request, {
                withCredentials: true,
                headers: {
                    credentials: 'include'
                }
            })
            .pipe(
                map((response: IResponse<ILoginResponse>) => {
                    if (response.data === null || response.data === undefined) {
                        return response;
                    }

                    const principalUser: IUser = {
                        email: response.data.email,
                        username: response.data.username,
                        accessToken: response.data.accessToken
                    };

                    this.userSubject.next(principalUser);

                    this.storageService.setItem(LocalStorageKeys.USER_KEY, principalUser);
                    return response;
                })
            );
    }

    refreshToken() : Observable<IResponse<ILoginResponse>> {
        debugger;
        console.log(document.cookie);
        return this.http.post<IResponse<ILoginResponse>>(`${environment.apiUrl}/${ACCOUNT_URL}/refresh-token`, {},
        {
            withCredentials: true,
            headers: {
                credentials: 'include'
            }
        });

    }

}