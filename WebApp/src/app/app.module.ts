import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { MatInputModule, MatRadioModule, MatButtonModule, MatTableModule, MatIconModule,
  MatPaginatorModule, MatSort, MatSortModule, MatExpansionModule, MatSelectModule, MatDialogRef, MatDialogModule } from '@angular/material';
import { ContainerComponent } from './cadastros/container/container.component';
import { ContainerListComponent } from './cadastros/container/container-list/container-list.component';
import { DialogComponent } from './shared/dialog/dialog/dialog.component';
  
@NgModule({
  declarations: [
    AppComponent,
    ContainerComponent,
    ContainerListComponent,
    DialogComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,

    BrowserAnimationsModule,
    MatInputModule,
    MatRadioModule,
    MatButtonModule, 
    MatTableModule, 
    MatIconModule, 
    HttpClientModule,
    MatPaginatorModule, 
    MatSortModule, 
    MatExpansionModule, 
    MatSelectModule,
    MatDialogModule

  ],
  providers: [HttpClient],

  //Geralmente usa Dialog, Spinner, Message
  entryComponents: [
    DialogComponent
  ],

  bootstrap: [AppComponent]
})
export class AppModule { }
