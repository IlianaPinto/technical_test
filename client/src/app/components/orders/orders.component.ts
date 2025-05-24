import { Component, OnInit } from '@angular/core';
import { OrdersService } from '../../services/orders.service';
import { Order } from '../../interfaces/orders.interface';
import { DataTableComponent } from '../table/table.component';
import { MatTableDataSource } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-orders',
  imports: [MatIconModule, DataTableComponent],
  templateUrl: './orders.component.html',
  styleUrl: './orders.component.css',
})
export class OrdersComponent implements OnInit {
  orders = new MatTableDataSource<Order>();

  columns = [
    { columnDef: 'id', header: 'id', cell: (element: any) => `${element.id}` },
    {
      columnDef: 'customerName',
      header: 'Nombre',
      cell: (element: any) => `${element.customerName}`,
    },
    {
      columnDef: 'total',
      header: 'Monto',
      cell: (element: any) => `${element.total}`,
    },
    {
      columnDef: 'status',
      header: 'Status',
      cell: (element: any) => `${element.status}`,
    },
    {
      columnDef: 'actions',
      header: 'Acciones',
      cell: () => '',
    },
  ];

  constructor(private ordersService: OrdersService) {}

  ngOnInit(): void {
    this.ordersService.getOrders().subscribe({
      next: (data) => (this.orders.data = data),
      error: () => console.error('Error al cargar las órdenes'),
    });
  }
}
