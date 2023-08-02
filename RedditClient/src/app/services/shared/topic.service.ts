import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { REDDIT_TOPIC_URL } from '@app/constants/config';
import { IResponse } from '@app/models/shared/response.interface';
import { SelectionControlItem } from '@app/models/shared/selection-control-item.interface';
import { environment } from '@environments/environment';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class TopicService {

  constructor(
    private http: HttpClient
  ) { }

  loadTopics() {
    return this.http.get<IResponse<SelectionControlItem[]>>(`${environment.apiUrl}/${REDDIT_TOPIC_URL}`, 
    {  
      withCredentials: true  
    })
    .pipe(
      map( (res: IResponse<SelectionControlItem[]>) => { 
        return res.data as SelectionControlItem[];
      })
    );
  }
}
