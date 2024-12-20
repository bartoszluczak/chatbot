import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MessageBubbleComponent } from '../message-bubble/message-bubble.component';
import { Message } from '../../types/messege.model';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import {FormsModule} from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';
import { v4 as uuidv4 } from 'uuid';

@Component({
  selector: 'app-conversation-window',
  imports: [MessageBubbleComponent, FormsModule, MatFormFieldModule, MatInputModule, MatIconModule],
  templateUrl: './conversation-window.component.html',
  styleUrl: './conversation-window.component.scss'
})
export class ConversationWindowComponent {
  @Input() messages: Message[] = []
  @Input() conversationId: string = '';
  @Output() newMessage = new EventEmitter<Message>();
  userMessage = '';

  sendMessage() {
    this.newMessage.emit({
      id: uuidv4(),
      role: 'user',
      content: this.userMessage,
      timestamp: new Date(),
      mark: '',
      conversationId: this.conversationId
    });

    this.userMessage = ''
  }
}
