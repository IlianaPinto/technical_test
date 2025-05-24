import { Component, OnInit } from '@angular/core';
import { OrdersService } from '../../services/orders.service';
import { Order } from '../../interfaces/orders.interface';
import { DataTableComponent } from '../table/table.component';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-orders',
  imports: [DataTableComponent],
  templateUrl: './orders.component.html',
  styleUrl: './orders.component.css',
})
export class OrdersComponent implements OnInit {
  orders = new MatTableDataSource<Order>();

  constructor(private ordersService: OrdersService) {}

  ngOnInit(): void {
    this.ordersService.getOrders().subscribe({
      next: (data) => (this.orders.data = data),
      error: () => console.error('Error al cargar las órdenes'),
    });
  }
}
