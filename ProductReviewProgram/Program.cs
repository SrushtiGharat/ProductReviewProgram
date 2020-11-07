using System;
using System.Collections.Generic;

namespace ProductReviewProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductReviewManagement management = new ProductReviewManagement();

            Console.WriteLine("Welcome To Product Review Program");
            List<ProductReview> productReviewList = new List<ProductReview>()
            {
                new ProductReview(){ProductID=1,UserID=1,Rating=2,Review="Good",isLike=true},
                new ProductReview(){ProductID=2,UserID=1,Rating=4,Review="Good",isLike=true},
                new ProductReview(){ProductID=3,UserID=1,Rating=5,Review="Good",isLike=true},
                new ProductReview(){ProductID=4,UserID=1,Rating=6,Review="Good",isLike=false},
                new ProductReview(){ProductID=5,UserID=1,Rating=2,Review="Nice",isLike=true},
                new ProductReview(){ProductID=6,UserID=1,Rating=1,Review="Bad",isLike=true},
                new ProductReview(){ProductID=8,UserID=1,Rating=1,Review="Good",isLike=false},
                new ProductReview(){ProductID=8,UserID=1,Rating=9,Review="Nice",isLike=true},
                new ProductReview(){ProductID=2,UserID=1,Rating=10,Review="Nice",isLike=true},
                new ProductReview(){ProductID=10,UserID=1,Rating=8,Review="Nice",isLike=true},
                new ProductReview(){ProductID=11,UserID=1,Rating=3,Review="Nice",isLike=true}
            };
            Console.WriteLine("------------------------------------");
            Console.WriteLine("1.Display all records\n2.Get Top 3 Best-Rated products\n3.Get products with id 1,4,9 and ratings > 3" +
                "\n4.Get Count Of Reviews");
            Console.WriteLine("------------------------------------");
           
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    foreach (var list in productReviewList)
                    {
                        Console.WriteLine("ProductID : " + list.ProductID + " " + "UserID : " + list.UserID + " " + "Rating : " + list.Rating + " " + "Review : " + list.Review + " " + "isLike : " + list.isLike);
                    }
                    break;
                case 2:
                    management.TopBestRatedRecords(productReviewList);
                    break;
                case 3:
                    management.RatingsGreaterThanThreeOfSpecificProducts(productReviewList);
                    break;
                case 4:
                    management.GetCountOfReviews(productReviewList);
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
            
        }
    }
}
