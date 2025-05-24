import { Component } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { OrderUserSummary } from '../../interfaces/orders.interface';
import { DataTableComponent } from '../table/table.component';

@Component({
  selector: 'app-dashboard-user',
  imports: [DataTableComponent],
  templateUrl: './dashboard-user.component.html',
  styleUrl: './dashboard-user.component.css',
})
export class DashboardUserComponent {
  ordersSummary = new MatTableDataSource<OrderUserSummary>();
  columns = [
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
}
