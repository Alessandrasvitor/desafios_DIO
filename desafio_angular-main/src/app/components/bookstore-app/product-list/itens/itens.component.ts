import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-itens',
  templateUrl: './itens.component.html',
  styleUrls: ['./itens.component.css']
})
export class ItensComponent implements OnInit {
  
  @Input()
  book!: any;

  constructor() { }

  ngOnInit(): void {
  }

}
