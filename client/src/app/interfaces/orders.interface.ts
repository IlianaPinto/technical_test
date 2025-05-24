export interface Order {
  id: number;
  customerName: string;
  total: number;
  status: string;
  createdAt: string;
}

export interface OrderSummary {
  customerId: string;
  customerName: string;
  totalOrders: number;
  totalAmount: number;
  lastOrderDate: Date;
}
