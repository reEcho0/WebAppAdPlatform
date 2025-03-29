## Задача. Рекламные площадки.  (C#)
если вы работаете на windows [установитье GitBash](https://gitforwindows.org/) 
1. клонируйте репозиторий
```https://github.com/reEcho0/WebAppAdPlatform.git```
2. откройте косноль работающую с Bash
3. напишите следующие команды  
- POST-запрос с рекламными площадками  
```curl -X POST http://localhost:5000/api/adplatforms/load --data-binary @platforms.txt -H "Content-Type: text/plain"```  
- GET-запрос на получение подходящих площадок под ваш регион  
```curl http://localhost:5000/api/adplatforms/search?location=/ru/svrd/revda```

## Содержимое файла platforms.txt
Яндекс.Директ:/ru  
Ревдинский рабочий:/ru/svrd/revda,/ru/svrd/pervik  
Газета уральских москвичей:/ru/msk,/ru/permobl,/ru/chelobl  
Крутая реклама:/ru/svrd
