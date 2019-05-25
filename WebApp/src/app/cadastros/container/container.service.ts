import { Injectable } from '@angular/core';
import { BaseService } from '../../shared/base.service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Container } from './model/container';
import { environment } from '../../../environments/environment';


@Injectable({
  providedIn: 'root'
})
export class ContainerService extends BaseService{

  constructor(private http: HttpClient) {
    super();
  }

  save(container: any) : Observable<any>{
    console.log(container)
    //Primeiro Parâmetro === URL
    //Segundo Parâmetro === BODY - Corpo da Requisição
    return this.http.post(environment.urlWebAPI +"Containers/", container)
      .catch((error: any) => Observable.throw(error.error));
  }

  delete(id : number) : Observable<any> {
    return this.http.delete(environment.urlWebAPI +"Containers/"+ id)
      .catch((error: any) => Observable.throw(error.error));
  }

  listAll() : Observable<any> {
    return this.http.get(environment.urlWebAPI +"Containers/")
      .catch((error: any) => Observable.throw(error.error));
  }

  list(id: number) : Observable<any> {
    return this.http.get(environment.urlWebAPI +"Containers/"+ id)
      .catch((error: any) => Observable.throw(error.error));
  }

  update(container: any) : Observable<any>{
    return this.http.put(environment.urlWebAPI +"Containers/"+container.containerId, container)
      .catch((error: any) => Observable.throw(error.error));
  }
}
