import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import {ActivatedRoute} from '@angular/router'
import {UserService} from 'src/app/shared/user.service';
import { Router } from '@angular/router'


@Component({
  selector: 'app-doctor-update',
  templateUrl: './doctor-update.component.html',
  styleUrls: ['./doctor-update.component.css']
})
export class DoctorUpdateComponent implements OnInit {
  TrueOrFalse: string="";
  Confirm:Confirmed[] =
  [
  {value: true, viewValue: "Potwierdzone"},
  {value: false, viewValue: "Niepotwierdzone"}
  ]
  selectedValue:string='';
  doctors:Doctor[] = [
    {value: 'f1f9124f-acf7-4eb8-f64f-08d92abb52b5', viewValue:'Dr Leszek Korsak Internista'},
    {value: '0301d31d-20c9-4fd3-f650-08d92abb52b5', viewValue:'Dr Aneta Korsak Internista'},
    {value: '54adcb37-db6c-4db8-f651-08d92abb52b5', viewValue:'Dr Dariusz Skorwyński Gastrolog'},
    {value: 'b1563d0a-2e3f-4cb1-f652-08d92abb52b5', viewValue:'Dr Stanisław Sienkiewicz Okulista'},
    {value: '98cb43d4-285b-4f18-f653-08d92abb52b5', viewValue:'Dr Katarzyna Wolna Pulmonolog'}
  ]

  alert:boolean = false;
  Editvisit = new FormGroup({
    name: new FormControl(''),
    surname: new FormControl(''),
    phoneNumber: new FormControl(''),
    date: new FormControl(''),
    time: new FormControl(''),
    doctorId: new FormControl(''),
    reason: new FormControl(''),
    confirmed: new FormControl("false"),
    doctorRecommendation: new FormControl('')
    })

  constructor(private router: ActivatedRoute, private _UserService: UserService, private router2: Router) { }

  ngOnInit(): void {
    console.warn(this.router.snapshot.params.id);
    this._UserService.getVisitUpdate(this.router.snapshot.params.id).subscribe((result)=>
    {
      this.Editvisit = new FormGroup({
        name: new FormControl(result['name'], ),
        surname: new FormControl(result['surname']),
        phoneNumber: new FormControl(result['phoneNumber']),
        date: new FormControl(result['date']),
        time: new FormControl(result['time']),
        doctorId: new FormControl(result['doctorId']),
        reason: new FormControl(result['reason']),
        confirmed: new FormControl(result['confirmed'],),
        doctorRecommendation: new FormControl(result['doctorRecommendation'])
        })
    }
    )
  }
  collection()
  {
    console.warn(this.Editvisit.value);
    this._UserService.UpdateVisitUpdate(this.router.snapshot.params.id, this.Editvisit.value).subscribe((result)=>
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
    this.router2.navigate(['/adminpanel'])
  }
}

export interface Doctor {
  value: string;
  viewValue: string;
}
export interface Confirmed {
  value: boolean;
  viewValue: string;
}