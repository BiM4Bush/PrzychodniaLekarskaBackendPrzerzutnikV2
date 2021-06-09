import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminPanelComponent } from './admin-panel/admin-panel.component';
import { AuthGuard } from './auth/auth.guard';
import { DoctorInfoComponent } from './doctor-info/doctor-info.component';
import { DoctorUpdateComponent } from './doctor-update/doctor-update.component';
import { ForbiddenComponent } from './forbidden/forbidden.component';
import { HelloComponent } from './hello/hello.component';
import { HomeComponent } from './home/home.component';
import { PatientUpdateComponent } from './home/patient-update/patient-update.component';
import { PatientAddinfoComponent } from './patient-addinfo/patient-addinfo.component';
import { PatientFormComponent } from './patient-form/patient-form.component';
import { ReceptionUpdateComponent } from './reception-update/reception-update.component';
import { LoginComponent } from './user/login/login.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { UserComponent } from './user/user.component';

const routes: Routes = [
  {path:'', redirectTo:'/user/login', pathMatch:'full'},
  {path:'user', component:UserComponent,
  children:[
    {path:'registration', component:RegistrationComponent},
    {path:'login', component:LoginComponent}
  ]
},
{path:'wizyta',component:PatientFormComponent,canActivate:[AuthGuard]},
{path:'home', component:HomeComponent, canActivate:[AuthGuard]},
{path:'forbidden',component:ForbiddenComponent},
{path:'adminpanel',component:AdminPanelComponent,canActivate:[AuthGuard],data :{permittedRoles:['Admin']}},
{path:'reception-update/:id', component:ReceptionUpdateComponent,canActivate:[AuthGuard],data :{permittedRoles:['Admin']} },
{path:'doctor-update/:id', component:DoctorUpdateComponent, canActivate:[AuthGuard],data :{permittedRoles:['Admin']} },
{path:'hello', component:HelloComponent},
{path:'doctorinfo', component:DoctorInfoComponent},
{path:'addinfo',component:PatientAddinfoComponent,canActivate:[AuthGuard]},
{path:'patient-update/:id',component:PatientUpdateComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
