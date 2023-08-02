import { NgModule } from "@angular/core";
import { UpsertSubredditComponent } from "./upsert-subreddit/upsert-subreddit.component";
import { ReactiveFormsModule } from "@angular/forms";
import { CommonModule } from "@angular/common";
import { FormModule } from "../controls/form/form.module";

const components = [
    UpsertSubredditComponent
];

@NgModule({
    declarations: [
        ...components
    ],
    imports: [
        CommonModule,
        ReactiveFormsModule,
        FormModule
    ],
    exports: [], 
    providers: []
})
export class SubRedditModule {

}