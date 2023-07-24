import { NgModule } from "@angular/core";
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from '../auth/login/login.component';
import { RegisterComponent } from '../auth/register/register.component';
import { UserFeedComponent } from './home-feed/user-feed/user-feed.component';

const routes : Routes = [
    {
        path: 'login',
        component: LoginComponent,
        loadChildren: () => import('../auth/auth.module')
                              .then(module => module.AuthModule)
    },
    {
        path: 'register',
        component: RegisterComponent,
        loadChildren: () => import('../auth/auth.module')
                              .then(module => module.AuthModule)
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
export class HomeRoutingModule{}