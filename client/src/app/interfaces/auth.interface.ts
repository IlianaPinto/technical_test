export interface LoginCredentials {
  email: string;
  password: string;
}

export interface LoginResponse {
  token: string;
  role: string;
}

export interface AuthUser {
  id: number;
  email: string;
  name: string;
  role?: string;
}
