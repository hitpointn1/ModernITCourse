# ModernITCourse
## Задания к спецкурсу Интернет-технологии

### Инструменты:
Платформа: .NET 5

Веб-фреймворк: ASP.NET Core

База Данных: SQLITE 3

ORM: Entity Framework Core

* [Скрипт](./ModernITCourse.DataAccessLayer/Sql/Universities.sql), вставлющий значения для выполения заданий (поехала кодировка при пуше на гит, сам скрипт в порядке).
* [Код генерации студентов](ModernITCourse.Services/InitService.cs).


### Лабораторная работа №8 (Вариант 13)
13) Получить список университетов, расположенных в Москве и имеющих рейтинг меньший, чем у ВГУ. Константу в ограничении на рейтинг
можно определить по этой же таблице.

- Изменил на больший, так как в базе из методички у всех больше.

Результат:

![Задача 8](/docs/task8.png)


### Лабораторная работа №9 (Вариант 13)
13. Получить список университетов, в которых учится более 15 студентов, отсортировать его по рейтингам.

- Изменил на 15, нет смысла генерировать больше студентов.

Результат:

![Задача 9](/docs/task9.png)
