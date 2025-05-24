import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Customer } from '../interfaces/customer.interface';

const API_URL = 'http://localhost:5027/customer';

@Injectable({
  providedIn: 'root',
})
export class CustomersService {
  private http = inject(HttpClient);

  private getAuthHeaders(): HttpHeaders {
    const token = localStorage.getItem('auth_token');
    return new HttpHeaders({
      Authorization: `Bearer ${token}`,
    });
  }

  getCustomers(): Observable<Customer[]> {
    return this.http.get<Customer[]>(API_URL, {
      headers: this.getAuthHeaders(),
    });
  }

  getCustomerById(id: number): Observable<Customer> {
    return this.http.get<Customer>(`${API_URL}/${id}`, {
      headers: this.getAuthHeaders(),
    });
  }

  createCustomer(customer: Partial<Customer>): Observable<Customer> {
    return this.http.post<Customer>(API_URL, customer, {
      headers: this.getAuthHeaders(),
    });
  }

  updateCustomer(
    id: number,
    customer: Partial<Customer>
  ): Observable<Customer> {
    return this.http.put<Customer>(`${API_URL}/${id}`, customer, {
      headers: this.getAuthHeaders(),
    });
  }

  deleteCustomer(id: number): Observable<void> {
    return this.http.delete<void>(`${API_URL}/${id}`, {
      headers: this.getAuthHeaders(),
    });
  }
}
