import { HTTP_INTERCEPTORS, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { IUser } from "@app/models/shared/user.interface";
import { AuthService } from "@app/services/account/auth.service";
import { environment } from "@environments/environment";
import { Observable } from "rxjs";

@Injectable()
export class JwtInterceptor implements HttpInterceptor {

    constructor(
        private authService: AuthService
    ) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        const loggedUser: IUser | null = this.authService.loggedUser();

        const isApiRequest = req.url.startsWith(environment.apiUrl);

        debugger;
        
        if (loggedUser && isApiRequest) {
            req = req.clone({
                setHeaders: { Authorization: `Bearer ${loggedUser.accessToken}` }
            });
        }

        return next.handle(req);
    }

}

export const JWT_INTERCEPTOR = {
    provide: HTTP_INTERCEPTORS,
    multi: true,
    useClass: JwtInterceptor
}