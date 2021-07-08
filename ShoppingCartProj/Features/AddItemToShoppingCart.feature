Feature: AddItemToShoppingCart
	Select items from the list and add into shopping cart

@mytag
Scenario: Add item from Best sellers list
	When I select "BEST SELLERS" list
	And I select "Blouse" from the list
	Then the details of the item "Blouse" is displayed
	When I add the item with following details
	| Quantity | Size | Color |
	| 2        | M    | White |
	Then item "Blouse" is added to the cart