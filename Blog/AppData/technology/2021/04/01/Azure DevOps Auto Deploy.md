# Azure DevOps Auto Deploy

## 環境

1. .net 5 MVC
2. Azure DevOps
3. Azure App Server 免費方案

# 設定 DevOps Pipelines

- Pipelines -> Pipelines -> Create Pipelines
  ![CreatePipeline](./AzureDevOpsAutoDeployImage/CreatePipeline.jpg)
- 選擇放 Code 的地方，這邊是示範 Code 放在 Azure DevOps 裡，所以選擇 Azure Repos Git
  ![ChooseGit](./AzureDevOpsAutoDeployImage/ChooseGit.jpg)

- 選擇專案
  ![SelectProject](./AzureDevOpsAutoDeployImage/SelectProject.jpg)

- 選擇專案架構，這邊事先準備好的專案是.net 5 的，所以選擇 ASP.NET Core(.Net Framework)
  ![ChooseFramework](./AzureDevOpsAutoDeployImage/ChooseFramework.jpg)

  ![ShowAssistant](./AzureDevOpsAutoDeployImage/ShowAssistant.jpg)

- 產出預設的 YAML 後，要多新增一個步驟 -> Publish build artifact
  ![PublishBuildArtifact](./AzureDevOpsAutoDeployImage/PublishBuildArtifact.jpg)

  ![AddPBA](./AzureDevOpsAutoDeployImage/AddPBA.jpg)

- 執行產生好的 YAML
  ![SaveAnrRunPipeline](./AzureDevOpsAutoDeployImage/SaveAnrRunPipeline.jpg)

  ![CommitAndRun](./AzureDevOpsAutoDeployImage/CommitAndRun.jpg)

- 等個一段時間，讓 Pipeline 跑完
  ![PipelineRunSuccess](./AzureDevOpsAutoDeployImage/PipelineRunSuccess.jpg)

  ![PipelineRunSuccess](./AzureDevOpsAutoDeployImage/PipelineRunSuccess.jpg)

## 設定 Releases

- Pipeline -> Releases -> New pipeline
  ![NewReleases](./AzureDevOpsAutoDeployImage/NewReleases.jpg)

- 選擇服務的 Template
  ![ApplyAppServiceTemplate](./AzureDevOpsAutoDeployImage/ApplyAppServiceTemplate.jpg)

- 選剛剛架好的 Pipeline
  ![AddArtifact](./AzureDevOpsAutoDeployImage/AddArtifact.jpg)

- 選擇資源群組(這邊先示範同一個帳號內的)
  ![EditTasks](./AzureDevOpsAutoDeployImage/EditTasks.jpg)
  ![SaveTasks](./AzureDevOpsAutoDeployImage/SaveTasks.jpg)

- 建立 Release
  ![CreateRelease](./AzureDevOpsAutoDeployImage/CreateRelease.jpg)
  ![CreateRelease1](./AzureDevOpsAutoDeployImage/CreateRelease1.jpg)

- Release 建立中
  ![DoingRelease](./AzureDevOpsAutoDeployImage/DoingRelease.jpg

- 建立成功
  ![ReleaseSuccess](./AzureDevOpsAutoDeployImage/ReleaseSuccess.jpg)
  ![ReleaseDetail](./AzureDevOpsAutoDeployImage/ReleaseDetail.jpg)

- Hello World !
  ![Done](./AzureDevOpsAutoDeployImage/Done.jpg)
