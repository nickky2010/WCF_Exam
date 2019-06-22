# WCF exam assignment

***

#### Написать приложение, реализующее запись студентов на курс ООП.

Для этого создать WCF-сервис в виде библиотеки классов с дуплексным контрактом.  Контракт службы должен содержать:

* операцию добавления информации о студенте (фамилию, оценку по основам алгоритмизации) в текстовый файл, который располагается по месту размещения службы (в операцию передавать через параметр объект класса Student;
* операцию определения есть ли среди записавшихся на курс заданный студент;
* операцию обратного вызова, которая отображает список записавшихся студентов, средний балл которых выше балла текущего клиента.

***

#### Создать консольный проект для хостинга созданной службы. Добавить конечные точки в программе.
#### Создать клиентское приложение WinForms, которое позволяет пользователю записаться на курс ООП, используя соответствующую операцию сервиса, узнать, записан ли уже на курс указанный студент, а  также отображает список записавшихся на курс студентов с баллом выше балла пользователя при каждой записи нового студента. 

Предусмотреть асинхронный вызов операции обратного вызова, используя асинхронную модель на основе задач. 

Предусмотреть трассировку сообщений.
