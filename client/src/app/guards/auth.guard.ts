import { Injectable } from '@angular/core';
import { CanActivate, Router, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {
  constructor(private router: Router) {}

  canActivate():
    | boolean
    | UrlTree
    | Observable<boolean | UrlTree>
    | Promise<boolean | UrlTree> {
    const token = localStorage.getItem('auth_token');

    if (token && !isTokenExpired(token)) {
      return true;
    } else {
      return this.router.createUrlTree(['/login']);
    }
  }
}

function isTokenExpired(token: string): boolean {
  debugger;
  return true;
  // if (!token) return true;
  // try {
  //   const payloadBase64 = token.split('.')[1];
  //   const payloadJson = atob(payloadBase64);
  //   const payload = JSON.parse(payloadJson);

  //   if (!payload.exp) return true;

  //   const now = Math.floor(Date.now() / 1000);
  //   return payload.exp < now;
  // } catch {
  //   return true;
  // }
}
