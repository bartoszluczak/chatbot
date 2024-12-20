import { Component, Input, signal } from '@angular/core';
import {MatIconModule} from '@angular/material/icon';
import { HttpClient } from '@angular/common/http';
import { Message } from '../../types/messege.model';
import { catchError, throwError } from 'rxjs';


@Component({
  selector: 'app-message-bubble',
  imports: [MatIconModule],
  templateUrl: './message-bubble.component.html',
  styleUrl: './message-bubble.component.scss'
})
export class MessageBubbleComponent {

  constructor(private http: HttpClient) {}

  baseURL = 'http://localhost:5093/api/MessageControler'

  @Input() message:Message = {
    id: '',
    role: '',
    content: '',
    mark: '',
    timestamp: new Date(),
    conversationId: ''
  }

  responseMark = signal('');

  ngOnInit() {
    this.responseMark.set(this.message.mark);
  }

  handelMarking(mark: string) {
    this.responseMark.set(mark);
    console.log(this.message.id, mark);
    this.message.mark = mark;
    this.http.put(this.baseURL, this.message).pipe(catchError((error) => throwError(() => new Error(error.message)))).subscribe(response => {
      console.log(response)
    })
  }
}
