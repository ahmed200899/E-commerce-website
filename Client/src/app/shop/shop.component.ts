import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Ipaggination } from 'src/app/shared/Models/paggination';
import { ShopService } from './shop.service';
import { IProducts } from '../shared/Models/Product';
import { Ibrands } from '../shared/Models/Brands';
import { Itypes } from '../shared/Models/Types';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {

  @ViewChild('searchInput') searchInput!: ElementRef<HTMLInputElement>;
  products: IProducts[] | undefined;
  brands: Ibrands[] = [];
  types: Itypes[] = [];
  selectedbrandid!: number;
  selectedtypeid!: number;
  search: string = "";
  orderby = 'name';
  AscOrDesc = 'desc'
  orderbylist = 
  [
    {name: 'name-desc', value:'Sort by'},
    {name: 'price-asc', value:'Price (ASC)'},
    {name: 'price-desc', value:'Price (DESC)'},
    {name: 'name-asc', value:'Name (ASC)'},
    {name: 'name-desc', value:'Name (DESC)'}
  ]

  constructor(private shopservice: ShopService) { }

  ngOnInit(): void {
    this.getproducts(); 
    this.getbrands();
    this.gettypes();


  }

  getproducts() {
    this.shopservice.getproducts(this.selectedbrandid,this.selectedtypeid,this.orderby,this.AscOrDesc, this.search).subscribe(
      (Response) => {
        this.products = Response?.data;
      },
      (error) => {
        console.log(error);
      }
    );
  }

  getbrands() {

    this.shopservice.getbrands().subscribe(
      (Response) => {
        this.brands = [{id: 0, name:'All'},...Response];
      },
      (error) => {
        console.log(error);
      }
    );
  }

  gettypes() {

    this.shopservice.gettypes().subscribe(
      (Response) => {
        this.types = [{id: 0, name:'All'},...Response];
      },
      (error) => {
        console.log(error);
      }
    );
  }

  onbrandselected(brandid: number) {
    this.selectedbrandid = brandid;
    this.getproducts();
  }

  ontypeselected(typeid: number) {
    this.selectedtypeid = typeid;
    this.getproducts();
  }

  onorderselection(event: Event) {
    const target = event.target as HTMLSelectElement;
    const orderbyselected = target.value;

    const parts = orderbyselected.split('-');
    this.orderby = parts[0];
    this.AscOrDesc = parts[1];
    this.getproducts();
  }


  onSearchClick(search : string)
  {
    console.log(search);
    this.search = search;
    this.getproducts();
  }

  onresetClick()
  {
    this.searchInput.nativeElement.value = '';
    this.search = "";
    this.getproducts();
  }
  
}
