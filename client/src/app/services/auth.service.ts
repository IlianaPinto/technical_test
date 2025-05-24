import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginCredentials, LoginResponse } from '../interfaces/auth.interface';

const API_URL = 'http://localhost:5027/Auth';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private http = inject(HttpClient);

  login(credentials: LoginCredentials): Observable<LoginResponse> {
    return this.http.post<LoginResponse>(`${API_URL}/login`, credentials);
  }

  saveToken(token: string): void {
    localStorage.setItem('auth_token', token);
  }

  getToken(): string | null {
    return localStorage.getItem('auth_token');
  }

  logout(): void {
    localStorage.removeItem('auth_token');
  }

  isLoggedIn(): boolean {
    return !!this.getToken();
  }

  setUserRole(role: string) {
    localStorage.setItem('role', role);
  }

  isAdmin(): boolean {
    return localStorage.getItem('role') === 'Admin';
  }

  isUser(): boolean {
    return localStorage.getItem('role') === 'User';
  }
}
function jwtDecode(token: string): any {
  throw new Error('Function not implemented.');
}
