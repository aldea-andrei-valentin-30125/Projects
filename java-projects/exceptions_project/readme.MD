Implement a safe home access Java application based on the diagram above. Consider following functional requirements in implementing your program:

- 1.If pin is wrong enterPin method shall throw an InvalidPinException.
- 2.If 3 consecutive attempts are made to enter pin then door is locked(until master key pin is used) and enterPin method shall throw TooManyAttemptsException. Any further invocations of enterPin method will throw TooManyAttemptsException.
- 3.If master key pin is used, door will be unlocked and retries count will be reset to 0.
- 4.If pin is correct, door shall be opened or closed depending on current state (if open will be closed, if closed will be opened)
- 5.When tenant already exists by name, addTenant method will throw TenantAlreadyExistsException.
- 6.When tenant not found, removeTenant method will throw TenantNotFoundException.
- 7.All attempts (successful or not) will be logged in access log list.