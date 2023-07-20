import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { Patterns } from '@app/constants/patterns';
import { ValidationRules } from '@app/constants/validation-rules';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit
{

  loginForm!: FormGroup;

  username!: FormControl ;
  password!: FormControl;

  showPassword : boolean = false;

  constructor(
    private formBuilder: FormBuilder
  ){}

  ngOnInit(): void {
    this.createForm();
  }

  createForm(): void {
    this.username = new FormControl('', 
    [
      Validators.required,
      Validators.min( ValidationRules.minUserNameLength ),
      Validators.max( ValidationRules.maxEmailLength )
    ]);

    this.password = new FormControl('',
    [
      Validators.required,
      Validators.pattern( Patterns.password )
    ]);

    this.loginForm = this.formBuilder.group({
      username: this.username,
      password: this.password
    });
  }

  onSubmit(): void
  {
    this.loginForm.markAllAsTouched();

    if(this.loginForm.invalid)
      return;
  }

}
