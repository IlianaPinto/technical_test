import { Component, Inject } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
} from '@angular/forms';
import { InputForm } from '../../interfaces/input-form.interface';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-modal',
  imports: [
    MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    FormsModule,
    ReactiveFormsModule,
    MatButtonModule,
  ],
  templateUrl: './modal.component.html',
  styleUrl: './modal.component.css',
})
export class ModalComponent {
  form: FormGroup;

  constructor(
    public dialogRef: MatDialogRef<ModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { event: any; inputs: InputForm[] },
    private fb: FormBuilder
  ) {
    const grupo: any = {};
    data.inputs.forEach((input) => {
      grupo[input.name] = [input.value || ''];
    });
    this.form = this.fb.group(grupo);

    this.form = this.fb.group(
      Object.fromEntries(
        this.data.inputs.map((input) => [
          input.name,
          new FormControl(data.event?.[input.name] ?? ''),
        ])
      )
    );
  }

  save() {
    if (this.form.valid) {
      this.dialogRef.close(this.form.value);
    }
  }

  cancel() {
    this.dialogRef.close();
  }
}
