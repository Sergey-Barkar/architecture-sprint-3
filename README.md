# Smart Home Control System

# Задание 1.1
Текущее монолитное решение представляет собой веб сервис написанный на Java. <br/>
Данный сервис позволяет осуществлять управлять отопительными устройствами по их идентификатору. Идентификация пользователя при управлении устройством не осуществляется, это говорит о том, что существует возможность контроля чужих устройств. <br/>
В качестве хранилища данных использует реляционная база данных - PostgreSQL.<br/>
Диаграмма контекста C4 (все последующие изображения диаграмм содержат гиперссылки на plantUML-файл):<br/>
<p href="Task1_1/context.puml" align="center">
  <img src="Task1_1/context.png" alt="PlantUML" />
</p><br/>

# Задание 1.2
## Диаграмма контейнеров
### Диаграмма целевой архитектуры решения на уровне контейнеров
В качестве способа коммуникации между сервисами используется хореография (только потому, что в рамках предыдущих спринтов использовал оркестрацию).
<p href="Task1_2/Containers/containers.puml" align="center">
  <img src="Task1_2/Containers/containers.png" alt="PlantUML" />
</p><br/>

## Диаграммы компонентов
### Диаграмма целевого состояния компонента ApiGateway
Вся коммуникация с внешним миром осуществляется исключительно через данный сервис.<br/>
<p href="Task1_2/Components/ApiGateway.puml" align="center">
  <img src="Task1_2/Components/ApiGateway.png" alt="PlantUML" width="80%" height="80%"/>
</p><br/>

### Диаграмма целевого состояния компонента SupportedDeviceService
Сервис содержит в себе поддерживаемые устройства.<br/>
<p align="center" href="Task1_2/Components/SDService.puml" >
  <img src="Task1_2/Components/SDService.png" alt="PlantUML" width="40%" height="40%"/>
</p><br/>

### Диаграмма целевого состояния компонента DeviceAutomatizationTemplateService:
Сервис доступных автоматизаций/действий в рамках категорий поддерживаемых устройств.<br/>
<p href="Task1_2/Components/DeviceAutomatizationTemplateService.puml" align="center">
  <img src="Task1_2/Components/DeviceAutomatizationTemplateService.png" alt="PlantUML" width="40%" height="40%"/>
</p><br/>

### Диаграмма целевого состояния компонента UserService:
Сервис аутентификации и авторизации пользователей.<br/>
<p href="Task1_2/Components/UserService.puml" align="center">
  <img src="Task1_2/Components/UserService.png" alt="PlantUML" width="40%" height="40%"/>
</p><br/>

### Диаграмма целевого состояния компонента UserDeviceService:
Сервис поддерживаемых системой зарегистрированных устройств пользователя.<br/>
<p href="Task1_2/Components/UserDeviceService.puml" align="center">
  <img src="Task1_2/Components/UserDeviceService.png" alt="PlantUML" width="40%" height="40%"/>
</p><br/>

### Диаграмма целевого состояния компонента UserDeviceTelemetryService:
Сервис телеметрии устройств пользовтаелей.<br/>
<p href="Task1_2/Components/UserDeviceTelemetryService.puml" align="center">
  <img src="Task1_2/Components/UserDeviceTelemetryService.png" alt="PlantUML" width="40%" height="40%"/>
</p><br/>

### Диаграмма целевого состояния компонента UserAutomatizationService:
Сервис автоматизации событий (автоматических сценариев) настроенных пользователем, соответствующих допустимым для устройств.<br/>
<p href="Task1_2/Components/UserAutomatizationService.puml" align="center">
  <img src="Task1_2/Components/UserAutomatizationService.png" alt="PlantUML" width="40%" height="40%"/>
</p><br/>

### Диаграмма целевого состояния компонента UserCommunicationService:
Сервис коммуникации системы с конечными устройствами.<br/>
<p href="Task1_2/Components/UserDeviceCommunicationService.puml" align="center">
  <img src="Task1_2/Components/UserDeviceCommunicationService.png" alt="PlantUML" width="40%" height="40%"/>
</p><br/>

## Диаграмма кода
### Диаграмма целевого кода сервиса коммуникации
<p href="Task1_2/Code/UserDeviceCommunicationService.puml" align="center">
  <img src="Task1_2/Code/UserDeviceCommunicationService.png" alt="PlantUML" width="40%" height="40%"/>
</p><br/>
