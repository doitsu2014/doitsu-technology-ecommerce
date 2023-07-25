import { Component, OnInit, Input } from '@angular/core';
import { LogoSlider } from 'src/app/shared/data/slider';

@Component({
  selector: 'app-logo',
  templateUrl: './logo.component.html',
  styleUrls: ['./logo.component.scss']
})
export class LogoComponent implements OnInit {
  
  @Input() logos: any[] = [];

  constructor() { }

  ngOnInit(): void {
  }

  public LogoSliderConfig: any = LogoSlider;

}
