import { inject } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivateFn, RouterStateSnapshot } from "@angular/router";
import { IUser } from "@app/models/shared/user.interface";
import { AuthService } from "@app/services/account/auth.service";

export const AuthGuard: CanActivateFn = (
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot) => {

    const user: IUser | null = inject(AuthService).loggedUser();

    return user !== null;
}