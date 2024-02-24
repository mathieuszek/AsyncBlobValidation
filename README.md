# Goals :soccer:

1. Create `Azure Function`:
   - Trigger: `Azure Storage Queue`,
   - Functionality: `This function will be triggered by new messages in a specified Azure Storage Queue. Each message will contain a valid JSON object. Your task is to validate the JSON data and store it as a new file in an Azure Blob Storage container. The file path within the Blob Storage should follow the pattern: year/month/day/hour/minute/{guid}.json`,
   - Configuration: `The names of the Azure Storage Queue and Blob Storage container should be  configurable and retrieved from the application's settings`,

2. Create `Azure Function`:
   - Trigger: `HTTP GET request`,
   - Functionality: ` This function will respond to HTTP GET requests by returning a list of all files  currently stored in the specified Blob Storage container. The response format should be a JSON array containing the names or paths of the files`,

## Getting started

Before first run ensure that you have installed following tools:

1. [.NET SDK](https://dotnet.microsoft.com/en-us/download) - please use [global.json](./global.json) to download correct version,
2. [Azurite](https://learn.microsoft.com/en-us/azure/storage/common/storage-use-azurite?tabs=docker-hub%2Cblob-storage#install-azurite) - depends on your preferences use which you want to (I will use `Azurite` as container),
3. [Azure Functions Core Tools](https://learn.microsoft.com/en-us/azure/azure-functions/create-first-function-cli-csharp?tabs=windows%2Cazure-cli#install-the-azure-functions-core-tools),

## Optional

- `Podman` or `Docker` to run `Azurite` as container,
