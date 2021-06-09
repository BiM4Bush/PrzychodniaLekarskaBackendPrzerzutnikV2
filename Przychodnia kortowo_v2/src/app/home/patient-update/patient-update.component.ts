import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import {ActivatedRoute, Router} from '@angular/router';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-patient-update',
  templateUrl: './patient-update.component.html',
  styleUrls: ['./patient-update.component.css']
})
export class PatientUpdateComponent implements OnInit {
  userDetails;
  id: any;
  alert:boolean = false;
  EditPatient = new FormGroup({
    name: new FormControl(''),
    surname: new FormControl(''),
    gender: new FormControl(''),
    telNumber: new FormControl(''),
    birthdayDate: new FormControl(''),
    adress: new FormControl(''),
    pesel: new FormControl(''),
  })
  constructor(private router:ActivatedRoute,private service: UserService, private router2: Router) { }

  ngOnInit(): void {
    this.service.getUserProfile().subscribe(
      res => {
        this.userDetails = res;

      },
      err => {
        console.log(err);
      },
    );
    console.warn(this.router.snapshot.params.id)
    this.service.getPatientUpdate(this.router.snapshot.params.id).subscribe((result)=>

    {

      this.EditPatient = new FormGroup({
        name: new FormControl(result['name'],),
        surname: new FormControl(result['surname']),
        gender: new FormControl(result['gender']),
        telNumber: new FormControl(result['telNumber']),
        birthdayDate: new FormControl(result['birthdayDate']),
        adress: new FormControl(result['adress']),
        pesel: new FormControl(result['pesel']),
        userId: new FormControl(result['userId']),
      })
    }
    )
  }
  collection()
  {
    console.warn(this.EditPatient.value);
    this.service.UpdatePatientUpdate(this.router.snapshot.params.id, this.EditPatient.value).subscribe((result) =>
    {
      console.warn(result)
      this.alert=true
    })
  }

  closeAlert()
  {
    this.alert=false
  }
  back(): void {
    this.router2.navigate(['/home'])
  }
  callApi()
  {
    this.EditPatient.patchValue({
      userId: this.userDetails.id,

    })
  }

}
