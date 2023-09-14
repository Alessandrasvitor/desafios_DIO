import {Injectable} from "@angular/core";


export const books: any[] = [
    { id: '1', name: 'O duque e eu' , price: 10, quantity: 1, category: "Romance", img:"1"},
    { id: '2', name: 'O visconde que me amava' , price: 10, quantity: 1, category: "Romance", img:"2"},
    { id: '3', name: 'Um perfeito cavalheiro' , price: 10, quantity: 1, category: "Romance", img:"3"},
    { id: '4', name: 'Os segredos de Colin Bridgerton' , price: 10, quantity: 1, category: "Romance", img:"4"},
    { id: '5', name: 'Para Sir Phillip com amor' , price: 10, quantity: 1, category: "Romance", img:"5"},
    { id: '6', name: 'O conde enfeitiçado' , price: 10, quantity: 1, category: "Romance", img:"6"},
    { id: '7', name: 'Um beijo inesquecível' , price: 10, quantity: 1, category: "Romance", img:"7"},
    { id: '8', name: 'A caminho do altar' , price: 10, quantity: 1, category: "Romance", img:"8"},
    { id: '9', name: 'E viveram felizes para sempre' , price: 10, quantity: 1, category: "Romance", img:"9"},
    { id: '10', name: 'Coleção completa de Os Bridgertons' , price: 80, quantity: 1, category: "Romance", img:"completo"},

  ];

@Injectable()
export class BooksService {
    
   constructor() {}

    getBooks() {
      return books;  
    }

}
