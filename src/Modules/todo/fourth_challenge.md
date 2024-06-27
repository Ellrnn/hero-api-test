## TODO challenge

You need to develop a simple CRUD (Create, Read, Update, Delete) for a task entity, in the "To-Do" model.

The "To-Do" entity must contain the following properties:

- **Id**: A unique identifier for the task.
- **Name**: The name of the task. Required.
- **Description**: A more detailed description of the task.
- **Status**: The status of the task, which can be "Pending", "In Progress" or "Completed".
- **Creation Date**: The date and time when the task was created.
- **Completion Date**: The date and time when the task was completed.

### Required functionality:

- **Register Task**: It should be possible to create a new task, filling in all properties except the "*Completion Date*" and the "*Status*" which should start as "*Pending*".
- **View Tasks**: It should be possible to view all registered tasks and also view the details of a specific task.
- **Edit Task**: It should be possible to change the name and description of a task.
- **Delete Task**: It should be possible to remove a task.
- **Mark as Completed**: It should be possible to mark a task as "*Completed*". When marking the task as completed, the "Completion Date" should be updated with the current time.

### Unit Tests:
Write unit tests to validate the use Cases classes. You should cover positive and negative cases, for example trying to edit a task that does not exist.
