import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';
import { Patterns } from '@app/constants/patterns';

export const passwordValidator = (): ValidatorFn => {
  return (control: AbstractControl): ValidationErrors | null => {
    const passwordRegex = Patterns.password;
    return passwordRegex.test(control.value) ? null : { invalidPassword: true };
  };
};
