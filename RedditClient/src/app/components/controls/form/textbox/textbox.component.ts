import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-textbox',
  templateUrl: './textbox.component.html',
  styleUrls: ['./textbox.component.css']
})
export class TextboxComponent implements OnInit {

  @Input()
  name!: string; 

  @Input() 
  label!: string;

  @Input()
  placeholder!: string;

  @Input() 
  value: string = '';

  @Input() 
  parentForm!: FormGroup;

  @Input() 
  controlName!: string;

  @Input() 
  control!: FormControl;

  ngOnInit(): void {
    this.control = this.parentForm.get(this.controlName) as FormControl; 
  }

}
