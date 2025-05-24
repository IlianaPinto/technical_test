import { Component } from '@angular/core';
import { CustomersService } from '../../services/customer.service';
import { MatTableDataSource } from '@angular/material/table';
import { Customer } from '../../interfaces/customer.interface';
import { DataTableComponent } from '../table/table.component';
import { MatButtonModule } from '@angular/material/button';
import { InputForm } from '../../interfaces/input-form.interface';
import { ModalComponent } from '../modal/modal.component';
import { MatDialog } from '@angular/material/dialog';

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
  constructor(
    private customersService: CustomersService,
    private dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.loadCustomers();
  }

  loadCustomers() {
    this.customersService.getCustomers().subscribe({
      next: (data) => (this.customers.data = data),
      error: () => console.error('Error al cargar los clientes'),
    });
  }

  openModal(event: any): void {
    const inputs: InputForm[] = [
      { name: 'name', type: 'text', label: 'Nombre' },
      { name: 'email', type: 'text', label: 'Email' },
      { name: 'phoneNumber', type: 'number', label: 'Numero de Telefono' },
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
          this.customersService.createCustomer(result).subscribe({
            next: (response) => {
              console.log('Cliente creado:', response);
              this.loadCustomers();
            },
            error: (err) => console.error('Error al actualizar:', err),
          });
        }
      });
  }
}
