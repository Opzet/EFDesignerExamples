---
name: UserRegisteredEvent
summary: Event triggered when a user is registered in the system.
version: 1.0.0
producers:
  - UserService
consumers:
  - NotificationService
  - AnalyticsService
schema:
  properties:
    id:
      type: string
      description: Unique identifier for the event.
    occurredOn:
      type: string
      format: date-time
      description: Timestamp of when the event occurred.
    username:
      type: string
      description: Registered user's username.
    email:
      type: string
      description: Registered user's email address.
