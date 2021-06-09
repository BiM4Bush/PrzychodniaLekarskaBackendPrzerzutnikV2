import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild, AfterViewInit, Pipe  } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import {Idoctor } from 'src/app/shared/visit';
import { UserService } from '../shared/user.service';
import {MatTableDataSource} from '@angular/material/table';


@Component({
  selector: 'app-doctor-info',
  templateUrl: './doctor-info.component.html',
  styleUrls: ['./doctor-info.component.css']
})
export class DoctorInfoComponent implements OnInit {
  readonly DoctorURL = 'http://localhost:5000/api/Doctor';
  doctor: Idoctor[] =[];
  data:any;
  DoctorSend = new FormGroup({
    namme: new FormControl(''),
    surname:  new FormControl(''),
    medicalSpecialization:  new FormControl('')
  })
  ELEMENT_DATA!: Idoctor[];
  Data2!: Idoctor[];
  public displayedColumns =  [ 'name', 'surname', 'medicalSpecialization', 'phoneNumber'];
  public dataSource = new MatTableDataSource<Idoctor>(this.ELEMENT_DATA);

  constructor(private router: Router, private service: UserService, private HttpClient: HttpClient) {
    this.service.getDoctor().subscribe(data=>{
      console.warn(data);
    })
   }

  onLogout() {
    localStorage.removeItem('token');
    this.router.navigate(['/user/login']);
  }
  ngOnInit(): void {

    this.getDoctor();
    this.service.getPost().subscribe((result)=>
    {
      console.warn("result",result)
      this.data =result
    })

  }
  public getDoctor()
  {
    let resp = this.service.getDoctor();
    resp.subscribe(report=>this.dataSource.data=report as Idoctor[]);
  }
}
