import { Component, OnInit, ViewChild } from '@angular/core';
import { Container } from '../model/container';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { ContainerService } from '../container.service';
import { Router } from '@angular/router';
import { DialogComponent } from '../../../shared/dialog/dialog/dialog.component';
import { MatDialog } from '../../../../../node_modules/@angular/material';

@Component({
  selector: 'app-container-list',
  templateUrl: './container-list.component.html',
  styleUrls: ['./container-list.component.css']
})
export class ContainerListComponent implements OnInit {

  displayedColumns: string[] = ["descricao", "altura", "largura", "comprimento", "capacidade", "dtVencimento", "editColumn"];
  public dataSource: any;

  @ViewChild(MatPaginator) paginatorCustom: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  constructor(private containerService: ContainerService, private router: Router, 
    private dialog: MatDialog) { }

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
    this.containerService.listAll().subscribe(sucesso => {
      if(sucesso != null) {
        this.atualizaTabela(sucesso);
      }
    },
    error => {
      console.log("Erro");
    });
  }

  list(id : number) {
    this.containerService.list(id).subscribe(sucesso => {
      if(sucesso != null) {
        this.atualizaTabela(sucesso);
      }
    },
    error => {
      console.log("Erro");
    });
  }

  atualizaTabela(containers : any) {
    this.dataSource = new MatTableDataSource<Container>(containers);
    this.dataSource.paginator = this.paginatorCustom;
    this.dataSource.sort = this.sort;
  }

}
