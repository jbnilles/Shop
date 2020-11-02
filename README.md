# Shop


## About / Synopsis

* This project tracks a shops treats and flavors keeping track of which treats are linked to which flavors and vice versa.
* This project was created following Epicodus' Authentication Project's requirments.
* Project status: working
* Created by: Joseph Nilles 10/23/20



## Table of contents


> * [Shop](#shop)
>   * [About / Synopsis](#about--synopsis)
>   * [Table of contents](#table-of-contents)
>   * [Setup](#setup)
>   * [Usage](#usage)
>     * [Features](#features)
>   * [Code](#code)
>     * [Bugs](#bugs)
>     * [To Do](#to-do)
>   * [Resources (Documentation and other links)](#resources-documentation-and-other-links)
>   * [Contact](#contact)
>   * [License](#license)


## Setup

* Clone the project from the repository at https://github.com/jbnilles/Shop
* Navigate to the project file and then into the folder `Shop`
* Create a file called `appsettings.json`
* In the `appsettings.json` file add the following
```json
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=joseph_nilles;uid=root;pwd=YOUR_PASSWORD;"
  }
}
```
* Replace `YOUR_PASSWORD` with you MySQL password
* Open a terminal and navigate to the `Shop` folder inside the project 
* In the terminal run `dotnet ef database update`
* In the terminal run `dotnet run`
* Open a web browser and go to http://localhost:5000/ 




## Usage
* When using this project you are allowed to view the flavors and treats pages and details pages at any time. However to modify (edit/delete or add ) you must be logged in to any account. You are freely able to register an account, with a userneame email and password. And login to the account with username and password.




### Features
* When logged in
  * Add/Edit/Delete/View Treats
  * Add/Edit/Delete/View Flavors
  * Add/Edit/Delete/View Links between Flavors and Treats)
* When not logged in
  * View Flavors
  * View Treats

## Code

### Bugs

* No known bugs

### To Do

  - [ ] Add Roles to authorization
  - [ ] Add ability to edit the user's account
  - [ ] Add add administrator to control user accounts


## Resources (Documentation and other links)

* https://ondras.zarovi.cz/sql/demo/?keyword=default
  * used for creating DB Table Layout Github: https://github.com/ondras/wwwsqldesigner


## Contact

To contact author 
  * Email Joseph Nilles at jbnilles24@gmail.com
  * Github : github.com/jbnilles

## License

This project is licensed using MIT License

