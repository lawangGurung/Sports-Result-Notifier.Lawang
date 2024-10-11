
# Sports-Notifier.Lawang

This application harverst the sports result data from the non-api source "https://www.basketball-reference.com/boxscores/", and sends the data result to specific e-mail address.
## Features
- Users don't need any interaction with the program. It is a service that runs automatically.
- It uses BackgroundService class to send the mail once every 24hr and user can exit the program by pressing Ctrl + c.
- This app uses HtmlAgility Pack to scrape the data.







## Deployment

To deploy this project Create .env file and inside .env file replace "YOUR_EMAIL" with your e-mail and "YOUR_PASSWORD" with your app password.

- `SenderEmail=YOUR_EMAIL`
- `Password=YOUR_PASSWORD`

## Testing

For testing Purposes user can change the value present inside the NotifyBackgroundSevice class.

- [image]

- Change the "_timeSpan" value to  (`private TimeSpan _timeSpan = TimeSpan.FromSeconds(10)`)  so that the program could send email every 10 seconds instead of once every 24 hour 

- [image]
- You can change the value to the specific date for which you want the basketball result.

 ## Screen shots:



* ![App Screenshot]

- Data is sent to user in the above format via gmail server.



## Project Summary
#### What challenges did you face and how did you overcome them?

* This was the first time that I had worked with the HtmlAgilityPack to scrape the data, but with the resources provided it was quite easy.





## 🛠 Skills Learned
#### BackgroundService 
- I utilised the BackgroundService class to send the e-mail once every day, which exposed me to cancellation token and how it can benifit the program to have the cancellation token.

## Feedback

If you have any feedback, please reach out to us at depeshgurung44@gmail.com

