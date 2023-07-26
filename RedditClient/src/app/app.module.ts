import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material/material-ui.module';
import { CommonModule } from '@angular/common';
import { HomeModule } from './components/home/home.module';
import { SharedModule } from './components/shared/shared.module';
import { HomeRoutingModule } from './components/home/home-routing.module';
import { HttpClientModule} from '@angular/common/http';
import { ToastrModule } from 'ngx-toastr';
import { CUSTOM_ERROR_INTERCEPTOR } from './interceptors/error.interceptor';
import { JWT_INTERCEPTOR } from './interceptors/jwt.interceptor';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    HomeModule,
    ToastrModule,
    HomeRoutingModule,
    HttpClientModule,
    ToastrModule.forRoot()
  ],
  providers: [
    CUSTOM_ERROR_INTERCEPTOR,
    JWT_INTERCEPTOR
  ],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
