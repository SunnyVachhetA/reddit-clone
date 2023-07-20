import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';
import { Patterns } from '@app/constants/patterns';

export const usernameValidator = (): ValidatorFn => {
  return (control: AbstractControl): ValidationErrors | null => {
    const passwordRegex = Patterns.username;
    return passwordRegex.test(control.value) ? null : { invalidUsername: true };
  };
};
