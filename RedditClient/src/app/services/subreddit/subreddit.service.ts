import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SUBREDDIT_URL } from '@app/constants/config';
import { environment } from '@environments/environment';

@Injectable({ providedIn: 'root' })
export class SubredditService {
    private readonly addUrl = `${environment.apiUrl}/${SUBREDDIT_URL}`;
    constructor(
        private http: HttpClient
    ) { }

    createSubreddit(obj: FormData): void {
        obj.forEach((value,key) => {
            console.log(key+" "+value)
          });
        debugger;

        this.http.post<any>(this.addUrl, obj)
            .subscribe(res => {
                debugger;
                return console.log(res);
            });
    }

}