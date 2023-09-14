import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductListComponent } from './components/bookstore-app/product-list/product-list.component';

const routes: Routes = [
  { path: '*', component: ProductListComponent },
  { path: 'sobre', component: ProductListComponent },
  { path: 'produtos', component: ProductListComponent },
  { path: 'suporte', component: ProductListComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }