import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from "@angular/core";
import { HomeComponent } from './home.component';
import { CommonModule } from '@angular/common';
import { HomeRoutingModule } from './home-routing.module';
import { SharedModule } from '../shared/shared.module';


@NgModule({
    declarations: [
        HomeComponent
    ],
    exports: [],
    imports: [
        CommonModule,
        SharedModule,
        HomeRoutingModule
    ],
    providers: []
})
export class HomeModule {}