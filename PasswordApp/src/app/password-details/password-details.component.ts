import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { PasswordDetails } from '../shared/password-details.model';
import { PasswordDetailsService } from '../shared/password-details.service';

@Component({
  selector: 'app-password-details',
  templateUrl: './password-details.component.html',
  styles: [
  ]
})
export class PasswordDetailsComponent implements OnInit {

  constructor(public service: PasswordDetailsService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(selectedRecord:PasswordDetails){
    this.service.formData = Object.assign({}, selectedRecord);
  }

  onDelete(id:number){
    this.service.deletePasswordDetails(id)
    .subscribe(
      res =>{
        this.service.refreshList();
        this.toastr.error('Entry deleted, congrats!');
      },
      err => {console.log(err)}
    )
  }

}
