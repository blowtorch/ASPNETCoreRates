import { Component, OnInit } from '@angular/core';
import { CORE_DIRECTIVES } from '@angular/common';
import { DataService } from '../services/DataService';
import { Rate }  from "../models/Rate");

@Component({
    selector: 'home',
    templateUrl: 'app/home/home.component.html',
    directives: [CORE_DIRECTIVES],
    providers:[DataService]
})

export class HomeComponent implements OnInit {

    public message: string;
    public rates: any[];
    public newRate: Rate;

    constructor(private _dataService: DataService) {
        this.newRate = new Rate();
    }

    ngOnInit() {
        this._dataService
        .GetAll()
            .subscribe(
                data => this.rates = data,
                error => console.log(error),
                () => console.log('Get all complete'));
    }

    selectRate(rate: number) {
        alert(`You selected:${rate.toString()}`);
    }

    setNewRateValue(value: number) {
        this.newRate.rate = value;
    }

    addRate() {
        //TODO: Save new rate
    }
}
