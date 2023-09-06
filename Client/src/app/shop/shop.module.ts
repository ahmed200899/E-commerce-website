import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component';
import { ItemComponent } from './item/item.component';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    ShopComponent,
    ItemComponent
  ],
  imports: [
    CommonModule,
    FormsModule 
  ],
  exports: [ShopComponent]
})
export class ShopModule { }
