import { Injectable } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient, HttpHeaders } from "@angular/common/http";

import { Idoctor} from 'src/app/shared/visit';
import { environment } from './../../environments/environment';
import { Observable } from 'rxjs';
import { IVisits } from 'src/app/shared/visit';
import { Ipatients } from './ipatients';
import { Imedicaments } from './imedicaments';
@Injectable({
  providedIn: 'root'
})
export class UserService {

  
  constructor(private fb:FormBuilder, private http:HttpClient) { }

  readonly BaseURL = 'http://localhost:5000/api';
  readonly VisitURL = 'http://localhost:5000/api/MedicalVisit';
  readonly DoctorURL = 'http://localhost:5000/api/Doctor';
  readonly PatientURL = 'http://localhost:5000/api/patientProfile';
  readonly MedicamentsURL = 'http://localhost:5000/api/medicaments';
  formModel = this.fb.group({
    UserName: ['', Validators.required],
    Email: ['', [Validators.email, Validators.required] ],
    FullName: ['', Validators.required],
    Passwords: this.fb.group({
      Password: ['', [Validators.required, Validators.minLength(8), Validators.pattern('(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&].{8,}')]], 
      //8 znakow dlugosci, male litery, duze liter, znaki specjalne
      ConfirmPassword: ['', Validators.required]
    }, { validator: this.comparePasswords })

  });
comparePasswords(fb:FormGroup){ //czy haslo to samo
let confirmPswrdCtrl = fb.get('ConfirmPassword');
//paswordMismatch
if(confirmPswrdCtrl?.errors == null || 'passwordMismatch' in confirmPswrdCtrl?.errors)
{
if(fb.get('Password')?.value != confirmPswrdCtrl?.value)
confirmPswrdCtrl?.setErrors({passwordMismatch: true});
else 
confirmPswrdCtrl?.setErrors(null);
}
}

register() {
  var body = {
    UserName: this.formModel.value.UserName,
    Email: this.formModel.value.Email,
    FullName: this.formModel.value.FullName,
    Password: this.formModel.value.Passwords.Password
  };
  return this.http.post(this.BaseURL + '/ApplicationUser/Register', body);
}

login(formData){
  return this.http.post(this.BaseURL + '/ApplicationUser/Login', formData);
}
getUserProfile() {
  return this.http.get(this.BaseURL + '/UserProfile');
}

// getUserRole(){
//   const idToken = localStorage.getItem('token')!;
//   return jwt_decode(idToken);
// }

roleMatch(allowedRoles): boolean {
  var isMatch = false;
  var payLoad = JSON.parse(window.atob(localStorage.getItem('token')!.split('.')[1]));
  var userRole = payLoad.role;
  allowedRoles.forEach(element => {
    if (userRole == element) {
      isMatch = true;
      return false;
    }
  });
  return isMatch;
}


public getData(): Observable<IVisits[]>
{
  return this.http.get<IVisits[]>(this.VisitURL)
}
 

public getVisitUpdate(id)
{
  return this.http.get(`${this.VisitURL}/${id}`)
}


public UpdateVisitUpdate(id, data)
{
  return this.http.put(`${this.VisitURL}/${id}`, data)
}




//////Pawła funkcje
public getDoctor(): Observable<Idoctor[]>
{
  return this.http.get<Idoctor[]>(this.DoctorURL)
}

getPost()
{
  return this.http.get(this.DoctorURL);
}
public getPatient(): Observable<Ipatients[]>
{
  return this.http.get<Ipatients[]>(this.PatientURL)
}
public getPatientUpdate(id)
{
  return this.http.get(`${this.PatientURL}/${id}`)
}

public UpdatePatient(id, data)
{
  return this.http.put(`${this.PatientURL}/${id}`, data)
}
public UpdatePatientUpdate(id, data)
{
  return this.http.put(`${this.PatientURL}/${id}`, data)
}

public getMedicaments(): Observable<Imedicaments[]>
{
  return this.http.get<Imedicaments[]>(this.MedicamentsURL)
}
public UpdateMedicamnet(id, data)
{
  return this.http.put(`${this.MedicamentsURL}/${id}`, data)
}
public UpdateMedicamentUpdate(id, data)
{
  return this.http.put(`${this.MedicamentsURL}/${id}`, data)
}

}