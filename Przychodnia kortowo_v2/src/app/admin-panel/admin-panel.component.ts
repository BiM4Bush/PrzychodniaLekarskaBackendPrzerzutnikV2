import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { Router } from '@angular/router';
import {MatSort} from '@angular/material/sort';
import {MatTableDataSource} from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import {UserService} from 'src/app/shared/user.service';
import {IVisits} from 'src/app/shared/visit';


@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.css']
})
export class AdminPanelComponent implements OnInit, AfterViewInit {


  onLogout() {
    localStorage.removeItem('token');
    this.router.navigate(['/user/login']);
  }
  ELEMENT_DATA!: IVisits[];
  public displayedColumns =  [ 'name', 'surname', 'phoneNumber', 'date', 'time', 'reason'];
  public dataSource = new MatTableDataSource<IVisits>(this.ELEMENT_DATA);

  constructor(private router: Router, private _userService: UserService) { 
    this._userService.getData().subscribe(data=>
      {
        console.warn(data);
      })
  }

  ngOnInit(): void {
    this.GetVisits();
  
  }

  
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
  public filtrLeszekKorsak = (value:string) => {
    this.dataSource.filter =  value= "7c390940-8321-43cc-9245-08d925e2f2ac";
  }

public GetVisits(){
  let resp = this._userService.getData();
  resp.subscribe(report=>this.dataSource.data=report as IVisits[]);
}


}

