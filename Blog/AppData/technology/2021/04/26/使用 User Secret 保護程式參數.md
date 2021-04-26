## 環境

- Visual Studio 2019 Community
- .net 5

## 用途

- 避免開發階段不小心把 連線字串 還有一些 Config 的小秘密公諸於世

## 設定

在使用前要先注意一下環境變數是不是 Development (開發環境)

![environment](.\UserSecretImg\environment.jpg)
![environment2](.\UserSecretImg\environment2.jpg)

這個設定會存在 launchSettings.json

![launchSetting](.\UserSecretImg\launchSetting.jpg)

對專案點 管理使用者密碼 (Manage User Secrets)

![ManageUserSecrets](.\UserSecretImg\ManageUserSecrets.jpg)

產生 secrets.json

路徑會根據作業系統不同

- Windows : `%APPDATA%\microsoft\UserSecrets\<userSecretsId>\secrets.json`
- Linux : `~/.microsoft/usersecrets/<userSecretsId>/secrets.json`
- Mac : `~/.microsoft/usersecrets/<userSecretsId>/secrets.json`
  ![secretsjson](.\UserSecretImg\secretsjson.jpg)

userSecretsId 會是隨機產生的

如果不同開發者要在同一個專案用同樣的 User Secrets 就要把整個 `<userSecretsId>` 資料夾複製過去

![UserSecretsdir](.\UserSecretImg\UserSecretsdir.jpg)

原始碼中的 `userSecretsId` 會記錄在 `.csproj`中

![UserSecretIdInCsproj](.\UserSecretImg\UserSecretIdInCsproj.jpg)

設定後兩個檔案應該要像這樣

![AfterSetting](.\UserSecretImg\AfterSetting.jpg)
