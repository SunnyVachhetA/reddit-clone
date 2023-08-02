import { Component, OnInit } from "@angular/core";
import { ILoginResponse } from "@app/models/account/response/login-response.interface";
import { IResponse } from "@app/models/shared/response.interface";
import { AuthService } from "@app/services/account/auth.service";
import { CustomToastrService } from "@app/services/shared/custom-toastr.service";

@Component({
    selector: 'user-feed',
    templateUrl: './user-feed.component.html',
    styleUrls: ['./user-feed.component.css']
})
export class UserFeedComponent implements OnInit {

    constructor(
        private authService: AuthService,
        private toastrService: CustomToastrService
    ) { }


    ngOnInit(): void {
    }
}


// data: Observable<string | null> = of(null);
// fetchSecureResource()
// {
//     this.data = this.authService.secureResource()
//         .pipe(
//             map((res : IResponse<string>) =>
//             {
//                 debugger;
//                 return res.message;
//             })
//         );
// }