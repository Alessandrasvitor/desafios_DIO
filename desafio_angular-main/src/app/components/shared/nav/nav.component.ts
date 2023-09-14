import { Component, OnInit } from '@angular/core';
import {MenuItem} from 'primeng/api';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  constructor() { }

  items: MenuItem[] = [];

    ngOnInit() {
        this.items = [
            {label: 'Bookstore', icon: 'pi pi-fw pi-home', routerLink: '*'},
            {label: 'Sobre', icon: 'pi pi-fw pi-calendar', routerLink: 'sobre'},
            {label: 'Produtos', icon: 'pi pi-fw pi-pencil', routerLink: 'produtos'},
            {label: 'Suporte', icon: 'pi pi-fw pi-file', routerLink: 'suporte'}
        ];
    }

}
