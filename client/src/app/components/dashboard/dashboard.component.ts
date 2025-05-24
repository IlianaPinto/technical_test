import { Component } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { OrderSummary } from '../../interfaces/orders.interface';
import { OrdersService } from '../../services/orders.service';
import { DataTableComponent } from '../table/table.component';

@Component({
  selector: 'app-dashboard',
  imports: [DataTableComponent],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css',
})
export class DashboardComponent {
  ordersSummary = new MatTableDataSource<OrderSummary>();
  columns = [
    {
      columnDef: 'id',
      header: 'id',
      cell: (element: any) => `${element.customerId}`,
    },
    {
      columnDef: 'customerName',
      header: 'Nombre Cliente',
      cell: (element: any) => `${element.customerName}`,
    },
    {
      columnDef: 'totalOrders',
      header: 'Cantidad de Pedidos',
      cell: (element: any) => `${element.totalOrders}`,
    },
    {
      columnDef: 'totalAmount',
      header: 'Monto Total',
      cell: (element: any) => `${element.totalAmount}`,
    },
    {
      columnDef: 'lastOrderDate',
      header: 'Ultimo Pedido',
      cell: (element: any) => `${element.lastOrderDate}`,
    },
  ];

  constructor(private ordersService: OrdersService) {}

  ngOnInit(): void {
    this.ordersService.getOrdersSummary().subscribe({
      next: (data) => (this.ordersSummary.data = data),
      error: () => console.error('Error al cargar los clientes'),
    });
  }
}
