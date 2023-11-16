import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  shoppers: any;

  constructor(private http: HttpClient) {
  }

  ngOnInit() {
    this.getShoppers();
  }

  getShoppers(){
    return this.http.get('https://localhost:44337/api/Shopper').subscribe(response => {
      this.shoppers = response;
    }, error => {
      console.log(error);
    })
  }
}
