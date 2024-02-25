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

## Local Development

To use application locally you need to create `local.settings.json` file in `src/File.Service` directory with following data:

```json
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
    "InputMessageQueue": "<input-message-queue>",
    "BlobStorage:ItemsContainerName": "items"
  },
  "ConnectionStrings": {
    "DefaultBlob": "<storage-connection-string>"
  }
}

```

To do so you need to prepare your environment by:

1. Run `Azurite` i.e.:
   ```powershell
   docker run -p 10000:10000 -p 10001:10001 -p 10002:10002 mcr.microsoft.com/azure-storage/azurite
   ```

2. Open `Microsoft Azure Storage Explorer`.

3. Go to `Emulator & Attached` > `Storage Accounts` > `(Emulator - Default Ports)`
   - go to `Properties` section, copy `Primary Connection String` and replace `<storage-connection-string>` value in `local.settings.json` by copied value,
   - expand `Queues` and create new one and use the new queue name to replace `<input-message-queue>` value in `local.settings.json`,

Then you should be able to run the project :D

## Contributing

Best practices:
1. Please use [http](/http/) directory to store every possible `Azure Functions` within solution. To do so you need to have [REST Client](https://github.com/Huachao/vscode-restclient) installed.
2. The was used `Vertical Slice Architecture` which provides better granularity for features: https://www.jimmybogard.com/vertical-slice-architecture/.

## Testing

### Unit Tests

To run unit tests just run:
```powershell
dotnet tests .\tests\UnitTests\UnitTests.csproj
```

### Functional Tests

### Preparation

1. Start project.

#### Uploading File

1. Happy path :smile::
   1. Go to `Emulator & Attached` > `Storage Accounts` > `(Emulator - Default Ports)` > `Queues`,
   2. Open your queue.
   3. Add valid message: `{ "description": "Text" }`
   4. In `Storage Explorer` open `Blob Containers` > `items` and verify if new blob was created.

2. Sad path :frowning::
   1. Go to `Emulator & Attached` > `Storage Accounts` > `(Emulator - Default Ports)` > `Queues`,
   2. Open your queue.
   3. Add valid message: `{ "description": "" }` (because description cannot be empty)
   4. You should see `Warning` printed in log console and no new blob should be created.

#### List Uploaded Blobs

1. Go to `Emulator & Attached` > `Storage Accounts` > `(Emulator - Default Ports)` > `Queues`,
2. Open your `Blob Containers` > `items`.
3. Verify the amount and names of the messages.
4. Send request from [list-item-storages.http](/http/items/list-item-storages.http) or just click: http://localhost:7071/api/ListItemStoragesHttpFunction
