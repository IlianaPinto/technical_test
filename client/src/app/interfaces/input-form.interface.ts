export interface InputForm {
  name: string;
  type: 'text' | 'number' | 'select';
  label: string;
  options?: string[];
  value?: any;
}
