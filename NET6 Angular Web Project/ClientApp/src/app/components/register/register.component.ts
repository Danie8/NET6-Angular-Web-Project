import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ValidationErrors } from '@angular/forms';
import { RegisterService } from './register.service'; // Asegúrate de que esta ruta sea correcta.

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registerForm!: FormGroup;
  isRegistered = false;
  constructor(private formBuilder: FormBuilder, private registerService: RegisterService) { }

  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      //email: ['', [Validators.required, Validators.email]],
      email: ['daniel@mail.com', [Validators.required]],
      userName: ['dangeles', [Validators.required, Validators.minLength(3), Validators.maxLength(50), Validators.pattern('.*')]],
      password: ['123456', [Validators.required, Validators.minLength(6), Validators.maxLength(100)]],
      confirmPassword: ['123456', [Validators.required]],
      nombreCompleto: ['Daniel A', [Validators.required, Validators.minLength(5), Validators.maxLength(50)]],
      empresa: ['COMPANY', [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
      area: ['TII', [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
      referencia: ['COMPANY', [Validators.required]]
    }, {
      //validator: this.mustMatch('password', 'confirmPassword')
    });
  }

  mustMatch(controlName: string, matchingControlName: string) {
    return (formGroup: FormGroup) => {
      const control = formGroup.controls[controlName];
      const matchingControl = formGroup.controls[matchingControlName];

      if (matchingControl.errors && !matchingControl.errors.mustMatch) {
        return;
      }

      if (control.value !== matchingControl.value) {
        matchingControl.setErrors({ mustMatch: true });
      } else {
        matchingControl.setErrors(null);
      }
    }
  }

  // Método para manejar el evento submit
  onSubmit() {
    // Comprueba si el formulario es válido
    if (this.registerForm.valid) {
      // Aquí se manejaría la lógica para enviar los datos a tu servidor
      // Por ejemplo:
      this.registerService.registerUser(this.registerForm.value).subscribe(response => {
        console.debug('Registro Exitoso. | ' + JSON.stringify(response));
        this.isRegistered = true;
      }, error => {
        console.error('Hubo un error al registrar el usuario', error);
      });
    } else {
      // Marca todos los controles como 'touched' para activar las validaciones
      console.debug('Corrije los errores.');
      this.registerForm.markAllAsTouched();

      // Imprimir los errores de cada control individual
      Object.keys(this.registerForm.controls).forEach(key => {
        const controlErrors: ValidationErrors | null | undefined = this.registerForm.get(key)?.errors;
        if (controlErrors != null) {
          Object.keys(controlErrors).forEach(keyError => {
            console.log('Key control: ' + key + ', keyError: ' + keyError + ', err value: ', controlErrors[keyError]);
          });
        }
      });
    }
  }

}
