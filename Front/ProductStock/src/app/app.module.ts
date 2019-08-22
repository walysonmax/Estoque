import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import {MatToolbarModule} from '@angular/material/toolbar';
import { NavbarComponent } from './shared/navbar/navbar.component';
import { ProductService } from './services/product.service';
import { HomeComponent } from './component/home/home.component';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { FlexLayoutModule } from '@angular/flex-layout';
import {ErrorStateMatcher} from '@angular/material/core';


import { ProductComponent } from './component/product/product.component';

import {
  MatIconModule, MatCardModule, MatButtonModule,  MatInputModule, MatFormFieldModule, MatTableModule,
   MatDialogModule
} from '@angular/material';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HomeComponent,
    ProductComponent
  ],
  imports: [
    ReactiveFormsModule,
    FlexLayoutModule,
    BrowserModule,
    MatIconModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    MatInputModule,
    MatCardModule,
    FormsModule,
    MatFormFieldModule,
    MatToolbarModule,
    MatTableModule,
    HttpClientModule,
    MatButtonModule,
    MatDialogModule
  ],
  providers: [ProductService],
  bootstrap: [AppComponent],
  entryComponents: [ProductComponent]
})
export class AppModule { }
