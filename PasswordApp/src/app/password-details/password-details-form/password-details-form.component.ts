import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { PasswordDetailsService } from 'src/app/shared/password-details.service';
import { PasswordDetails } from 'src/app/shared/password-details.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-password-details-form',
  templateUrl: './password-details-form.component.html',
  styles: [
  ]
})
export class PasswordDetailsFormComponent implements OnInit {

  constructor(public service: PasswordDetailsService,
    private toastr:ToastrService) { }

  ngOnInit(): void {
  }

  onSubmit(form:NgForm){
    if(this.service.formData.passwordDetailsId == 0){
      this.insertRecord(form)
    } else {
      this.updateRecord(form);
    }
  }

  insertRecord(form:NgForm){
    this.service.postPasswordDetails().subscribe( 
      res => {
        this.resetForm(form);
        this.toastr.success('Entry added, congrats!');
      },
      err => {
        console.log(err);
      }
    );
  }

  updateRecord(form:NgForm){
    this.service.putPasswordDetails().subscribe( 
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.info('Entry updated, congrats!');
      },
      err => {
        console.log(err);
      }
    );
  }

  resetForm(form:NgForm){
    form.form.reset();
    this.service.formData = new PasswordDetails();
  }

}
