import { Component, OnInit, AfterViewInit } from '@angular/core';
import { ProductService } from 'src/app/services/product.service';
import { MatTableDataSource } from '@angular/material/table';
import { Product } from 'src/app/model/product.model';
import { MatDialogConfig, MatDialog } from '@angular/material';
import { ProductComponent } from '../product/product.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit, AfterViewInit {

  public dataSourceProduct = new MatTableDataSource<Product>();
  displayedColumns = ['id', 'name', 'price', 'amount', 'action'];

  constructor(private produtoService: ProductService, public dialog: MatDialog) { }

  ngOnInit() {

  }
  ngAfterViewInit(): void {
    this.getProduct();
  }

  getProduct() {
    this.produtoService.get().subscribe((result: Product[]) => {
      console.log(result);
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

  // edit(product: Product) {

  //   this.openDialog();
  // }

  openDialog(product: Product) {
    const dialogConfig = new MatDialogConfig();

    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    if (product) {
      dialogConfig.data = product;
    }


    const dialogRef = this.dialog.open(ProductComponent, dialogConfig);
    dialogRef.afterClosed().subscribe(result => {
      this.getProduct();
    });
  }


}
