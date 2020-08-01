Instructions:-
1. Open Solution in Visual Studio.
2. Create Db or use existing Db and Update Database connection string in Web.config file.
3. Code first approach data migration steps:-
	Please Run below commands in Package Manager Console.
	1.Enable-Migrations  
	2.add-migration InitialCreate  
	3.update-database
4. Run the application.

Note- Incase of deploying application locally as the port number might differ.Please update port no in BasePath of ContactsPage Controller.

Functionality:-
- List contacts
- Add a contact
- Edit contact
- Delete/Inactivate a contact

Features:-
1. Data Annotations -
	-Email validation.
	-Required All field.
	-Phone No should be in digits and 10 Min & Max digits are allowed
2. Dropdown for Status possible values are 'Active' and 'InActive'.
3. rest Api functionallity:-
	- Action to Get All contacts.
	- Action to Add new contact.
	- Action to update contact.
	- Action to delete contact.
	- Action to InActivate contact.

Folder structure:-
-Controllers:-Contains rest api and Contacts page controller
-Models:- Contains Contact Model class.
-App_Start:- Contains web page route config and web api route config.
-Views:- Contains views of the controller.
-Repository- Contains db context class file.
-Migrations- Contains the migration details of db.
