import { IProducts } from "./Product";
export interface Ipaggination {
    page_Number: number;
    page_size: number;
    count: number;
    data: IProducts[];
}
