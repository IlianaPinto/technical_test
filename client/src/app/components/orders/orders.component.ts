import { Component, inject, OnInit } from '@angular/core';
import { OrdersService } from '../../services/orders.service';
import { Order } from '../../interfaces/orders.interface';
import { DataTableComponent } from '../table/table.component';
import { MatTableDataSource } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { InputForm } from '../../interfaces/input-form.interface';
import { MatDialog } from '@angular/material/dialog';
import { ModalComponent } from '../modal/modal.component';

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

  readonly dialog = inject(MatDialog);

  ngOnInit(): void {
    this.loadOrders();
  }

  loadOrders() {
    this.ordersService.getOrders().subscribe({
      next: (data) => (this.orders.data = data),
      error: () => console.error('Error al cargar las órdenes'),
    });
  }

  openModal(event: any): void {
    const inputs: InputForm[] = [
      { name: 'total', type: 'number', label: 'Total' },
      {
        name: 'status',
        type: 'select',
        label: 'Status',
        options: ['Pending', 'Completed', 'Canceled'],
      },
    ];

    this.dialog
      .open(ModalComponent, {
        width: '400px',
        height: '500px',
        data: { inputs, event },
      })
      .afterClosed()
      .subscribe((result) => {
        if (result) {
          console.log('Resultado del formulario:', result);
          this.ordersService.updateOrder(event.id, result).subscribe({
            next: (response) => {
              console.log('Pedido actualizado:', response);
              this.loadOrders();
            },
            error: (err) => console.error('Error al actualizar:', err),
          });
        }
      });
  }
}
