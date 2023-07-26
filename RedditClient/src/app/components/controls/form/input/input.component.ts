import { Component, EventEmitter, Input, Output, OnInit } from "@angular/core";
import { FormControl, FormGroup } from '@angular/forms';

@Component({
    selector: 'app-input',
    templateUrl: './input.component.html',
    styleUrls: ['./input.component.css']
})
export class InputComponent implements OnInit {

    control!: FormControl;

    @Input()
    title!: string;

    @Input()
    name!: string;

    @Input()
    controlName!: string;

    @Input()
    parentForm!: FormGroup;

    @Input()
    placeholder!: string;

    @Input()
    readonly: boolean = false;

    @Input()
    pattern!: string;

    @Input()
    autocomplete!: string;

    @Input()
    type!: string;

    eyeVisible: boolean = false;

    toggleEyeVisibility(): void {
        this.eyeVisible = !this.eyeVisible;
    }

    ngOnInit(): void {
        this.control = this.parentForm.get(this.controlName) as FormControl;
    }
}