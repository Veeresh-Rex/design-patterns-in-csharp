# Chain of Responsibility Pattern

## Intent
Avoid coupling the sender of a request to its receiver by giving more than one object a chance to handle the request. Chain the receiving objects and pass the request along the chain until an object handles it.

## When to Use
- When more than one object may handle a request, and the handler isn't known a priori.
- When you want to issue a request to one of several objects without specifying the receiver explicitly.
- When the set of objects that can handle a request should be specified dynamically.
- Examples: HTTP request middleware pipelines (authentication, authorization, logging, rate-limiting), event propagation in GUI frameworks.

## Implementation details in this lab
- **Handler Interface:** `IRequestHandler` defines `SetHandler(IRequestHandler)` to chain handlers sequentially and `Handle(HttpRequest)` to process requests.
- **Concrete Handlers:**
  - `AuthenticationHandler`: Validates `ApiKey` on the request and populates the `User` context upon success.
  - `AuthoriztionHandler`: Verifies user authorization before passing execution down the chain.
  - `RateLimitHandler`: Checks daily request count against a maximum threshold (`MaxRequestCount = 5`) to prevent rate-limit violations.
  - `BusinessLogicHandler`: The terminal handler that executes the core request processing logic once all checks succeed.
- **Request Context:** `HttpRequest` acts as a data context (`ApiKey`, `User`, `RequestCountPerDay`) mutated and validated progressively across the handler chain.

## Output Trace
```
Authenticated successfully
User is Authrozied
Executing business logic
Authenticated successfully
User is Authrozied
Executing business logic
Authenticated successfully
User is Authrozied
Executing business logic
Authenticated successfully
User is Authrozied
Executing business logic
Authenticated successfully
User is Authrozied
Executing business logic
Authenticated successfully
User is Authrozied
User API call limit reach
```
