import { Component, OnInit } from '@angular/core';
import { FormControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;

  constructor(private fb: FormBuilder, private authService: AuthService) {
    this.loginForm = this.fb.group({

      'username': ['', [Validators.required]],
      'password': ['', Validators.required]

    })
   }

  ngOnInit(): void {
  }

  login(){
  this.authService.login(this.loginForm.value).subscribe(data => {
    console.log(data)
  })

  }

  get username(){
    console.log(this.loginForm.get('username'));
    return this.loginForm.get('username');
  }

  get password(){
    return this.loginForm.get('password');
  }

}
