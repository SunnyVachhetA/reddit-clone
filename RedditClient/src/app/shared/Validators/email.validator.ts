import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';
import { Patterns } from '@app/constants/patterns';

export const emailValidator = (): ValidatorFn => {
  return (control: AbstractControl): ValidationErrors | null => {
    const passwordRegex = Patterns.email;
    return passwordRegex.test(control.value) ? null : { invalidEmail: true };
  };
};
