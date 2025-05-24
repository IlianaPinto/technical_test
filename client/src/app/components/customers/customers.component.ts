import { Component } from '@angular/core';
import { CustomersService } from '../../services/customer.service';
import { MatTableDataSource } from '@angular/material/table';
import { Customer } from '../../interfaces/customer.interface';
import { DataTableComponent } from '../table/table.component';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-customers',
  imports: [DataTableComponent, MatButtonModule],
  templateUrl: './customers.component.html',
  styleUrl: './customers.component.css',
})
export class CustomersComponent {
  customers = new MatTableDataSource<Customer>();

  columns = [
    { columnDef: 'id', header: 'id', cell: (element: any) => `${element.id}` },
    {
      columnDef: 'name',
      header: 'Nombre',
      cell: (element: any) => `${element.name}`,
    },
    {
      columnDef: 'email',
      header: 'Email',
      cell: (element: any) => `${element.email}`,
    },
    {
      columnDef: 'phoneNumber',
      header: 'Telefono',
      cell: (element: any) => `${element.phoneNumber}`,
    },
    {
      columnDef: 'date',
      header: 'Fecha',
      cell: (element: any) => `${element.date}`,
    },
  ];
  constructor(private customersService: CustomersService) {}

  ngOnInit(): void {
    this.customersService.getCustomers().subscribe({
      next: (data) => (this.customers.data = data),
      error: () => console.error('Error al cargar los clientes'),
    });
  }
}
