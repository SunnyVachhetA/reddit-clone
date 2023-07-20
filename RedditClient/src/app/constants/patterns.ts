import { ValidationRules } from './validation-rules';

export const Patterns = {

    email: /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,3}$/,

    password: new RegExp(
        `^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*_=+-]).{${ValidationRules.minPasswordLength},${ValidationRules.maxPasswordLength}}$`
      ),

    username: /^[a-zA-Z0-9_-]{3,20}$/
};