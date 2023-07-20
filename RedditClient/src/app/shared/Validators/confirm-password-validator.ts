import { ValidatorFn, AbstractControl, ValidationErrors } from '@angular/forms';


export function ConfirmPasswordValidator() : ValidatorFn 
{
    return ( control: AbstractControl ) : ValidationErrors | null => {
            const password = control.parent?.get('password')?.value;

            if(password === null || password === '')
                return null;

            return password === control.value 
                                ? null
                                : { confirmPasswordError: true } 
    }
}