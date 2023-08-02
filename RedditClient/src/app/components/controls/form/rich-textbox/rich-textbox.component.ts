import { Component, Input, OnInit } from '@angular/core';
import ClassicEditor from '@ckeditor/ckeditor5-build-classic';

@Component({
  selector: 'app-rich-textbox',
  templateUrl: './rich-textbox.component.html',
  styleUrls: ['./rich-textbox.component.css']
})
export class RichTextboxComponent implements OnInit {

  data: string = '';
  public Editor = ClassicEditor;

  @Input()
  placeholder : string = '';

  ngOnInit(): void {
    console.log(this.placeholder);
    debugger;
  }
}
