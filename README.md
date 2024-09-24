<h1>Smart Home Control System</h1>
<h1>Задание 1.1</h1>
Текущее монолитное решение представляет собой веб сервис написанный на Java. <br/>
Данный сервис позволяет осуществлять управлять отопительными устройствами по их идентификатору. Идентификация пользователя при управлении устройством не осуществляется, это говорит о том, что существует возможность контроля чужих устройств. <br/>
В качестве хранилища данных использует реляционная база данных - PostgreSQL.<br/>
Диаграмма контекста C4 (все последующие изображения диаграмм содержат гиперссылки на plantUML-файл):<br/>
<p href="Task1_1/context.puml" align="center">
  <img src="Task1_1/context.png" alt="PlantUML" />
</p><br/>

# Задание 1.2
По причине объёмов информации данного задания - реализация, по умолчанию, свёрнута.

<details><summary><h2>Диаграмма контейнеров</h2></summary><br/>
<h3>Диаграмма целевой архитектуры решения на уровне контейнеров</h3><br/>
В качестве способа коммуникации между сервисами используется хореография (только потому, что в рамках предыдущих спринтов использовал оркестрацию).
<p href="Task1_2/Containers/containers.puml" align="center">
  <img src="Task1_2/Containers/containers.png" alt="PlantUML" />
</p><br/>
</details><br/>
<hr>
<details><summary><h2>Диаграммы компонентов</h2></summary>
<h3>Диаграмма целевого состояния компонента ApiGateway</h3><br/>
Вся коммуникация с внешним миром осуществляется исключительно через данный сервис.<br/>
<p href="Task1_2/Components/ApiGateway.puml" align="center">
  <img src="Task1_2/Components/ApiGateway.png" alt="PlantUML" width="80%" height="80%"/>
</p><br/>

<h3>Диаграмма целевого состояния компонента SupportedDeviceService</h3><br/>
Сервис содержит в себе поддерживаемые устройства.<br/>
<p align="center" href="Task1_2/Components/SDService.puml" >
  <img src="Task1_2/Components/SDService.png" alt="PlantUML" width="40%" height="40%"/>
</p><br/>

<h3>Диаграмма целевого состояния компонента DeviceAutomatizationTemplateService</h3><br/>
Сервис доступных автоматизаций/действий в рамках категорий поддерживаемых устройств.<br/>
<p href="Task1_2/Components/DeviceAutomatizationTemplateService.puml" align="center">
  <img src="Task1_2/Components/DeviceAutomatizationTemplateService.png" alt="PlantUML" width="40%" height="40%"/>
</p><br/>

<h3>Диаграмма целевого состояния компонента UserService</h3><br/>
Сервис аутентификации и авторизации пользователей.<br/>
<p href="Task1_2/Components/UserService.puml" align="center">
  <img src="Task1_2/Components/UserService.png" alt="PlantUML" width="40%" height="40%"/>
</p><br/>

<h3>Диаграмма целевого состояния компонента UserDeviceService</h3><br/>
Сервис поддерживаемых системой зарегистрированных устройств пользователя.<br/>
<p href="Task1_2/Components/UserDeviceService.puml" align="center">
  <img src="Task1_2/Components/UserDeviceService.png" alt="PlantUML" width="40%" height="40%"/>
</p><br/>

<h3>Диаграмма целевого состояния компонента UserDeviceTelemetryService</h3><br/>
Сервис телеметрии устройств пользовтаелей.<br/>
<p href="Task1_2/Components/UserDeviceTelemetryService.puml" align="center">
  <img src="Task1_2/Components/UserDeviceTelemetryService.png" alt="PlantUML" width="40%" height="40%"/>
</p><br/>

<h3>Диаграмма целевого состояния компонента UserAutomatizationService</h3><br/>
Сервис автоматизации событий (автоматических сценариев) настроенных пользователем, соответствующих допустимым для устройств.<br/>
<p href="Task1_2/Components/UserAutomatizationService.puml" align="center">
  <img src="Task1_2/Components/UserAutomatizationService.png" alt="PlantUML" width="40%" height="40%"/>
</p><br/>

<h3>Диаграмма целевого состояния компонента UserCommunicationService</h3><br/>
Сервис коммуникации системы с конечными устройствами.<br/>
<p href="Task1_2/Components/UserDeviceCommunicationService.puml" align="center">
  <img src="Task1_2/Components/UserDeviceCommunicationService.png" alt="PlantUML" width="40%" height="40%"/>
</p><br/>
</details><br/>
<hr>
<details><summary><h2>Диаграмма кода</h2></summary><br/>
<h3>Диаграмма целевого кода сервиса коммуникации</h3><br/>
Весь трафик во вне проходит через Apigateway.<br/>
<p href="Task1_2/Code/DeviceCommunicationService.puml" align="center">
  <img src="Task1_2/Code/DeviceCommunicationService.png" alt="PlantUML" width="100%" height="100%"/>
</p><br/>
</details><br/>

<h1>Задание 1.3</h1><br/>
ER диаграмма<br/>
<p href="Task1_3/ER.puml" align="center">
  <img src="Task1_3/ER.png" alt="PlantUML" width="100%" height="100%"/>
</p><br/>

<h1>Задание 1.4</h1><br/>
Для взаимодействия между микросервисами используется RestApi.<br/>
Ссылка на Swagger: <a href="Task1_4/swagger.yml">Task1_4/swagger.yml</a>.<br/>

<h1>Задание 2.1</h1><br/>
Деплой осуществляется командой "docker compose up -d"<br/>
Для проверки через swagger сконфигурируйте keycloak:<br/>
1. Дождитесь старта keycloak;<br/>
2. Зайдите в админку. Порт 18080. Логин admin, пароль аналогичный;<br/>
3. Создайте рилм "shsmvp";<br/>
4. Создайте юзера, либо в параметрах рилма включите флаг отвечающий за взможность регистрации;<br/>
5. Создайте клиент для данного рилма.<br/>В пункте "Valid redirect URIs" укажите любые пути от сервисов телемитрии и устройств пользователя (http://localhost:8080/* и http://localhost:8081/*).<br/>В пункте  укажите URL'ы сервисов телемитрии и устройств пользователя (http://localhost:8080 и http://localhost:8081).<br/>
Включите Implicit flow в аутентификации данного клиента. <br/>

Swagger поднят для сервисов.
http://localhost:8080/swagger/index.html - устройства пользователя
http://localhost:8081/swagger/index.html - телеметрия
При работе функции action сервиса устройств в кафку записывается сообщение-"рыба", сервис телеметрии подписан на данные сообщения.<br/>
