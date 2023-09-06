import { Component,OnInit,Input } from '@angular/core';
import { IProducts } from 'src/app/shared/Models/Product';
import { Ibrands } from 'src/app/shared/Models/Brands';
import { Itypes } from 'src/app/shared/Models/Types';

 

@Component({
  selector: 'app-item',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.scss']
})
export class ItemComponent implements OnInit {

  @Input() product!: IProducts;
  constructor(){}
  ngOnInit(): void {
  }

}
