import { Component, OnInit } from '@angular/core';
import { SelectItem } from 'primeng/api';
import { BooksService } from './books.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  books = [
    { id: '1', name: 'O duque e eu' , price: 59.60, rating: 5, category: "Romance", img:"1"},
    { id: '2', name: 'O visconde que me amava' , price: 62.90, rating: 5, category: "Romance", img:"2"},
    { id: '3', name: 'Um perfeito cavalheiro' , price: 60.15, rating: 4.5, category: "Romance", img:"3"},
    { id: '4', name: 'Os segredos de Colin Bridgerton' , price: 61.50, rating: 4.5, category: "Romance", img:"4"},
    { id: '5', name: 'Para Sir Phillip com amor' , price: 59.80, rating: 3, category: "Romance", img:"5"},
    { id: '6', name: 'O conde enfeitiçado' , price: 64.20, rating: 4, category: "Romance", img:"6"},
    { id: '7', name: 'Um beijo inesquecível' , price: 62.30, rating: 5, category: "Romance", img:"7"},
    { id: '8', name: 'A caminho do altar' , price: 60.40, rating: 5, category: "Romance", img:"8"},
    { id: '9', name: 'E viveram felizes para sempre' , price: 61.10, rating: 5, category: "Romance", img:"9"},
    { id: '10', name: 'Coleção completa de Os Bridgertons' , price: 500.00, rating: 4, category: "Romance", img:"completo"},

  ];

  sortOrder: any;
  sortField: any;
  sortOptions: SelectItem[] = [];
  sortKey: string = '';

  constructor(/*private booksService: BooksService*/) { }

    ngOnInit() {
      this.sortOptions = [
        {label: 'Newest First', value: '10'},
        {label: 'Comple6', value: '80'}
      ];
    }
    
    onSortChange(event: any) {
        let value = event.value;

        if (value.indexOf('!') === 0) {
            this.sortOrder = -1;
            this.sortField = value.substring(1, value.length);
        }
        else {
            this.sortOrder = 1;
            this.sortField = value;
        }
    }
}