using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductReviewProgram
{
    class ProductReviewManagement
    {
        /// <summary>
        /// Get top 3 best rated products
        /// </summary>
        /// <param name="listProductReview"></param>
        public void TopBestRatedRecords(List<ProductReview> listProductReview)
        {
            var recordedData = (from productReviews in listProductReview
                                orderby productReviews.Rating descending
                                select productReviews).Take(3);

            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductID : " + list.ProductID + " " + "UserID : " + list.UserID
                    + " " + "Rating : " + list.Rating + " " + "Review : " + list.Review + " " + "isLike : " + list.isLike);
            }
        }

        /// <summary>
        /// Get products with id 1,4 or 9 having rating >3
        /// </summary>
        /// <param name="listProductReview"></param>
        public void RatingsGreaterThanThreeOfSpecificProducts(List<ProductReview> listProductReview)
        {
            var recordedData = from productReview in listProductReview
                               where (productReview.ProductID == 1 || productReview.ProductID == 4 || productReview.ProductID == 9)
                               && productReview.Rating > 3
                               select productReview;
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductID : " + list.ProductID + " " + "UserID : " + list.UserID
                    + " " + "Rating : " + list.Rating + " " + "Review : " + list.Review + " " + "isLike : " + list.isLike);
            }
        }
    }
}
