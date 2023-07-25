import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/shared/classes/product';
import { ProductSlider } from 'src/app/shared/data/slider';
import { ProductService } from 'src/app/shared/services/product.service';


@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {

  public products: Product[] = [];
  public ProductSliderConfig: any = ProductSlider;

  constructor(public productService: ProductService) {
    this.productService.getProducts.subscribe(response =>
      this.products = response.filter(item => item.type == 'vegetables')
    );
  }

  // Sliders
  public sliders = [{
    title: 'save 10%',
    subTitle: 'fresh vegetables',
    image: 'assets/images/slider/7.jpg'
  }, {
    title: 'save 10%',
    subTitle: 'fresh vegetables',
    image: 'assets/images/slider/8.jpg'
  }];

  // Blogs
  public blogs = [{
    image: 'assets/images/blog/6.jpg',
    date: '25 January 2018',
    title: 'Lorem ipsum dolor sit consectetur adipiscing elit,',
    by: 'John Dio'
  }, {
    image: 'assets/images/blog/7.jpg',
    date: '26 January 2018',
    title: 'Lorem ipsum dolor sit consectetur adipiscing elit,',
    by: 'John Dio'
  }, {
    image: 'assets/images/blog/8.jpg',
    date: '27 January 2018',
    title: 'Lorem ipsum dolor sit consectetur adipiscing elit,',
    by: 'John Dio'
  }, {
    image: 'assets/images/blog/9.jpg',
    date: '28 January 2018',
    title: 'Lorem ipsum dolor sit consectetur adipiscing elit,',
    by: 'John Dio'
  }]

  ngOnInit(): void {
  }
}
