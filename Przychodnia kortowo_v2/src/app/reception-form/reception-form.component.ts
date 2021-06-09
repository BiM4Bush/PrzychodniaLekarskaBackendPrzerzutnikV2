import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild, AfterViewInit  } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import {MatSort, MatSortable, Sort} from '@angular/material/sort';
import {MatTableDataSource} from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import {UserService} from 'src/app/shared/user.service';
import {IVisits} from 'src/app/shared/visit';
import { MatDialog ,MatDialogRef} from '@angular/material/dialog';
import { concatMap, filter } from 'rxjs/operators';
import { DatePipe } from '@angular/common';


@Component({
  selector: 'app-reception-form',
  templateUrl: './reception-form.component.html',
  styleUrls: ['./reception-form.component.css']
})

export class ReceptionFormComponent implements OnInit, AfterViewInit {
  
  alert:boolean = false;

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
  godziny = ['9:00','9:30','10:00','10:30','11:00','11:30','12:00','12:30','13:00','13:30','14:00','14:30','15:00','15:30','16:00','16:30','17:00'];
  readonly VisitURL = 'http://localhost:5000/api/MedicalVisit';
  VisitSend = new FormGroup({
  name: new FormControl('', Validators.required),
  surname: new FormControl('', Validators.required),
  phoneNumber: new FormControl('', [Validators.required, Validators.pattern("[0-9 ]{9}")]),
  date: new FormControl('', Validators.required),
  time: new FormControl('', Validators.required),
  doctorId: new FormControl('', Validators.required),
  reason: new FormControl('', Validators.required),
  confirmed: new FormControl('false'),

  })
  
  
  
//FORMGROUP DLA POSTA PACJENTA, doctor is null, private always true
  //FORMGROUP DLA POSTA PACJENTA, doctor is null, private always true





  onLogout() {
    localStorage.removeItem('token');
    this.router.navigate(['/user/login']);
  }
  ELEMENT_DATA!: IVisits[];
  public displayedColumns =  [ 'name', 'surname', 'phoneNumber', 'date', 'time','reason', 'confirmed',  'doctorId', 'update', ];
  public dataSource = new MatTableDataSource<IVisits>(this.ELEMENT_DATA);

  


  constructor(private router: Router, private _userService: UserService, private HttpClient: HttpClient, public dialog: MatDialog, public datepipe: DatePipe) {
    this.dataSource.filterPredicate =
    (data, filter: string) => !filter || data.date.includes(filter);
    
    this._userService.getData().subscribe(data=>
      {
        console.warn(data);
      })
  }

  nameFilter = new FormControl();
  surnameFilter = new FormControl();
  doktorfilter = new FormControl( );
  datefilter = new FormControl();
  confirmFilter = new FormControl();
  filteredValues = { name:'', surname:'', phoneNumber:'', date:'', time:'', reason:'', doctorId:'', confirmed: ''};
  
  @ViewChild(MatSort)
  sort!: MatSort;

  confirmYes: string = "true";
  value3: string = 'aa8b6df7-1ce6-4389-33e2-08d92907d611';

  ngOnInit(): void {
    this.GetVisits();
    this.nameFilter.valueChanges.subscribe((nameFilterValue) => {
      this.filteredValues['name'] = nameFilterValue;
      this.dataSource.filter = JSON.stringify(this.filteredValues);
    });

    this.surnameFilter.valueChanges.subscribe((surnameFilter) => {
      this.filteredValues['surname'] = surnameFilter;
      this.dataSource.filter = JSON.stringify(this.filteredValues);
    });

    this.doktorfilter.valueChanges.subscribe((doktorfilter) => {
      this.filteredValues['doctorId'] = doktorfilter;
      this.dataSource.filter = JSON.stringify(this.filteredValues);
    });


    this.datefilter.valueChanges.subscribe((datefilter) => {
      this.filteredValues['date'] = datefilter;
      this.dataSource.filter = JSON.stringify(this.filteredValues);
    });

    this.datefilter.valueChanges.subscribe((datefilter) => {
      this.filteredValues['date'] = datefilter;
      this.dataSource.filter = JSON.stringify(this.filteredValues);
    });

    this.confirmFilter.valueChanges.subscribe((confirmFilter) => {
      this.filteredValues['confirmed'] = confirmFilter;
      this.dataSource.filter = JSON.stringify(this.filteredValues);
    });
    
  this.dataSource.filterPredicate = this.customFilterPredicate();

  }
  customFilterPredicate() {
    const myFilterPredicate = function(data:IVisits, filter:string) :boolean {
      let searchString = JSON.parse(filter);
      let nameFound = data.name.toString().trim().toLowerCase().indexOf(searchString.name.toLowerCase()) !== -1
      let positionFound = data.surname.toString().trim().toLowerCase().indexOf(searchString.surname.toLowerCase()) !== -1
      let doctor = data.doctorId.toString().trim().indexOf(searchString.doctorId) !== -1
      let datefilter =data.date.toString().trim().indexOf(searchString.date) !==-1
      let confirm = data.confirmed.toString().trim().indexOf(searchString.confirmed) !== -1
      if (searchString.topFilter) {
          return nameFound || positionFound || doctor || datefilter || confirm
      } else {
          return nameFound && positionFound && doctor && datefilter && confirm
      }
    }
    return myFilterPredicate;
  }

  
  @ViewChild(MatPaginator)
  paginator!: MatPaginator;


  

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  public doFilter = (value: string) => { //Wyszukiwanie w panelu lekarza
    this.dataSource.filter = value.trim().toLocaleLowerCase() ;
  }

public GetVisits(){
  let resp = this._userService.getData()
  resp.subscribe(report=>this.dataSource.data=report as IVisits[]);
}




///POST DLA REJESTRACJI PACJENTA
callAPI(){
  console.warn(this.VisitSend.value)
  this.HttpClient.post(this.VisitURL, this.VisitSend.value).subscribe((data)=>
  {
    console.warn(data)
    this.alert=true
  })
}
updateVisit(id: string)
{
this.router.navigate(['reception-update', id]);
}

closeAlert()
{
  this.alert=false
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
