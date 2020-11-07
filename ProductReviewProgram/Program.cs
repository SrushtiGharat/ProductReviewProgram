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
                "\n4.Get Count Of Reviews\n5.Get ProductId and Review\n6.Skip Top 5 Records\n7.Insert values in Data Table\n8.Get Records with" +
                "isLike True\n9.Get average rating for each product\n10.Get products with review as nice\n11.Get records where UserId is 10 OrderBy Rating");
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
                    management.GetTopBestRatedRecords(productReviewList);
                    break;
                case 3:
                    management.RatingsGreaterThanThreeOfSpecificProducts(productReviewList);
                    break;
                case 4:
                    management.GetCountOfReviews(productReviewList);
                    break;
                case 5:
                    management.GetProductIdAndReview(productReviewList);
                    break;
                case 6:
                    management.SkipTop5Records(productReviewList);
                    break;
                case 7:
                    management.InsertValuesInDataTable(productReviewList);
                    Console.WriteLine("Values inserted successfully");
                    break;
                case 8:
                    management.InsertValuesInDataTable(productReviewList);
                    management.GetRecordsWithIsLikeTrue();
                    break;
                case 9:
                    management.InsertValuesInDataTable(productReviewList);
                    management.GetAverageRating();
                    break;
                case 10:
                    management.InsertValuesInDataTable(productReviewList);
                    management.GetProductWithReviewNice();
                    break;
                case 11:
                    management.InsertValuesInDataTable(productReviewList);
                    management.GetRecordsWithUserId10();
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
            
        }
    }
}
