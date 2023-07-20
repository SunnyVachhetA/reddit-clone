import { NgModule } from "@angular/core";
import { HeaderComponent } from './header/header.component';
import { CommonModule } from '@angular/common';

import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

const components = [
    HeaderComponent
];

@NgModule({
    declarations: [
        ...components
    ],
    imports: [
        CommonModule,
        RouterModule,
        NgbModule
    ],
    exports: [
        ...components,
        NgbModule
    ],
    providers: []
})
export class SharedModule {
}