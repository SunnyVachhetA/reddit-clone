import { Component, OnInit } from "@angular/core";
import { IResponse } from "@app/models/shared/response.interface";
import { AuthService } from "@app/services/account/auth.service";
import { Observable, map, of } from "rxjs";

@Component({
    selector: 'user-feed',
    templateUrl: './user-feed.component.html',
    styleUrls: ['./user-feed.component.css']
})
export class UserFeedComponent implements OnInit {

    constructor(
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