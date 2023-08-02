import { ChangeDetectionStrategy, Component, EventEmitter, Input, Output } from '@angular/core';
import { FormArray, FormControl } from '@angular/forms';
import { SelectionControlItem } from '@app/models/shared/selection-control-item.interface';

@Component({
  selector: 'app-checkbox',
  templateUrl: './checkbox.component.html',
  styleUrls: ['./checkbox.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CheckboxComponent {
  @Input() 
  items!: SelectionControlItem[] | null;

  @Output()
  selected: EventEmitter<string[]> = new EventEmitter<string[]>();

  topicChange(item: SelectionControlItem) : void
  {
    item.selected = !item.selected ?? false;
    const selectedTopics = this.items?.filter((item) => item.selected)
            .map((item) => item.id);

    this.selected.emit(selectedTopics);
  }

}
