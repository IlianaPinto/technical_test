import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Order, OrderSummary } from '../interfaces/orders.interface';

const API_URL = 'http://localhost:5027/Order';

@Injectable({
  providedIn: 'root',
})
export class OrdersService {
  private http = inject(HttpClient);

  private getAuthHeaders(): HttpHeaders {
    const token = localStorage.getItem('auth_token');
    return new HttpHeaders({
      Authorization: `Bearer ${token ?? ''}`,
    });
  }

  getOrders(): Observable<Order[]> {
    return this.http.get<Order[]>(API_URL, {
      headers: this.getAuthHeaders(),
    });
  }

  getOrdersSummary(): Observable<OrderSummary[]> {
    return this.http.get<OrderSummary[]>(`${API_URL}/summary/by-customer`, {
      headers: this.getAuthHeaders(),
    });
  }

  getOrderById(id: number): Observable<Order> {
    return this.http.get<Order>(`${API_URL}/${id}`, {
      headers: this.getAuthHeaders(),
    });
  }

  createOrder(order: Partial<Order>): Observable<Order> {
    return this.http.post<Order>(API_URL, order, {
      headers: this.getAuthHeaders(),
    });
  }

  updateOrder(id: number, order: Partial<Order>): Observable<Order> {
    return this.http.put<Order>(`${API_URL}/${id}`, order, {
      headers: this.getAuthHeaders(),
    });
  }

  deleteOrder(id: number): Observable<void> {
    return this.http.delete<void>(`${API_URL}/${id}`, {
      headers: this.getAuthHeaders(),
    });
  }
}
