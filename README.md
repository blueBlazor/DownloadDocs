Goal: Create a class library that can be used in different software projects.

Description:

The project uses a layered structure:

Layer 1: API
Executes the action and receives data from the frontend. Creates a Request<T> for the handler and determines the response. Returns an HttpCode.

Layer 2: HandlerDispatch
Selects the correct handler based on the given request and response. If the combination does not exist, no handler will be found.

Layer 3: Handler
Contains the required services as predefined properties and executes their functions. Based on the results, it returns a Response<T>, which can be Success or Failure.

Layer 4: Services
Handles the business logic, including rules, calculations, validations and workflows. Services receive the required parameters and return a Result<T>.

HTML Manual:
The project includes two HTML manual templates in the "manual" folder, one in English and one in Dutch. Both have the same structure but use different object-specific names. Based on the given parameters, the system selects the correct file, fills it with the provided values and exports it.

Project result:
Experimenting with the layered system and working with Response<T> and Result<T>. The goal is to reduce exceptions and only use them for critical situations, such as database connection failures or tokens that cannot be renewed.

Extensions:

Excel export function.

Word export function.

StreamReader and StreamWriter.

Text file export function.

CSV export function.

Plan after extensions:

Create event handlers to communicate with other class libraries (microservices).
