import { Component, OnInit, ViewChild } from '@angular/core';
import { Container } from '../model/container';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { ContainerService } from '../container.service';
import { Router } from '@angular/router';
import { DialogComponent } from '../../../shared/dialog/dialog/dialog.component';
import { MatDialog } from '../../../../../node_modules/@angular/material';
import { DatePipe } from '../../../../../node_modules/@angular/common';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-container-list',
  templateUrl: './container-list.component.html',
  styleUrls: ['./container-list.component.css']
})
export class ContainerListComponent implements OnInit {

  displayedColumns: string[] = ["descricao", "altura", "largura", "comprimento", "capacidade",
   "dtVencimento", "dtRecord", "editColumn"];
  public dataSource: any;

  @ViewChild(MatPaginator) paginatorCustom: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  constructor(private containerService: ContainerService, private router: Router, 
    private dialog: MatDialog, private datePipe: DatePipe, public spinner: NgxSpinnerService) { }

  ngOnInit() {
    this.listAll();
  }

  deleteConfirmation(id: number) {
    let dialogRef = this.dialog.open(DialogComponent, {
      panelClass: 'custom-dialog',
      data: 'Confirmar exclusão do registro ?',
      disableClose: true
    });

    dialogRef.afterClosed().subscribe(isConfirm => {
      if(isConfirm)
        this.remover(id);
    });
  }

  remover(id : number) {
    this.containerService.delete(id).subscribe(sucesso => {
      if(sucesso != null) {
        this.listAll();
      }
    },
    error => {
      console.log("Erro");
    });
  }

  editar(id : number) {
    this.router.navigate(["../container-edit/"+id]);
  }

  listAll() {
    this.spinner.show();
    this.containerService.listAll().subscribe(sucesso => {
      if(sucesso != null) {
        this.atualizaTabela(sucesso);
        this.spinner.hide();
      }
    },
    error => {
      console.log("Erro");
      this.spinner.hide();
    });
  }

  list(id : number) {
    this.spinner.show();
    this.containerService.list(id).subscribe(sucesso => {
      if(sucesso != null) {
        this.atualizaTabela(sucesso);
        this.spinner.hide();
      }
    },
    error => {
      console.log("Erro");
      this.spinner.hide();
    });
  }

  atualizaTabela(containers : any) {
    this.dataSource = new MatTableDataSource<Container>(containers);
    this.dataSource.paginator = this.paginatorCustom;
    this.dataSource.sort = this.sort;
  }

  callNew() {
    this.router.navigate(["../container"]);
  }

}
