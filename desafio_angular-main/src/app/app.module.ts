import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms'; 

import { AppComponent } from './app.component';
import { BookstoreAppComponent } from './components/bookstore-app/bookstore-app.component';
import { ProductListComponent } from './components/bookstore-app/product-list/product-list.component';
import { FooterComponent } from './components/shared/footer/footer.component';
import { NavComponent } from './components/shared/nav/nav.component';
import { MenubarModule } from 'primeng/menubar';
import { AppRoutingModule } from './app.routing.module';
import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';
import { InputNumberModule } from 'primeng/inputnumber';
import { ItensComponent } from './components/bookstore-app/product-list/itens/itens.component';
import { DataViewModule } from 'primeng/dataview';
import { DropdownModule } from 'primeng/dropdown';
import { RatingModule } from 'primeng/rating';
import { InputTextModule } from 'primeng/inputtext';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    FooterComponent,
    BookstoreAppComponent,
    ProductListComponent,
    ItensComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    MenubarModule,
    AppRoutingModule,
    ButtonModule,
    CardModule,
    InputNumberModule,
    DataViewModule,
    DropdownModule,
    RatingModule,
    InputTextModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
