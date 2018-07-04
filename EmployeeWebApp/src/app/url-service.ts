import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class URLService {
  constructor(private http: HttpClient, private router: Router) { }
  url: string = 'http://localhost:61710/api/';

 

   postMethod(navigateTo, data): any {
    var header = new HttpHeaders();
    header = new HttpHeaders({ 'Content-Type': 'application/json' })

    return this.http.post<any>(this.url + navigateTo, data, { headers: header, observe: 'response' })
      .map((res: HttpResponse<any>) => {       
        return res.body;
      }).catch(error => {
       
        if (error.status == 401) {
        
          this.router.navigateByUrl('/home');
        }
        else
          
          return error;
      })
  }
  
}
