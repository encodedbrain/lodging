# Hosting System

- This project is a hosting system that allows you to make a reservation at a hotel. The system is composed of three classes:

- Person: Represents the guest.
- Suite: Represents the hotel suite.
- Reservation: Represents the guest's reservation in the suite.
The system correctly calculates the values of the Reservation class methods, which need to include the number of guests and the daily rate, granting a 10% discount if the reservation is for a period longer than 10 days.

**Requirements**

- C language#
- Database: SQL server

**Installation Instructions**

- Clone the GitHub repository:
```git clone https://github.com/[seu-usuário]/sistema-hospedagem.git ```
- Open the project in Visual Studio.
``` code .```
- add your database connection string to the appsettings.json file | appsettings.development.json
```
Server=myServerAddress;Database=myDataBase;Trusted_Connection=True;
```
- Create a MySQL database with the name hosting.
```
dotnet ef migrations add NameMigrations
```
```
dotnet ef database update
```
- Run the project.
```dotnet run | dotnet watch run```

**how to use**

**To make a reservation, follow these steps:**

- Fill in the fields on the booking form.
- Select the desired suite.
- Click on the "Make reservation" button.
- The system will calculate the reservation value and display a confirmation message.

**Example**

**Below is an example of how to make a reservation:**

```Name: João da Silva
CPF: 123.456.789-00
Entry date: 2023-08-01
Departure date: 2023-08-10
Number of guests: 2
Suite: Luxury
```

**The system will calculate the reservation value as:**

```
Daily price: R$500.00
Discount: R$50.00
Total value: R$ 450.00
License
```
- This project is licensed under the MIT License.
