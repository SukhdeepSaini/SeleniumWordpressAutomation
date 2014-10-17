Instructions:

Started developing Test Automation Framework for Wordpress, the famous blogging engine. I have developed the basic framework to start with, it includes some smoke tests and other tests .

Please see below the details:

Framework:

I have created the required classes for login , creating posts , pages , navigation and checking data(Assertions).

PSB the details:

Utilities : Class for initialization and cleanup 

Navigation : LeftNavigation class is used for navigation across the CMS using the left navigation menu . It Can be used for navigation to pages and posts.

Pages: Contains classes for Dashboard, login , PostPage , ListPostPage and NewPostPage.

Driver : Class for web driver initialization , navigation and waiting logic.

=======================================================================================

Wordpress Tests:

1) Smoke Tests:
  a) LoginTests
  b) Create Posts Tests
  c) Page Tests

2) All Posts Tests

Feel free to add more tests and explore the framework. 






