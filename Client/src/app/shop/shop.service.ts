import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IProducts } from '../shared/Models/Product';
import { Ipaggination } from '../shared/Models/paggination';
import { Ibrands } from '../shared/Models/Brands';
import { Itypes } from '../shared/Models/Types';
import {map} from 'rxjs/operators'

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseurl = 'https://localhost:5001/api/'
  constructor( private Http: HttpClient) { }

  getproducts(brandid?: number , typeid?: number , orderby?: string, AscOrDesc?: string, search?: string)
  {
    let params = new HttpParams();

    if(brandid)
    {
      params = params.append('brandid',brandid.toString());  
    }
    if(typeid)
    {
      params = params.append('Typeid',typeid.toString());  
    }
    if (orderby && AscOrDesc) 
    {
      params = params.append('orderby',orderby)
      params = params.append('AscOrDesc',AscOrDesc)
    }
    if(search)
    {
      params = params.append('search',search);  
    }
    return this.Http.get<Ipaggination>(this.baseurl+'products',{observe:'response',params})
      .pipe
      (
        map(Response => 
          {
            return Response.body;
          })
      );
  }

  getbrands()
  {
    return this.Http.get<Ibrands[]>(this.baseurl+'products/Brands')
  }

  gettypes()
  {
    return this.Http.get<Itypes[]>(this.baseurl+'products/Types')
  }
}
