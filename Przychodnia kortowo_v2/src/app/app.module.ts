import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserComponent } from './user/user.component';
import { RegistrationComponent } from './user/registration/registration.component';
import {ReactiveFormsModule, FormsModule} from "@angular/forms"
import { UserService } from './shared/user.service';
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import {BrowserAnimationsModule} from '@angular/platform-browser/animations'
import {ToastrModule} from 'ngx-toastr';
import { LoginComponent } from './user/login/login.component';
import { HomeComponent } from './home/home.component'
import { AuthInterceptor } from './auth/auth.interceptor';
import { AdminPanelComponent } from './admin-panel/admin-panel.component';
import { ForbiddenComponent } from './forbidden/forbidden.component';
import {MatTabsModule} from '@angular/material/tabs';
import {MatCardModule} from '@angular/material/card';
import {MatTableModule} from '@angular/material/table';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatButtonModule} from '@angular/material/button';
import {MatDatepickerModule} from '@angular/material/datepicker'
import { MatSortModule } from '@angular/material/sort';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { ReceptionFormComponent } from './reception-form/reception-form.component';
import { MatNativeDateModule, MAT_DATE_LOCALE } from '@angular/material/core';
import { MatSelectModule } from '@angular/material/select';
import {MatIconModule} from '@angular/material/icon';
import {MatDialogModule} from '@angular/material/dialog';
import { ReceptionUpdateComponent } from './reception-update/reception-update.component';
import { ReplacePipe } from 'src/app/reception-form/reception-form.pipe';
import { ReceptionGastrologComponent } from './reception-gastrolog/reception-gastrolog.component';
import { DatePipe } from '@angular/common';
import { ReceptionAddComponent } from './reception-add/reception-add.component';
import { DoctorUpdateComponent } from './doctor-update/doctor-update.component';
import { PatientFormComponent } from './patient-form/patient-form.component';
import { HelloComponent } from './hello/hello.component';
import { DoctorInfoComponent } from './doctor-info/doctor-info.component';
import { FilterPipe } from './doctor-info/filter.pipe';
import {MatListModule} from '@angular/material/list';
import { PatientAddinfoComponent } from './patient-addinfo/patient-addinfo.component';
import { PatientUpdateComponent } from './home/patient-update/patient-update.component';


@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    RegistrationComponent,
    LoginComponent,
    HomeComponent,
    AdminPanelComponent,
    ForbiddenComponent,
    ReceptionFormComponent,
    ReceptionUpdateComponent,
    ReplacePipe,
    ReceptionGastrologComponent,
    ReceptionAddComponent,
    DoctorUpdateComponent,
    PatientFormComponent,
    HelloComponent,
    DoctorInfoComponent,
    FilterPipe,
    PatientAddinfoComponent,
    PatientUpdateComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    ToastrModule.forRoot(
      {
        progressBar: true
      }
    ),
    BrowserAnimationsModule,
    FormsModule,
    MatTabsModule,
    MatCardModule,
    MatTableModule,
    MatPaginatorModule,
    MatToolbarModule,
    MatButtonModule,
    MatDatepickerModule,
    MatSortModule,
    FlexLayoutModule,
    MatFormFieldModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatSelectModule,
    MatIconModule,
    MatDialogModule,
    MatListModule,


  ],
  
  providers: [UserService, 
    MatDatepickerModule,  
    {
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
  }, 
  {provide: MAT_DATE_LOCALE, useValue: 'pl-PL'},

  DatePipe,

],
  bootstrap: [AppComponent]
})
export class AppModule { }
