import { Component, OnInit } from '@angular/core';
import { SampleService } from '../../services/sample/sample.service';

@Component({
  selector: 'app-medicine-list',
  templateUrl: './medicine-list.component.html',
  styleUrls: ['./medicine-list.component.scss']
})
export class MedicineListComponent implements OnInit {

  data: any;
  constructor(private sampleService: SampleService) { }

  ngOnInit() {
    this.getData();
  }

  getData() {
    this.sampleService.getAllMedicinesData().subscribe(
      response => {
        this.data = response;
      },
      error => {
        console.log(error);
      }
    );
  }

}
