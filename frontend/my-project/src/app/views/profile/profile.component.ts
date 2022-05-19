import { Component, OnInit,ViewEncapsulation  } from '@angular/core';
import { Validators, FormGroup, FormControl } from "@angular/forms";
import { RegisterService } from '../../../app/shared/service/register.service';
import {states,citys,types} from './data';
import { Router } from '@angular/router';
import { NotificationService } from "@progress/kendo-angular-notification";
@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  encapsulation: ViewEncapsulation.None,
  //styleUrls: ['./profile.component.scss']
  styles:[
    `
    .example {
      display: flex;
      justify-content: center;
  }
  .wrap {
      display: flex;
      justify-content: space-between;
  }
  .k-form {
      width: 400px;
  }
    `
  ]
})
export class ProfileComponent{
  public phoneNumberValue: string = "";
  public phoneNumberMask: string = "(999) 000-00-00";
  public form: FormGroup;
  public updateData: any;
  public data: any = {
    email: "",
    phoneNumber: this.phoneNumberValue,
    address: "",
    state:"",
    city:""
  };
  public emaildata:any={
    email:""
  };
  public states: Array<string> = states;
  public citys: Array<string> = citys;
  public types: Array<string> = types;
  public getsession:any;
  constructor(private service:RegisterService,private router:Router,private notificationService: NotificationService) { 
    this.form = new FormGroup({
      email: new FormControl(this.data.email, [
        Validators.required,
        Validators.email,
      ]),
      phoneNumber: new FormControl(this.data.phoneNumber, [
        Validators.required,
      ]),
      address: new FormControl(this.data.comments),
      state: new FormControl(this.data.state, [Validators.required]),
      city: new FormControl(this.data.city, [Validators.required])
    });
  }

  ngOnInit(): void {
    this.getsession = window.sessionStorage.getItem("username");
    console.log(this.getsession);
    this.emaildata.email=this.getsession;
    this.service.getadmindata(this.emaildata).subscribe(data=>{
      
      console.log(data);
      this.updateData=data;
      this.form.patchValue({
        email : data[0].email,
        phoneNumber : data[0].contactno,
        address : data[0].address,
        state : data[0].state,
        city : data[0].city
      });
    });
    
  }
  public submitForm(): void {
    
    if(this.form.valid)
    {
      var companydata={
        Email:this.getsession,
        Contactno:this.form.value.phoneNumber,
        Address:this.form.value.address,
        State:this.form.value.state,
        City:this.form.value.city
      };
      
      console.log(companydata);
      this.service.updateprofile(companydata).subscribe(res=>{
        // alert(res.toString());
        //this.refreshDepList();
        if(res.toString())
        {
          alert(res.toString());
          this.router.navigate(['/dashboard']);
          this.notificationService.show({
            content: "SuccessFully  Updated Profile",
            hideAfter: 600,
            position: { horizontal: "center", vertical: "bottom" },
            animation: { type: "fade", duration: 1000 },
            type: { style: "success", icon: false },
          });
        }
      });
    }
    else
    {
      alert("Failed");
    }
    
  }

  public clearForm(): void {
    this.form.reset();
  }
}
