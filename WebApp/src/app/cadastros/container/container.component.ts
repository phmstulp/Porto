import { Component, OnInit } from '@angular/core';
import { Container } from './model/container';
import { ContainerService } from './container.service';
import { ActivatedRoute, Router } from '@angular/router';
import { fillProperties } from '@angular/core/src/util/property';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-container',
  templateUrl: './container.component.html',
  styleUrls: ['./container.component.css']
})
export class ContainerComponent implements OnInit {

  container: Container;
  edit : Boolean;

  constructor(private containerService: ContainerService, private activatedRoute: ActivatedRoute,
    private router: Router, public spinner: NgxSpinnerService) { }

  ngOnInit() {
    this.container = new Container();

    this.activatedRoute.params.subscribe(params => {
      if (params.id != undefined) {
        this.getById(params.id);
        this.edit = true;
      }
    })
  }

  salvar(){
    this.spinner.show();
    if (this.edit) {
      this.containerService.update(this.container).subscribe(sucesso => {
        if (sucesso != null) 
          console.log(sucesso);
          this.router.navigate(["../container-list"]);
          this.spinner.hide();
      },
      error => {
        console.log(error);
        this.spinner.hide();
      });
    } else {
      this.containerService.save(this.container).subscribe(sucesso => {
        if (sucesso != null) 
          console.log("sucesso");
          this.router.navigate(["../container-list"]);
          this.spinner.hide();
      },
      error => {
        console.log("Erro");
        this.spinner.hide();
      });
  }
  }

  getById(id : number) {
    this.containerService.list(id).subscribe(sucesso => {
      if (sucesso) 
        this.fill(sucesso);
    },
    error => {
      console.log(error);
    });
  }

  fill(container : any) {
    this.container = container;
  }

  voltar() {
    this.router.navigate(["../container-list"]);
  }
  
}