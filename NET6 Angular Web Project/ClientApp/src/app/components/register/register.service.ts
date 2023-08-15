import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RegisterModel } from '../../models/register.model';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  constructor(private http: HttpClient) { }

  registerUser(user: RegisterModel): Observable<any> {
    const url = 'https://localhost:7275/api/users/registeruser'; // Reemplaza esto con la URL de tu API
    return this.http.post(url, user);
  }
}
