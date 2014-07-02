RWWA-Article 5
=============

Real World Windows Azure: In die Cloud loggen http://rolandkru.azurewebsites.net/rwwa/


This is a sample application I wrote for the "Real World Windows Azure"-Series in the Windows Developer Magazine.

Installation:
-------------
1. Create a windows azure subscription. See: http://www.windowsazure.com/de-de/pricing/free-trial/
2. Create a windows azure storage account. See: http://www.windowsazure.com/en-us/documentation/articles/storage-create-storage-account/
3. Copy the account name and account key from the management portal and enter it in the app.config files of the "AzureStorageFileSyncTool" and the "DemoConsoleApp" project (look for [Enter Storage Account Name] and [Enter Storage Account Key])
4. Compile
5. Run the DemoConsoleApp project. Now, on your storage account a blob container, a queue and a table, each named "clientlogs", gets created and filled with log informations from the client app.