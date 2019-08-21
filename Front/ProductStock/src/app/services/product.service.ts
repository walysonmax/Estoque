import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse, HttpParams } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, catchError, tap, filter } from 'rxjs/operators';
import { Product } from '../model/product.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };
  constructor(private http: HttpClient) { }


  get() {   
    return this.http.get<Product>(environment.endpointProduct , this.httpOptions)
      .pipe(
        catchError(this.handleError('get', []))
      )
  }

  getById(id: string) {   

    // let params = new HttpParams().set('id', id);

    return this.http.get<Product>(environment.endpointProduct + '/' + id, this.httpOptions)
      .pipe(
        catchError(this.handleError('getById', []))
      )
  }

  post(product: Product) {

    return this.http.post(environment.endpointProduct , product, this.httpOptions)
      .pipe(
        catchError(this.handleError('post', []))
      )

  }

  delete(id: number) {


    return this.http.delete(environment.endpointProduct + '/' + id, this.httpOptions)
      .pipe(
        catchError(this.handleError('delete', []))
      )

  }

  put(id: number, product: Product) {

    return this.http.put(environment.endpointProduct + '/' + id, product, this.httpOptions)
      .pipe(
        catchError(this.handleError('delete', []))
      )

  }
 


  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.log(error);
      // TODO: send the error to remote logging infrastructure
      console.error('Erro ao comunicar com o servidor, contate o suporte!', 'OK', { duration: 4000 });

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
