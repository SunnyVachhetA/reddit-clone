import { ChangeDetectionStrategy, Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { SelectionControlItem } from '@app/models/shared/selection-control-item.interface';

@Component({
  selector: 'app-dropdown',
  templateUrl: './dropdown.component.html',
  styleUrls: ['./dropdown.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class DropdownComponent implements OnInit {

  @Input()
  label!: string;

  @Input()
  dropdownItems: SelectionControlItem[] = [];

  @Input()
  required: boolean = true;

  @Input()
  selectedValue?: string;

  @Input()
  placeholder!: string;

  @Input() 
  showDeleted: boolean = false;

  @Input()
  parentForm!: FormGroup;

  @Input()
  controlName!: string;

  control!: FormControl;

  ngOnInit(): void {

    this.control = this.parentForm.get(this.controlName) as FormControl;

    if(!this.showDeleted)
    {
      this.dropdownItems = this.dropdownItems.filter( item => item.id !== 0 );
    }
  }
}
