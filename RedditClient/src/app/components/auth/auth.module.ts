import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from "@angular/core";
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';
import { FormModule } from '../controls/form/form.module';

const components = [
    LoginComponent,
    RegisterComponent
];

@NgModule({
    declarations: [
        ...components
    ],
    imports: [
        CommonModule,
        ReactiveFormsModule,
        SharedModule,
        FormModule
    ],
    providers: [],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AuthModule {}