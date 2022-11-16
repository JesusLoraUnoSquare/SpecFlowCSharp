Feature: Shopping cart
		shopping cart functionality test
		An item is searched for and added to the shopping cart

	Background: 
	Given I open the web page

@mytag
Scenario Outline: shopping cart functionality
	When I go to Amazon.com
    And Search for <product>
    Then Verify Item is displayed on the screen and  locate the first one and store the price
    And Click on the First Result
    And Once in the details page compare this price vs the above one (first stored price)
    Then Click on Add to Cart.
    When Go to Cart and verify again the price of the phone
    Then Delete Item
	And I close the web navigator

	Examples: 
	| product            |
	| Iphone 14          |
	| Samsung Galaxy S22 |
	| Google pixel       |
