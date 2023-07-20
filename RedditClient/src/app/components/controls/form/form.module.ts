import { NgModule } from "@angular/core";
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { InputComponent } from './input/input.component';

const components = [
    InputComponent
];

@NgModule({
    declarations: [
        ...components
    ],
    imports: [
        CommonModule,
        ReactiveFormsModule
    ],
    exports: [
        ...components
    ]
})
export class FormModule {}