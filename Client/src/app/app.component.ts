import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IProducts } from './shared/Models/Product';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Skinet';


  constructor() {}

  ngOnInit(): void {

  }
}

