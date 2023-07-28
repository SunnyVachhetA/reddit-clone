import { inject } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivateFn, Router, RouterStateSnapshot } from "@angular/router";
import { IUser } from "@app/models/shared/user.interface";
import { AuthService } from "@app/services/account/auth.service";

export const LoggedUserGuard : CanActivateFn = (
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot) => {

    const user: IUser | null = inject(AuthService).loggedUser();

    if (user === null) return true;

    const router : Router = inject(Router);
    router.navigate(['/']);
    return false;
}