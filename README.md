# Приложение: План приема лекарств #
# TASK 1 #
> Требования к задаче
1. Реагистрация. <br/>
  1.1. Для пациента нужно указать следующее:
    - ФИО;
    - телефон;
    - почта;
    - снилс;
    - полис.<br/>
  1.2. Для врача: 
    - ФИО;
    - телефон;
    - почта;
    - снилс;
    - полис;
    - уникальный код врача, который, например, выдается минздравом(дабы не было лже врачей);
    - Название университета;
    - Дата начала и конца обучения в университете;
    - Специальность;
    - Стаж работы.<br/>
2. Необходим вход в аккаунт. <br/>
  2.1 Для пациента\врача:
    - Логин - номер телефона\почта;
    - пароль.<br/>
3. Работа с приложением: <br/>
  3.1 Для пациента:
    - Пациент может открывать запись с приемом лекарства, назначенную врачом, где будет указано следующее:
    - дата и время начала;
    - дата и время конца;
    - интервал приема;
    - название лекартсва;
    - рекомандации по приему(или что-то еще, что напишет доктор). <br/> 
  3.2 Для врача:<br/>
    Перед врачом появляются пациенты, где он выбирает нужного и в дальнейшем работает с ним.
    - Назначение лекарств (т.е добавление их):
      + дата и время начала;
      + дата и время конца;
      + интервал приема;
      + краткая рекомендация к приему лекарства.
    - Редактирование записей (например, спустя месяц курса, нужно изменить дозировку лекарства);
    - Удаление записей (например, препарат назначенный врачом стал негативно действовать на пациента).

# TASK 2 #

>Модель базы данных:

![image](https://user-images.githubusercontent.com/103942325/197052192-b7c142cd-703c-46fd-b112-5a8295ad1ba0.png)

