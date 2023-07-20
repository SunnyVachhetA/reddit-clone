import { Component, OnInit } from "@angular/core";
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { Patterns } from '@app/constants/patterns';
import { ValidationRules } from '@app/constants/validation-rules';
import { ConfirmPasswordValidator } from '@app/shared/Validators/confirm-password-validator';
import { passwordValidator } from '@app/shared/Validators/password.validator';
import { usernameValidator } from '@app/shared/Validators/username.validator';
import { IRegisterRequest } from '@app/models/account/register-request.interface';
import { RegisterService } from '@app/services/account/login.service';

@Component({
    selector: 'app-register',
    templateUrl: './register.component.html',
    styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit{

    registrationForm!: FormGroup;

    username!: FormControl;
    email!: FormControl;
    password!: FormControl;
    confirmPassword!: FormControl;

    constructor(
        private fb: FormBuilder,
        private registerService: RegisterService
    ){}

    ngOnInit(): void {
        this.createForm();
    }

    createForm(): void{

        this.email = new FormControl
        (
            '',
            [ 
                Validators.required, 
                Validators.minLength( ValidationRules.minEmailLength ), 
                Validators.maxLength( ValidationRules.maxEmailLength ),
                Validators.pattern( Patterns.email )
            ]
        );

        this.username = new FormControl
        (
            '',
            [ 
                Validators.required, 
                Validators.minLength( 3 ), 
                Validators.maxLength( ValidationRules.maxUserNameLength ),
                usernameValidator()
            ]
        );

        this.password = new FormControl
        (
            '',
            [ 
                Validators.required, 
                Validators.minLength( ValidationRules.minPasswordLength ), 
                Validators.maxLength( ValidationRules.maxPasswordLength ),
                passwordValidator()
            ]   
        );

        this.confirmPassword = new FormControl
        (
            '',
            [ 
                Validators.required, 
                ConfirmPasswordValidator()
            ]   
        );

        this.registrationForm = new FormGroup({
            username: this.username,
            email: this.email,
            password: this.password,
            confirmPassword: this.confirmPassword
        });
    }

    onSubmit(): void 
    {
        this.registrationForm.markAllAsTouched();

        if(this.registrationForm.invalid)
            return;

        const request: IRegisterRequest = this.GetRegisterData(); 

        this.registerService.register(request);
    }

    GetRegisterData(): IRegisterRequest
    {
        const request: IRegisterRequest = 
        {
            username: this.username.value,
            password: this.password.value,
            email: this.email.value
        };
        return request;
    }
}