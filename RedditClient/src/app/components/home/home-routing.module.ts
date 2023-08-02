import { NgModule } from "@angular/core";
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from '../auth/login/login.component';
import { RegisterComponent } from '../auth/register/register.component';
import { UserFeedComponent } from './home-feed/user-feed/user-feed.component';
import { AuthGuard } from "@app/guards/auth.guard";
import { LoggedUserGuard } from "@app/guards/logged-user.guard";
import { UpsertSubredditComponent } from "../subreddit/upsert-subreddit/upsert-subreddit.component";

const routes: Routes = [
    {
        path: 'login',
        component: LoginComponent,
        canActivate: [LoggedUserGuard],
        loadChildren: () => import('../auth/auth.module')
            .then(module => module.AuthModule)
    },
    {
        path: 'register',
        component: RegisterComponent,
        canActivate: [LoggedUserGuard],
        loadChildren: () => import('../auth/auth.module')
            .then(module => module.AuthModule)
    },

    {
        path: 'create-subreddit',
        component: UpsertSubredditComponent,
        loadChildren: () => import('../subreddit/sub-reddit.module')
            .then(module => module.SubRedditModule)
    },
    {
        path: '',
        component: UserFeedComponent,
        loadChildren: () => import('./home-feed/home-feed.module').then(module => module.HomeFeedModule),
        pathMatch: 'full'
    }
];

@NgModule({
    imports: [
        RouterModule.forChild(routes),
    ],
    exports: [
        RouterModule
    ]
})
export class HomeRoutingModule { }