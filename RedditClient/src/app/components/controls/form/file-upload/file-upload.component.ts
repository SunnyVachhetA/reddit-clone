import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-file-upload',
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.css']
})
export class FileUploadComponent implements OnInit {

  @Input()
  public parentForm!: FormGroup;

  @Input()
  public controlName!: string;

  @Input()
  public label!: string;

  @Input()
  public placeholder: string = '';

  @Input()
  public showPreview: boolean = false;

  @Input() 
  public previewFileCss:string = '';

  @Output()
  public selectFile: EventEmitter<File | null> = new EventEmitter<File | null>();

  public previewFileSrc?: string | null = '';

  public control!: FormControl;

  ngOnInit(): void {
    this.control = this.parentForm.get(this.controlName) as FormControl;
  }

  public onSelectFile(event: Event) : void {
    const target = event.target as HTMLInputElement;

    if(!target.files || !target.files[0]) return;

    const reader = new FileReader();

    reader.readAsDataURL(target.files[0]);

    reader.onload = (e) => {
      this.previewFileSrc = e.target?.result as string;
      this.parentForm.patchValue({
        controlName: e.target?.result
      });
    };

    this.selectFile.emit(target.files.item(0));
  }
}
