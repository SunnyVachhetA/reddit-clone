import { ToastrService, TOAST_CONFIG } from 'ngx-toastr';
import { TOASTR_CONFIG } from '@app/constants/toastr-config';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class CustomToastrService {
    constructor(
        private toastr: ToastrService
    )
    {
        this.toastr.toastrConfig.enableHtml = true;
    }

    success(message: string, title?: string) : void
    {
        this.toastr.success(message, title, TOASTR_CONFIG);
    }

    error(message: string, title?: string) : void
    {
        this.toastr.error(message, title, TOASTR_CONFIG);
    }

    warning(message: string, title?: string) : void
    {
        this.toastr.warning(message, title, TOASTR_CONFIG);
    }

    info(message: string, title?: string) : void
    {
        this.toastr.info(message, title, TOASTR_CONFIG);
    }
    
    clearToast() : void
    {
        this.toastr.clear();
    }
}