# Console Task Manager

A feature-rich console-based task management system built with C# and dependency injection.

## Features

- **Task Management**:
  - Create tasks with names and priorities
  - Mark tasks as complete/incomplete
  - Update task priorities
- **Task Views**:
  - View all tasks
  - Filter by completion status
  - Sort by priority level (High/Medium/Low)
- **User Experience**:
  - Personalized welcome message
  - Input validation
  - Clean console interface

## Technical Implementation

### Architecture
- **Dependency Injection** (Microsoft.Extensions.Hosting)
- **Clean Separation**:
  - Services (business logic)
  - Interfaces (abstractions)
  - Helpers (utility classes)
- **SOLID Principles** applied

### Key Components
| Component          | Responsibility                          |
|--------------------|----------------------------------------|
| `TaskService`      | Core task operations                   |
| `Menu`             | User interaction flow                  |
| `TaskDisplayer`    | Presentation logic                     |
| `UserTask`         | Data model with enums                  |
| `IntInputValidator`| Input validation                       |

## How to Use

1. Clone the repository
2. Build and run in Visual Studio (or `dotnet run`)
3. Follow the menu prompts:
   - Enter your name
   - Choose from 7 main options
   - Manage your tasks

## Code Quality Highlights

- Strong typing with enums (`TaskPriority`, `TaskStatus`)
- Input validation throughout
- Single Responsibility Principle in classes
- Dependency injection for testability
- Clear separation of concerns

## Example Usage

```plaintext
Welcome to the Task Manager!
Enter your name: John

1. Add tasks
2. Assign priority to tasks
3. Mark tasks as complete
4. Show all tasks
5. Filter by completion status
6. Sort by priority
7. Exit

Choose an option: 1
Enter task name: Finish project
Set priority (1-3): 1
Task successfully added!