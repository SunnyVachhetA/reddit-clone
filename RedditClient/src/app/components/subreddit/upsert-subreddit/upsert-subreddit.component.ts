import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import {
    FormArray,
    FormBuilder,
    FormControl,
    FormGroup,
    Validators,
} from '@angular/forms';
import { SelectionControlItem } from '@app/models/shared/selection-control-item.interface';
import { SubredditStatus } from '@app/models/subreddit/subreddit-status';
import { SubredditType } from '@app/models/subreddit/subreddit-type';
import { TopicService } from '@app/services/shared/topic.service';
import { SubredditService } from '@app/services/subreddit/subreddit.service';
import { toFormData } from '@app/shared/formhelper/to-form-data.function';
 
@Component({
    selector: 'upsert-subreddit',
    templateUrl: './upsert-subreddit.component.html',
    styleUrls: ['./upsert-subreddit.component.css']
})
export class UpsertSubredditComponent implements OnInit {
    subredditForm!: FormGroup;

    title!: FormControl;
    slug!: FormControl;
    icon!: FormControl;
    banner!: FormControl;
    description!: FormControl;
    status!: FormControl;
    type!: FormControl;
    topics!: FormArray<FormControl>;

    topicOptions!: null | SelectionControlItem[];
    selectedTopics: string[] = [];

    statusMenu: SelectionControlItem[] = SubredditStatus;
    typeMenu: SelectionControlItem[] = SubredditType;

    constructor(
        private fb: FormBuilder,
        private topicService: TopicService,
        private subredditService: SubredditService
    ) { }

    ngOnInit(): void {
        this.loadTopics();
        this.createForm();
    }

    private createForm(): void {
        this.title = new FormControl('', [Validators.required]);
        this.slug = new FormControl('', [Validators.required]);

        this.description = new FormControl('', [Validators.required]);

        this.type = new FormControl(1, [Validators.required]);

        this.status = new FormControl('');

        this.topics = this.fb.array([]);

        this.icon = new FormControl(null);

        this.banner = new FormControl(null);

        this.subredditForm = new FormGroup({
            title: this.title,
            slug: this.slug,
            description: this.description,
            type: this.type,
            topics: this.topics,
            status: this.status,
            icon: this.icon,
            banner: this.banner
        });
    }

    private loadTopics() {
        this.topicService.loadTopics()
            .subscribe({
                next: (res: SelectionControlItem[]) => {
                    this.topicOptions = res;
                    this.loadTopicsInFormArray();
                }
            });
    }

    private loadTopicsInFormArray() {
        if (!this.topicOptions) return;

        this.topicOptions.forEach((topic: SelectionControlItem) => {
            this.topics.push(this.fb.control(topic.selected ?? false));
        });
    }

    addTopic(selectedTopics: string[]): void {
        this.selectedTopics = selectedTopics;
    }

    onSubmit(): void {
        console.log(this.subredditForm.value);
        if (this.subredditForm.invalid) return;

        const formData = new FormData();
        debugger;
        formData.append('title', this.title?.value);
        formData.append("slug", this.slug?.value);
        formData.append("icon", this.icon?.value);
        formData.append("banner", this.banner?.value);
        formData.append("description", this.description?.value);
        formData.append("status", this.status?.value);
        formData.append("type", this.type?.value);
        if (this.selectedTopics) {
            this.selectedTopics?.forEach( topic => formData.append("Topics", topic) )
        }
        console.log(formData);
        this.subredditService.createSubreddit( formData );
    }

    uploadIconFile(file: File | null): void {
        this.icon.setValue(file);
    }

    uploadBannerFile(file: File | null): void {
        this.banner.setValue(file);
    }
}
