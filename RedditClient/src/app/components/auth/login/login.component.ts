import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Patterns } from '@app/constants/patterns';
import { ValidationRules } from '@app/constants/validation-rules';
import { ILoginRequest } from '@app/models/account/login-request.interface';
import { ILoginResponse } from '@app/models/account/response/login-response.interface';
import { IResponse } from '@app/models/shared/response.interface';
import { AuthService } from '@app/services/account/auth.service';
import { CustomToastrService } from '@app/services/shared/custom-toastr.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class LoginComponent implements OnInit {

  loginForm!: FormGroup;

  username!: FormControl;
  password!: FormControl;

  showPassword: boolean = false;

  constructor(
    private formBuilder: FormBuilder,
    private toastr: CustomToastrService,
    private authService: AuthService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.createForm();
  }

  createForm(): void {
    this.username = new FormControl('',
      [
        Validators.required,
        Validators.min(ValidationRules.minUserNameLength),
        Validators.max(ValidationRules.maxEmailLength)
      ]);

    this.password = new FormControl('',
      [
        Validators.required,
        Validators.pattern(Patterns.password)
      ]);

    this.loginForm = this.formBuilder.group({
      username: this.username,
      password: this.password
    });
  }

  onSubmit(): void {
    this.loginForm.markAllAsTouched();

    if (this.loginForm.invalid)
      return;

    const request: ILoginRequest = this.createLoginRequest();

    this.authService.login(request)
      .subscribe((response: IResponse<ILoginResponse>) => {
        this.toastr.success(response.message);
        this.router.navigate(['/']);
      });
  }

  createLoginRequest(): ILoginRequest {
    const request: ILoginRequest = {
      username: this.username.value,
      password: this.password.value
    }
    return request;
  }

}
