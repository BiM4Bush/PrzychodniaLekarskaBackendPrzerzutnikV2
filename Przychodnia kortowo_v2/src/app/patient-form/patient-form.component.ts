import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild, AfterViewInit  } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import {MatSort} from '@angular/material/sort';
import {MatTableDataSource} from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import {UserService} from 'src/app/shared/user.service';
import {IVisits} from 'src/app/shared/visit';
import { ToastrService } from 'ngx-toastr';
import { delay } from 'rxjs/operators';

@Component({
  selector: 'app-patient-form',
  templateUrl: './patient-form.component.html',
  styleUrls: ['./patient-form.component.css']
})
export class PatientFormComponent implements OnInit {

  selectedValue:string='';
  doctors:Doctor[] = [
    {value: '7e69e274-2457-497b-f0a2-08d92a80bcac', viewValue:'Dr Leszek Korsak Internista'},
    {value: '7973dcfc-a45c-4576-f0a3-08d92a80bcac', viewValue:'Dr Aneta Korsak Internista'},
    {value: 'bd04bdb4-1d19-41a0-30c9-08d92b58d8f6', viewValue:'Dr Dariusz Skorwyński Gastrolog'},
    {value: '26ad7e5b-e05f-41b3-30ca-08d92b58d8f6', viewValue:'Dr Stanisław Sienkiewicz Okulista'},
    {value: '5fa7d7af-cce0-44b4-30cb-08d92b58d8f6', viewValue:'Dr Katarzyna Wolna Pulmonolog'}
  ]
  godziny = ['9:00','9:30','10:00','10:30','11:00','11:30','12:00','12:30','13:00','13:30','14:00','14:30','15:00','15:30','16:00','16:30','17:00'];
  readonly VisitURL = 'http://localhost:5000/api/MedicalVisit';
  
  
  
  
//FORMGROUP DLA POSTA PACJENTA, doctor is null, private always true

userDetails;
id;
  onLogout() {
    localStorage.removeItem('token');
    this.router.navigate(['/user/login']);
  }
  ELEMENT_DATA!: IVisits[];
  public displayedColumns =  [ 'name', 'surname', 'phoneNumber', 'date', 'time', 'reason','confirmed'];
  public dataSource = new MatTableDataSource<IVisits>(this.ELEMENT_DATA);

  constructor(private router: Router, private _userService: UserService, private HttpClient: HttpClient,private toastr: ToastrService) {
    this._userService.getData().subscribe(data=>
      {
      })
      
  }


  ngOnInit(): void {
    this.GetVisits();
    this._userService.getUserProfile().subscribe(
      res => {
        this.userDetails = res;
        this.id=this.userDetails.id;
      },
      err => {
        console.log(err);
      },
    );
  }
  VisitSend = new FormGroup({
    name: new FormControl('', Validators.required),
    surname: new FormControl('', Validators.required),
    phoneNumber: new FormControl('', [Validators.required, Validators.pattern("[0-9 ]{9}")]),
    date: new FormControl('', Validators.required),
    time: new FormControl('', Validators.required),
    doctorId: new FormControl('', Validators.required),
    reason: new FormControl('', Validators.required),
    confirmed: new FormControl("false"),
    userId: new FormControl(''),
    })
  

  
  @ViewChild(MatPaginator)
  paginator!: MatPaginator;

  @ViewChild(MatSort)
  sort!: MatSort;

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  public doFilter = (value: string) => { //Wyszukiwanie w panelu lekarza
    this.dataSource.filter = value.trim().toLocaleLowerCase();
  }

public GetVisits(){
  let resp = this._userService.getData();
  resp.subscribe(report=>this.dataSource.data=report as IVisits[]);
}

///POST DLA REJESTRACJI PACJENTA
callAPI(){
  this.VisitSend.patchValue({
    userId: this.id, 
  })
  console.warn(this.VisitSend.value)
  this.HttpClient.post(this.VisitURL, this.VisitSend.value).subscribe((data)=>
  {
    console.warn(data)
  })
  this.toastr.success('Formularz Wysłany Pomyślnie')
  this.router.navigate(['/home'])
}


}
export interface Doctor {
  value: string;
  viewValue: string;
}
