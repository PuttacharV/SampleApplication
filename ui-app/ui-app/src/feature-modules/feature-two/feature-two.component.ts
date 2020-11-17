import { Component, OnInit } from '@angular/core';
import { SampleService } from './services/sample/sample.service';

@Component({
  selector: 'app-feature-two',
  templateUrl: './feature-two.component.html',
  styleUrls: ['./feature-two.component.scss']
})
export class FeatureTwoComponent implements OnInit {

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
