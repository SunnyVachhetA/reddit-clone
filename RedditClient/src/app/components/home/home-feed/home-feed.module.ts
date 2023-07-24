import { NgModule } from "@angular/core";
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { HomeFeedRoutingModule } from './home-feed-routing.module';
import { UserFeedComponent } from './user-feed/user-feed.component';

@NgModule({
    imports: [
        CommonModule,
        HomeFeedRoutingModule
    ],
    declarations: [
        UserFeedComponent
    ],
    exports: [],
    providers: []
})
export class HomeFeedModule {}