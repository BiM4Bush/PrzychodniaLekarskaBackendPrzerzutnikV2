import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild, AfterViewInit, Pipe  } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from '../shared/user.service';
import {MatSort} from '@angular/material/sort';
import {MatTableDataSource} from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import {MatGridListModule} from '@angular/material/grid-list';
import { from, pipe } from 'rxjs';
import { filter } from 'rxjs/operators';
import { FilterPipe } from 'src/app/filter.pipe';
import { Ipatients } from '../shared/ipatients';
import {MatListModule} from '@angular/material/list';
import { Identifiers } from '@angular/compiler';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {


  selectedValue:string='';
  alert:boolean = false;
  userDetails;
  patientDetails;
  id:string='';
  readonly PatientURL = 'http://localhost:5000/api/patientProfile';
  patient: Ipatients[] =[];
  data:any;


  ELEMENT_DATA!: Ipatients[];
  Data2!: Ipatients[];
  public displayedColumns =  [ 'name', 'surname', 'gender', 'telNumber','birthdayDate','adress','pesel','userId'];
  public dataSource = new MatTableDataSource<Ipatients>(this.ELEMENT_DATA);

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


  constructor(private router: Router, private service: UserService,private HttpClient: HttpClient) {
  }

  ngOnInit() {
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
    })
  }
  updatePatient(id: string)
  {
  this.router.navigate(['patient-update', id]);
  }

  onLogout() {
    localStorage.removeItem('token');
    this.router.navigate(['/user/login']);
  }
  callApi()
  {
    this.PatientSend.patchValue(
      {
        userid: this.id,

      }
    )
  }


}