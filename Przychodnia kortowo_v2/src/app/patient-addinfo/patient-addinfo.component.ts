import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from '../shared/user.service';
import {HttpClient} from '@angular/common/http'
import { Ipatients } from '../shared/ipatients';

@Component({
  selector: 'app-patient-addinfo',
  templateUrl: './patient-addinfo.component.html',
  styleUrls: ['./patient-addinfo.component.css']
})
export class PatientAddinfoComponent implements OnInit {
  selectedValue:string='';
  alert:boolean = false;
  userDetails;
  patientDetails;
  id:string='';
  readonly PatientURL = 'http://localhost:5000/api/patientProfile';
  patient: Ipatients[] =[];
  data:any;
  plci:plec[] = [
    {value: 'mezczyzna', viewValue:'Mężczyzna'},
    {value: 'kobieta', viewValue:'Kobieta'},
  ]

  constructor(private router: Router, private service: UserService,private HttpClient: HttpClient) { }
  PatientSend = new FormGroup({
    name: new FormControl(''),
    surname: new FormControl(''),
    gender: new FormControl(''),
    telNumber: new FormControl(''),
    birthdayDate: new FormControl(''),
    adress: new FormControl(''),
    pesel: new FormControl(''),
    userId: new FormControl(''),
  })

  ngOnInit(): void {
    this.service.getUserProfile().subscribe(
      res => {
        this.userDetails = res;
        this.id=this.userDetails.id;
        console.log(this.id);
      },
      err => {
        console.log(err);
      },
    );
    this.service.getPatientUpdate(this.id).subscribe(
      rest =>{
        this.data = rest;
        console.warn(this.data);
      },
      err => {
        console.log(err);
      },
    )
    
  }
  callAPI(){
    this.PatientSend.patchValue({
      userId: this.userDetails.id,
    })
    console.warn(this.PatientSend.value)
    this.HttpClient.post(this.PatientURL, this.PatientSend.value).subscribe((data)=>
    {
      console.warn(data)
      this.alert=true
      this.router.navigate(['home']);
    })
  }
  

}
export interface plec {
  value: string;
  viewValue: string;
}
