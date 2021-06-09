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
import { DatePipe } from '@angular/common';


@Component({
  selector: 'app-reception-gastrolog',
  templateUrl: './reception-gastrolog.component.html',
  styleUrls: ['./reception-gastrolog.component.css']
})
export class ReceptionGastrologComponent implements OnInit {

  alert:boolean = false;
  selected = '5d02179c-6cc6-475f-399c-08d925d46a0b';

  onLogout() {
    localStorage.removeItem('token');
    this.router.navigate(['/user/login']);
  }
  ELEMENT_DATA!: IVisits[];
  public displayedColumns =  [ 'name', 'surname', 'phoneNumber', 'date', 'time','reason', 'doctorId' , 'confirmed' , 'update', 'doctorRecommendation'];
  public dataSource = new MatTableDataSource<IVisits>(this.ELEMENT_DATA);

  constructor(private router: Router, private _userService: UserService, private HttpClient: HttpClient, public dialog: MatDialog,public datepipe: DatePipe ) {
    this.dataSource.filterPredicate =
    (data, filter: string) => !filter || data.date.includes(filter);

    this._userService.getData().subscribe(data=>
      {
        console.warn(data);
      })
  }
  
  TrueOrFalse: string="";
  Confirm:Confirmed[] =
  [
  {value: true, viewValue: "Potwierdzone"},
  {value: false, viewValue: "Niepotwierdzone"}
  ]

  @ViewChild(MatSort)
  sort!: MatSort;


  


  nameFilter = new FormControl();
  surnameFilter = new FormControl();
  doktorfilter = new FormControl( );
  datefilter = new FormControl();
  confirmFilter = new FormControl();


  selectedValue:string='';
  doctors:Doctor[] = [
    {value: '7e69e274-2457-497b-f0a2-08d92a80bcac', viewValue:'Dr Leszek Korsak Internista'},
    {value: '7973dcfc-a45c-4576-f0a3-08d92a80bcac', viewValue:'Dr Aneta Korsak Internista'},
    {value: 'bd04bdb4-1d19-41a0-30c9-08d92b58d8f6', viewValue:'Dr Dariusz Skorwyński Gastrolog'},
    {value: '26ad7e5b-e05f-41b3-30ca-08d92b58d8f6', viewValue:'Dr Stanisław Sienkiewicz Okulista'},
    {value: '5fa7d7af-cce0-44b4-30cb-08d92b58d8f6', viewValue:'Dr Katarzyna Wolna Pulmonolog'}
  ]
  
  filteredValues = { name:'', surname:'', phoneNumber:'', date:'', time:'', reason:'', doctorId:'', confirmed: '', doctorRecommendation: ''};

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

  
  @ViewChild(MatPaginator)
  paginator!: MatPaginator;


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


updateVisit(id: string)
{
this.router.navigate(['doctor-update', id]);
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

export interface Confirmed {
  value: boolean;
  viewValue: string;
}
