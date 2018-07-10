Shopping cart infrastructure

GUI


1. App consist three pages Main page, Good page, Cart page
2. On Main page placed such blocks: 
	1. Layout 
	2. Filter block
	 - implemented as checkboxes. After checking item, list of goods changing according to filter 
	
	3. List of goods
	 - Contain links on Good's page and adding good to cart
	4. Link on Cart

3. Good page contain:
	Row with one good. Row contain link for adding good to the cart.

4. Cart page:

	- list of goods with group by Name for count and sum.
	- every row contain delete link for deleting good from cart
	- there is a red button that clear all cart

5. Database
  - used SQLite file 
  - added two tables Cars and Cart
  - file located in App_data folder, also in Debug folder inside Unit test(SerenataflowersTestTest) application
	
Visual studio

1. For develop the task I have choosen ASP.NET MVC.
2. Created empty built-in MVC API project
3. Add two model classes Good and Cart 
4. Also in Models folder created class GoodsContext for connect to SQLite data file. Firstly I was planning use this class as DB context, but met problem with connector and leave this class in Models.
5. For implement API I added API controllers (one was as template) ValuesController and CartApiController.
6. Also added controllers for views HomeController, CartController, GoodController. There only action which need for show view.
7. Main actions has written in views using Jquery

Main page view

When project runs  $(document).ready(function ()) runs functions GetManufacturers() for getting data for Filter block and GetAllGoods() for filling table with goods.
All functions use Ajax queries for passing params in api controllers and running functions when succes.

Filter block 
On each checkbox hanged function GetAllGoods(). This function check all "Checked" checkboxes and makes string for sql query filter, uses Name column.

Good list block
Each column Name has link on the Good page. Also link with function AddToCart() for adding good in the Cart. Function passes Id and calls Action CreateItem in API controller.

Go on Cart - link on Cart page


Good view
Good's Id passes from Main view and uses with help ViewBag. When page loads, runs function GetGood(id). Placement of list on page same as on Main view, but here only one row.
Row contains link on function AddToCart().

Cart view
When view loads, runs function GetCart() which run Action in API for runnig sql query which gets data from Cart table.
Also view has functions DeleteItem() for deletting single row and ClearCart() for clear table Cart.



Unit test
For test app uses buil-in MStest. I added Class Library SerenataflowersTestTests.
Main methods locate in GoodContext class and I did test only for methods in this class.  







