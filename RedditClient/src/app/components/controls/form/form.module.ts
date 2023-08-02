import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { InputComponent } from './input/input.component';
import { DropdownComponent } from './dropdown/dropdown.component';
import { CheckboxComponent } from './checkbox/checkbox.component';
import { TextboxComponent } from './textbox/textbox.component';
import { RichTextboxComponent } from './rich-textbox/rich-textbox.component';
import { CKEditorModule } from "@ckeditor/ckeditor5-angular";
import { FileUploadComponent } from './file-upload/file-upload.component';

const components = [
    InputComponent,
    DropdownComponent,
    CheckboxComponent,
    TextboxComponent,
    RichTextboxComponent,
    FileUploadComponent,
];

@NgModule({
    declarations: [
        ...components,
    ],
    imports: [
        CommonModule,
        ReactiveFormsModule,
        FormsModule, 
        CKEditorModule
    ],
    exports: [
        ...components
    ]
})
export class FormModule {}