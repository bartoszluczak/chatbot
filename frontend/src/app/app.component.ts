import { Message } from './types/messege.model';
import { Component } from '@angular/core';
import { ConversationWindowComponent } from './core/conversation-window/conversation-window.component';
import { v4 as uuidv4 } from 'uuid';
import { HttpClient } from '@angular/common/http';
import { catchError, throwError } from 'rxjs';

@Component({
  selector: 'app-root',
  imports: [ConversationWindowComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {

  constructor(private http: HttpClient) {}

  title = 'ChatBot';
  baseURL = 'http://localhost:5093/api/MessageControler'
  messages: Message[] = [];
  conversationId = uuidv4();

  ngOnInit() {
    this.http.get<Message[]>(this.baseURL).pipe(catchError((error) => throwError(() => new Error("Something goes wrong!")))).subscribe(messages => {
      this.messages = [...this.messages, ...messages].sort((a,b) => new Date(a.timestamp).getTime() - new Date(b.timestamp).getTime())
    })
  }

  sendNewMessage($event: any) {
    this.messages.push($event);
    this.http.post<Message>(this.baseURL, $event).subscribe(resp => {
      this.messages = [...this.messages, resp]
    });
  }
}
