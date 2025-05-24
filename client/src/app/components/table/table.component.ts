import { Component, Input, ViewChild } from '@angular/core';
import { MatTableModule, MatTableDataSource } from '@angular/material/table';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-table',
  standalone: true,
  imports: [MatTableModule, MatFormFieldModule, MatInputModule, CommonModule],
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css'],
})
export class DataTableComponent<T> {
  @Input() dataSource!: MatTableDataSource<T>;
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
  displayedColumns: string[] = this.columns.map((c) => c.columnDef);

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
}
