import { Component, OnInit, ChangeDetectionStrategy } from "@angular/core";
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { ValidationRules } from '@app/constants/validation-rules';
import { ConfirmPasswordValidator } from '@app/shared/Validators/confirm-password-validator';
import { passwordValidator } from '@app/shared/Validators/password.validator';
import { usernameValidator } from '@app/shared/Validators/username.validator';
import { IRegisterRequest } from '@app/models/account/register-request.interface';
import { RegisterService } from '@app/services/account/register.service';
import { emailValidator } from '@app/shared/Validators/email.validator';
import { IResponse } from '@app/models/shared/response.interface';
import { CustomToastrService } from "@app/services/shared/custom-toastr.service";
import { Router } from "@angular/router";

@Component({
    selector: 'app-register',
    templateUrl: './register.component.html',
    styleUrls: ['./register.component.css'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class RegisterComponent implements OnInit {

    registrationForm!: FormGroup;

    username!: FormControl;
    email!: FormControl;
    password!: FormControl;
    confirmPassword!: FormControl;

    constructor(
        private fb: FormBuilder,
        private registerService: RegisterService,
        private toastrService: CustomToastrService,
        private router: Router
    ) { }

    ngOnInit(): void {
        this.createForm();
    }

    createForm(): void {

        this.email = new FormControl
            (
                'sun@gmail.com',
                [
                    Validators.required,
                    Validators.minLength(ValidationRules.minEmailLength),
                    Validators.maxLength(ValidationRules.maxEmailLength),
                    emailValidator()
                ]
            );

        this.username = new FormControl
            (
                'sun_pirate',
                [
                    Validators.required,
                    Validators.minLength(3),
                    Validators.maxLength(ValidationRules.maxUserNameLength),
                    usernameValidator()
                ]
            );

        this.password = new FormControl
            (
                'Test@123',
                [
                    Validators.required,
                    Validators.minLength(ValidationRules.minPasswordLength),
                    Validators.maxLength(ValidationRules.maxPasswordLength),
                    passwordValidator()
                ]
            );

        this.confirmPassword = new FormControl
            (
                'Test@123',
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

    onSubmit(): void {
        this.registrationForm.markAllAsTouched();

        if (this.registrationForm.invalid)
            return;

        const request: IRegisterRequest = this.registrationForm.value;

        debugger;
        this.registerService.register(request)
            .subscribe({
                next: (response: IResponse<IRegisterRequest>) => {
                    this.router.navigate(['/login']);
                    this.toastrService.success(response.message);
                }
            });
    }
}
