# Goals :soccer:

1. Create `Azure Function`:
   - Trigger: `Azure Storage Queue`,
   - Functionality: `This function will be triggered by new messages in a specified Azure Storage Queue. Each message will contain a valid JSON object. Your task is to validate the JSON data and store it as a new file in an Azure Blob Storage container. The file path within the Blob Storage should follow the pattern: year/month/day/hour/minute/{guid}.json`,
   - Configuration: `The names of the Azure Storage Queue and Blob Storage container should be  configurable and retrieved from the application's settings`,

2. Create `Azure Function`:
   - Trigger: `HTTP GET request`,
   - Functionality: ` This function will respond to HTTP GET requests by returning a list of all files  currently stored in the specified Blob Storage container. The response format should be a JSON array containing the names or paths of the files`,
