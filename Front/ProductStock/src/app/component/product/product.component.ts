import { Product } from 'src/app/model/product.model';
import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {

  productForm: FormGroup;
  public product: Product;
  submitted = false;
  constructor(private dialogRef: MatDialogRef<ProductComponent>, private formBuilder: FormBuilder,
    @Inject(MAT_DIALOG_DATA) data, private produtoService: ProductService) {
    this.product = new Product();

    if (data) {
      console.log('entrei');
      this.product.identifier = (data as Product).identifier;
      this.product.amount = (data as Product).amount;
      this.product.name = (data as Product).name;
      this.product.price = (data as Product).price;
    }
  }

  ngOnInit() {

    this.productForm = this.formBuilder.group({
      name: ['', Validators.required],
      price: ['', Validators.required],
      amount: ['', Validators.required]
    });
  }


  get f() { return this.productForm.controls; }
  save() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.productForm.invalid) {
      return;
    }

    if (this.product.identifier) {
      this.produtoService.put(this.product.identifier, this.product).subscribe(() => {
        this.dialogRef.close();
      }, (err) => {
        console.log(err);
      });
    } else {
      this.produtoService.post(this.product).subscribe(() => {
        this.dialogRef.close();
      }, (err) => {
        console.log(err);
      });
    }

  }


  close() {
    this.dialogRef.close();
  }





}
