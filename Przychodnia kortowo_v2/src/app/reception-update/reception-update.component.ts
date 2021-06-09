import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import {ActivatedRoute} from '@angular/router'
import {UserService} from 'src/app/shared/user.service';
import { Router } from '@angular/router'


@Component({
  selector: 'app-reception-update',
  templateUrl: './reception-update.component.html',
  styleUrls: ['./reception-update.component.css']
})
export class ReceptionUpdateComponent implements OnInit {
  TrueOrFalse: string="";
  Confirm:Confirmed[] =
  [
  {value: true, viewValue: "Potwierdzone"},
  {value: false, viewValue: "Niepotwierdzone"}
  ]
  selectedValue:string='';
  doctors:Doctor[] = [
    {value: '7e69e274-2457-497b-f0a2-08d92a80bcac', viewValue:'Dr Leszek Korsak Internista'},
    {value: '7973dcfc-a45c-4576-f0a3-08d92a80bcac', viewValue:'Dr Aneta Korsak Internista'},
    {value: 'bd04bdb4-1d19-41a0-30c9-08d92b58d8f6', viewValue:'Dr Dariusz Skorwyński Gastrolog'},
    {value: '26ad7e5b-e05f-41b3-30ca-08d92b58d8f6', viewValue:'Dr Stanisław Sienkiewicz Okulista'},
    {value: '5fa7d7af-cce0-44b4-30cb-08d92b58d8f6', viewValue:'Dr Katarzyna Wolna Pulmonolog'}
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
        confirmed: new FormControl(result['confirmed']),
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
