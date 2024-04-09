using System;

// Abstract base class representing common attributes and behavior for social media entities
public abstract class SocialMediaEntity
{
    // Encapsulation: Attributes are encapsulated as private fields
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    // Abstraction: Constructor initializes CreatedAt and UpdatedAt properties
    public SocialMediaEntity()
    {
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    // Abstraction: Method to update the UpdatedAt property
    public virtual void Update()
    {
        UpdatedAt = DateTime.Now;
    }
}

// Class representing a user in the social media platform
public class User : SocialMediaEntity
{
    // Encapsulation: Properties are encapsulated with appropriate access modifiers
    public string Username { get; set; }
    public string Email { get; set; }
    private string Password { get; set; }
    public string MobileNumber { get; set; } // New property for mobile number

    // Inheritance: User class inherits common attributes and behavior from SocialMediaEntity class
    public User(int id, string username, string email, string password, string mobileNumber)
    {
        Id = id;
        Username = username;
        Email = email;
        Password = password;
        MobileNumber = mobileNumber;
    }

    // Encapsulation: Method to set the user's password
    public void SetPassword(string newPassword)
    {
        Password = newPassword;
    }

    // Abstraction: Method to display user information
    public void DisplayUserInfo()
    {
        Console.WriteLine($"Username: {Username}, Email: {Email}, Mobile Number: {MobileNumber}");
    }
}

// Class managing user authentication
public class AuthenticationManager
{
    // Abstraction: Method to authenticate using username and password
    public bool Authenticate(string username, string password)
    {
        // Placeholder logic for authentication
        // Return true if authentication is successful, false otherwise
        return true;
    }

    // Abstraction: Method to authenticate with multi-factor authentication
    public bool AuthenticateWithMFA(string username, string password, string verificationCode)
    {
        // Placeholder logic for multi-factor authentication
        // Return true if authentication with MFA is successful, false otherwise
        return true;
    }

    // Abstraction: Method to send verification code to mobile number
    public void SendVerificationCode(string mobileNumber)
    {
        // Placeholder logic for sending verification code to mobile number
        Console.WriteLine($"Verification code sent to {mobileNumber}");
    }
}

// Main program class
public class Program
{
    // Main method
    public static void Main(string[] args)
    {
        Console.WriteLine("\nWelcome to Unite Social (ZA) Media Platform!");
        Console.WriteLine("\n=== Unite Social is a family-centered platform with a focus on the wholesomeness of life. Warning! Here, we might just make you happy! ===");

        bool exit = false;

        // Encapsulation: Main program logic is encapsulated within a loop
        while (!exit)
        {
            Console.WriteLine("\nSelect an option:");
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Log in");
            Console.WriteLine("3. Create a post");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            // Encapsulation: Switch statement encapsulates different program options
            switch (choice)
            {
                case "1":
                    Register();
                    break;
                case "2":
                    Login();
                    break;
                case "3":
                    CreatePost();
                    break;
                case "4":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    // Abstraction: Method for user registration
    static void Register()
    {
        Console.WriteLine("\n Welcome to the registration Portal");
        Console.WriteLine("\n=== Welcome to Unite Social family. You can relax! Your information is secured with MFA to enhance your security!");
        Console.WriteLine("\n Let's get you sorted!:");
        Console.Write("Enter username: ");
        string username = Console.ReadLine();
        Console.Write("Enter email: ");
        string email = Console.ReadLine();
        Console.Write("Enter password: ");
        string password = Console.ReadLine();
        Console.Write("Enter mobile number: ");
        string mobileNumber = Console.ReadLine();

        // Placeholder logic for user registration
        Console.WriteLine("User registered successfully!");
    }

    // Abstraction: Method for user login
    static void Login()
    {
        Console.WriteLine("\nYou are a log away to make trending content!!!");
        Console.WriteLine("\nLog in:");
        Console.Write("Enter username: ");
        string username = Console.ReadLine();
        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        // Authentication manager instance
        AuthenticationManager authManager = new AuthenticationManager();

        // Encapsulation: Authenticate user using provided credentials
        bool isAuthenticated = authManager.Authenticate(username, password);

        if (isAuthenticated)
        {
            Console.WriteLine("Authentication successful!");
            
            // Send verification code to mobile number for MFA
            authManager.SendVerificationCode("+27699983955"); // Placeholder mobile number
            
            Console.Write("Enter verification code from mobile: ");
            string verificationCode = Console.ReadLine();

            // Authenticate with MFA
            bool isMFAAuthenticated = authManager.AuthenticateWithMFA(username, password, verificationCode);

            if (isMFAAuthenticated)
            {
                Console.WriteLine("Multi-factor authentication successful!");
                // Proceed to user dashboard or main menu
            }
            else
            {
                Console.WriteLine("Multi-factor authentication failed. Please try again.");
            }
        }
        else
        {
            Console.WriteLine("Authentication failed. Invalid username or password.");
        }
    }

    // Abstraction: Method for creating a post
    static void CreatePost()
    {
        Console.WriteLine("\n=== You are clicks away from shaping opinion in society! Well done!! ===");
        Console.WriteLine("\nWhat is on your mind? ");
        Console.WriteLine("\nCreate a new post:");
        Console.Write("Enter post content: ");
        string postContent = Console.ReadLine();

        Post post = new Post(1, 1, postContent); // Assuming user ID 1 for demonstration
        
        Console.WriteLine("Do you want to upload photos? (yes/no)");
        Console.WriteLine("\n=== Photos live forever! Pick your very best pic that your loved ones will upload one day, and remember you by!! ===");
        string uploadPhotosChoice = Console.ReadLine();

        if (uploadPhotosChoice.ToLower() == "yes")
        {
            Camera camera = new Camera();
            camera.TakePhoto();

            Console.WriteLine("Do you want to process the image? (yes/no)");
            string processImageChoice = Console.ReadLine();

            if (processImageChoice.ToLower() == "yes")
            {
                Console.WriteLine("Enter the URL of the image: ");
                string imageUrl = Console.ReadLine();

                ImageProcessing imageProcessing = new ImageProcessing();
                imageProcessing.ProcessImage(imageUrl);
            }
        }

        post.Update();
        Console.WriteLine("Post created successfully!");

        // Display post information including timestamps
        post.DisplayPostInfo();
    }
}

// Placeholder class representing a post in the social media platform
public class Post : SocialMediaEntity
{
    // Placeholder properties and methods for managing posts
    public int UserId { get; set; } // Added UserId property
    public string Content { get; set; }

    public Post(int id, int userId, string content)
    {
        Id = id;
        UserId = userId;
        Content = content;
    }

    // Abstraction: Method to display post information including timestamps
    public void DisplayPostInfo()
    {
        Console.WriteLine($"Post ID: {Id}");
        Console.WriteLine($"User ID: {UserId}");
        Console.WriteLine($"Content: {Content}");
        Console.WriteLine($"Created At: {CreatedAt}"); // Display creation timestamp
        Console.WriteLine($"Updated At: {UpdatedAt}"); // Display update timestamp
    }
}

// Placeholder class representing a camera
public class Camera
{
    // Placeholder method to simulate taking a photo
    public void TakePhoto()
    {
        Console.WriteLine("Photo taken.");
    }
}

// Placeholder class representing image processing functionality
public class ImageProcessing
{
    // Placeholder method to simulate image processing
    public void ProcessImage(string imageUrl)
    {
        Console.WriteLine($"Image processed: {imageUrl}");
    }
}