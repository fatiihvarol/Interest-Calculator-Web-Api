# .NET Core In-Memory Database Learning Project

The Interest Calculator project is designed to provide a simple and efficient way to calculate compound interest and basic interests for various financial scenarios. The project utilizes the MediatR library for handling CQRS (Command Query Responsibility Segregation) patterns to process interest calculation queries.

## Project Structure

- **Models:** Contains classes representing the application's data model.
- **Api Responses** Includes classes responsible for defining standardized API response formats.
- **Validators:** Contains classes used for data validation processes.
- **MediatR** Includes classes that utilize the MediatR library to organize communication within the application. This encompasses handler classes responsible for processing requests and generating results.
- **Cqrs** Integrates Command Query Responsibility Segregation (CQRS) principles, separating command and query operations, often in conjunction with MediatR for better organization and scalability.

## Technologies Used

- **Entity Framework Core:** Employed for operations, facilitating a mapping between model classes and relevant entities.
- **Fluent Validation Library:** Used for data validation processes, validating user inputs and managing appropriate errors.
- **MediatR** Includes classes that utilize the MediatR library to organize communication within the application. This involves handler classes responsible for processing requests and generating results.

## Getting Started
1. **Clone Project**
    ```bash
    git clone https://github.com/300-Akbank-Net-Bootcamp/aw-4-fatiihvarol.git
    ```

2. **Install Dependencies:** Navigate to the project folder in the terminal or command prompt and use the `dotnet restore` command to install dependencies.

    ```bash
    dotnet restore
    ```

3. **Run the Application:** Start the application using the following command.

    ```bash
    dotnet watch run
    ```

After following these steps, the application should start and perform basic operations using the in-memory database.


## Screenshots

- **Swing Page** 
##
 ![](https://i.hizliresim.com/m9e1drz.png)
 ##


 - **Basic Interest Request**
 ##
 ![](https://i.hizliresim.com/27mx5nr.png)
 ##
  - **Basic Interest Response**
  ##
 ![](https://i.hizliresim.com/cz9hyxd.png)
##

  - **Compunt Interest Request**
  ##
 ![](https://i.hizliresim.com/fk11cnu.png)
 ##
  - **Compunt Interest Response**
  ##
 ![](https://i.hizliresim.com/cis4vi4.png)
 ##
 ##
 ##



# API Using

## Calculate the basic interest
#### Endpoint
```http
https://localhost:7096/api/BasicInterests
```
#### Request Body
```bash
{
  "principal": 1000,
  "interestRate": 0.1,
  "maturity": 1,
  "interestFrequency": "yıl"
}
```

#### Response

```bash
{
  "serverDate": "2024-01-15T20:55:25.6710109Z",
  "referenceNo": "f1188efa-6b15-4e51-be89-8caedd4c0ba4",
  "success": true,
  "message": "Success",
  "response": {
    "interestIncome": 100,
    "totalBalance": 1100
  }
}
```


## Calculate the Compount Interest
#### Endpoint
```http
https://localhost:7096/api/CompoundInterest
```
#### Request Body 
```bash
{
  "Principal": 100000,
  "InterestRate": 10,
  "Maturity": 3,
  "InterestFrequency": "yıl"
}
```

#### Response

```bash
{
  "serverDate": "2024-01-15T21:37:35.0808274Z",
  "referenceNo": "2c54d7c4-2d0d-44ed-9835-6a083f299bad",
  "success": true,
  "message": "Success",
  "response": {
    "interestIncome": 33100,
    "totalBalance": 133100
  }
}
```

  