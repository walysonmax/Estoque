import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/services/product.service';
import { MatTableDataSource } from '@angular/material/table';
import { Product } from 'src/app/model/product.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  public dataSourceProduct = new MatTableDataSource<Product>();
  displayedColumns = ['id', 'name', 'price', 'amount', 'action'];

  constructor(private produtoService: ProductService) { }

  ngOnInit() {

  }

  getProduct() {
    this.produtoService.get().subscribe((result: Product[]) => {
      this.dataSourceProduct.data = result as Product[];
    }, (err) => {
      console.log(err);
    });
  }


  deleteProduct(id: number) {
    this.produtoService.delete(id).subscribe(() => {
      this.getProduct();
    }, (err) => {
      console.log(err);
    });
  }


}
