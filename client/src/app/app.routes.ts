import { Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { MainLayoutComponent } from './components/main-layout/main-layout.component';
import { OrdersComponent } from './components/orders/orders.component';
import { CustomersComponent } from './components/customers/customers.component';
import { AdminGuard } from './guards/admin.guard';
import { UserGuard } from './guards/user.guard';
import { DashboardUserComponent } from './components/dashboard-user/dashboard-user.component';

export const routes: Routes = [
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: '',
    component: MainLayoutComponent,

    children: [
      {
        path: 'dashboard',
        component: DashboardComponent,
        canActivate: [AdminGuard],
      },
      {
        path: 'pedidos',
        component: OrdersComponent,
        canActivate: [AdminGuard],
      },
      {
        path: 'clientes',
        component: CustomersComponent,
        canActivate: [AdminGuard],
      },
      {
        path: 'dashboard-user',
        canActivate: [UserGuard],
        component: DashboardUserComponent,
      },
    ],
  },

  {
    path: '**',
    redirectTo: '',
  },
];
