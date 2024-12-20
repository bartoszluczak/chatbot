export interface Message {
  id: string,
  role: string,
  content: string,
  mark: string,
  timestamp: Date,
  conversationId: string
}
